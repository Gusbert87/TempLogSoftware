using ApplicationSettings;
using Serial;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace View.Forms
{
    public partial class CalibrationForm : Form
    {
        private const float FIRST_ROW_HEIGHT = 50F;
        private const float CHANNEL_ROW_HEIGHT = 25F;

        List<CheckBox> channelsCheckBox = new List<CheckBox>();
        List<Label> channelsLabel = new List<Label>();
        List<NumericUpDown> channelsUpDown = new List<NumericUpDown>();

        private bool connectedOnLoad = false;

        private int channel;

        private bool attempConnection()
        {
            if (ViewUtils.IsConnected) return true;

            bool connected = ViewUtils.attempConnection(false);

            return connected;
        }

        private void initChannelControls()
        {
            int n = GlobalSettings.SerialSettings.N;

            pnlTableMain.RowCount = (channel < 0 ? n + 1 : 1);
            pnlTableMain.RowStyles.Clear();
            pnlTableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, FIRST_ROW_HEIGHT));
            pnlTableMain.Size = new Size(359, Convert.ToInt32(FIRST_ROW_HEIGHT + (channel < 0 ? n + 1 : 1) * CHANNEL_ROW_HEIGHT) + 2 + (channel < 0 ? n + 1 : 1));
            pnlTableMain.Controls.Clear();
            pnlTableMain.Controls.Add(lblCanale, 0, 0);
            pnlTableMain.Controls.Add(lblValoreAttuale, 1, 0);
            pnlTableMain.Controls.Add(lblNuovoValore, 2, 0);


            ClientSize = new Size(366, 57 + Convert.ToInt32(FIRST_ROW_HEIGHT + (channel < 0 ? n + 1 : 1) * CHANNEL_ROW_HEIGHT) + 2 + (channel < 0 ? n + 1 : 1));


            Label lblChannel;
            NumericUpDown numChannel;
            if (channel >= 0)
            {
                Label lblChannelName = createNameLabel(channel);
                lblChannel = createChannelLabel(channel);
                numChannel = createNumericUpDown(channel);
                numChannel.Enabled = true;

                channelsLabel.Add(lblChannel);
                channelsUpDown.Add(numChannel);

                pnlTableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, CHANNEL_ROW_HEIGHT));
                pnlTableMain.Controls.Add(lblChannelName, 0, 1);
                pnlTableMain.Controls.Add(lblChannel, 1, 1);
                pnlTableMain.Controls.Add(numChannel, 2, 1);
            }
            else
            {
                CheckBox cbxChannel;

                for (int i = Math.Max(channel, 0); i < (channel < 0 ? n : channel); i++)
                {
                    cbxChannel = createCheckBox(i);
                    lblChannel = createChannelLabel(i);
                    numChannel = createNumericUpDown(i);

                    channelsCheckBox.Add(cbxChannel);
                    channelsLabel.Add(lblChannel);
                    channelsUpDown.Add(numChannel);

                    cbxChannel.CheckedChanged += CbxChannelCheckedChanged;

                    pnlTableMain.RowStyles.Add(new RowStyle(SizeType.Absolute, CHANNEL_ROW_HEIGHT));
                    pnlTableMain.Controls.Add(cbxChannel, 0, i + 1);
                    pnlTableMain.Controls.Add(lblChannel, 1, i + 1);
                    pnlTableMain.Controls.Add(numChannel, 2, i + 1);
                }
            }
        }

        private void CbxChannelCheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbxChannel = (CheckBox)sender;
            int index = channelsCheckBox.IndexOf(cbxChannel);
            channelsUpDown[index].Enabled = cbxChannel.Checked;
            btnApply.Enabled = true;

            if (cbxChannel.Checked)
            {
                try
                {
                    channelsUpDown[index].Value = Convert.ToDecimal(float.Parse(channelsLabel[index].Text));
                }
                catch (FormatException)
                {
                    channelsUpDown[index].Value = 0;
                }
            }
        }

        private static Label createChannelLabel(int i)
        {
            Label lblChannel = new Label();
            lblChannel.Anchor = (AnchorStyles)((AnchorStyles.Top | AnchorStyles.Bottom));
            lblChannel.AutoSize = true;
            lblChannel.Location = new Point(40, 1);
            lblChannel.Name = "lblChannel";
            lblChannel.Size = new Size(40, 50);
            lblChannel.TabIndex = 0;
            lblChannel.Text = "Attendere...";
            lblChannel.TextAlign = ContentAlignment.MiddleCenter;
            return lblChannel;
        }

        private static CheckBox createCheckBox(int i)
        {
            CheckBox cbxChannel = new CheckBox();
            //var cbxChannel = new CheckBox();
            cbxChannel = (CheckBox)setupChannelLabel(cbxChannel, i);
            cbxChannel.UseVisualStyleBackColor = true;
            return cbxChannel;
        }

        private static Label createNameLabel(int i)
        {
            Label lblChannel = new Label();
            lblChannel = (Label)setupChannelLabel(lblChannel, i);
            return lblChannel;
        }

        private static Control setupChannelLabel(Control ctlChannel, int i)
        {
            ctlChannel.Anchor = AnchorStyles.Right;
            ctlChannel.AutoSize = true;
            ctlChannel.Location = new Point(48, 56);
            ctlChannel.Name = "cbxCanale1";
            ctlChannel.RightToLeft = RightToLeft.Yes;
            ctlChannel.Size = new Size(68, 17);
            ctlChannel.TabIndex = 3;
            ctlChannel.Text = "Canale " + i;
            return ctlChannel;
        }

        private static NumericUpDown createNumericUpDown(int i)
        {
            NumericUpDown numChannel = new NumericUpDown();
            numChannel.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Bottom)));
            numChannel.Location = new Point(271, 55);
            numChannel.Name = "numNuovoValore " + i;
            numChannel.Size = new Size(63, 20);//55,20
            numChannel.TabIndex = 5;
            numChannel.Enabled = false;
            numChannel.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numChannel.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numChannel.Minimum = new decimal(new int[] { 1000, 0, 0, -2147483648 });
            numChannel.DecimalPlaces = 2;
            return numChannel;
        }

        public CalibrationForm() : this(-1)
        {
        }

        public CalibrationForm(int channel)
        {
            this.channel = channel;
            InitializeComponent();
        }

        private void CalibrationFormLoad(object sender, EventArgs e)
        {
            SerialThread.Instance.temperatureArrivedHandler += temperatureArrived;
            SerialThread.Instance.connectedHandler += startTemperaturePolling;

            bool connected = false;
            if (ViewUtils.IsConnected)
            {
                connectedOnLoad = true;
                connected = true;
                startTemperaturePolling(true);
            }
            else
            {
                connected = attempConnection();
            }

            if (connected)
            {
                initChannelControls();
            } else
            {
                Close();
            }
        }

        private void startTemperaturePolling(bool connected)
        {
            if (connected)
            {
                SerialTemperaturePolling.Instance.stopTemperaturePolling();
                SerialTemperaturePolling.Instance.startTemperaturePolling((int)GlobalSettings.TEMPERATURE_INTERVAL.CONTINUOS);
                SerialThread.Instance.connectedHandler -= startTemperaturePolling;
            }
        }

        private void temperatureArrived(T t)
        {
            Invoke(new Action(() =>
            {
                if (channel >= 0)
                {
                    channelsLabel[0].Text = t[channel].ToString();
                }
                else
                {
                    for (int i = 0; i < GlobalSettings.SerialSettings.N; i++)
                    {
                        channelsLabel[i].Text = t[i].ToString();
                    }
                }
            }));
        }

        private void sendCalibrations()
        {
            CalibrationData calibrationData;
            if (channel >= 0)
            {
                calibrationData = new CalibrationData(channel + 1, (float)Convert.ToDouble(channelsUpDown[0].Value));
                SerialThread.Instance.SendCalibrationData(calibrationData);
            }
            else
            {
                for (int i = 0; i < GlobalSettings.SerialSettings.N; i++)
                {
                    if (channelsCheckBox[i].Checked)
                    {
                        calibrationData = new CalibrationData(i + 1, (float)Convert.ToDouble(channelsUpDown[i].Value));
                        SerialThread.Instance.SendCalibrationData(calibrationData);
                    }
                }
            }
        }

        private void btnOkClick(object sender, EventArgs e)
        {
            sendCalibrations();
        }

        private void btnApplyClick(object sender, EventArgs e)
        {
            sendCalibrations();
        }

        private void CalibrationFormClosing(object sender, FormClosingEventArgs e)
        {
            SerialTemperaturePolling.Instance.stopTemperaturePolling();
            SerialThread.Instance.temperatureArrivedHandler -= temperatureArrived;

            SerialThread.Instance.connectedHandler -= startTemperaturePolling;

            if (!connectedOnLoad) ViewUtils.disconnect();
        }
    }
}
