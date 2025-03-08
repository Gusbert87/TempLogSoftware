using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApplicationSettings;

namespace View.Controls.SettingsPanel
{
    public partial class ChannelSettingsPanel : SettingsPanelImpl
    {
        public const String TITLE = "Canale ";
        private int n;

        public ChannelSettingsPanel(int n)
        {
            this.n = n;
            InitializeComponent();
            gbxBorder.Text = TITLE + n;

            loadSettings();

            numInf.Enabled = chkIsInf.Checked;
            numSup.Enabled = chkIsSup.Checked;
        }

        private void NumSupValueChanged(object sender, EventArgs e)
        {
            componentChanged();
        }

        private void NumInfValueChanged(object sender, EventArgs e)
        {
            componentChanged();
        }

        private void ChkIsInfCheckedChanged(object sender, EventArgs e)
        {
            numInf.Enabled = chkIsInf.Checked;
            componentChanged();
        }

        private void ChkIsSupCheckedChanged(object sender, EventArgs e)
        {
            numSup.Enabled = chkIsSup.Checked;
            componentChanged();
        }

        public override bool setVisible(bool visible)
        {
            DialogResult result = DialogResult.OK;

            if (visible && !Visible)
            {
                bool connected = ViewUtils.attempConnection(false);
                Visible = connected;
                result = connected ? DialogResult.OK : DialogResult.Cancel;
            }
            else
            {
                Visible = visible;
            }

            return Visible;
        }

        public override void loadSettings()
        {
            float sup = GlobalSettings.SerialSettings.Sup[n];
            float inf = GlobalSettings.SerialSettings.Inf[n];

            chkIsSup.Checked = GlobalSettings.SerialSettings.isSup[n];
            chkIsInf.Checked = GlobalSettings.SerialSettings.isInf[n];

            numSup.Value = new Decimal(sup);
            numInf.Value = new Decimal(inf);
            int newInf = Decimal.ToInt32(numInf.Value);

        }

        public override void saveSettings()
        {
            float newSup = (float)Decimal.ToDouble(numSup.Value);
            float newInf = (float)Decimal.ToDouble(numInf.Value);

            GlobalSettings.SerialSettings.isSup[n] = chkIsSup.Checked;
            GlobalSettings.SerialSettings.isInf[n] = chkIsInf.Checked;

            GlobalSettings.SerialSettings.Sup[n] = newSup;
            GlobalSettings.SerialSettings.Inf[n] = newInf;

            settingsChanged = false;
        }

        public override bool isSettingsChanged()
        {
            bool changed = false;

            float newSup = (float)Decimal.ToDouble(numSup.Value);
            float newInf = (float)Decimal.ToDouble(numInf.Value);

            if (!newSup.Equals(GlobalSettings.SerialSettings.Sup[n])) changed = true;
            if (!newInf.Equals(GlobalSettings.SerialSettings.Inf[n])) changed = true;
            if (!chkIsSup.Checked.Equals(GlobalSettings.SerialSettings.isSup)) changed = false;
            if (!chkIsInf.Checked.Equals(GlobalSettings.SerialSettings.isInf)) changed = false;

            return changed;
        }

        private void ChannelSettingsPanelLoad(object sender, EventArgs e)
        {
            chkIsInf.CheckedChanged += ChkIsInfCheckedChanged;
            chkIsSup.CheckedChanged += ChkIsSupCheckedChanged;
            numInf.ValueChanged += NumInfValueChanged;
            numSup.ValueChanged += NumSupValueChanged;
            loaded = true;
        }
    }
}
