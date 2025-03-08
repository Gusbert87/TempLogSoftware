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
    public partial class ControlUnitSettingsPanel : SettingsPanelImpl
    {
        public ControlUnitSettingsPanel()
        {
            InitializeComponent();
        }

        public override bool isSettingsChanged()
        {
            int newN = Decimal.ToInt32(this.numNumChannels.Value);
            int N = GlobalSettings.SerialSettings.N;

            if (newN != N) return true;

            return false;
        }

        public override void loadSettings()
        {
            int N = GlobalSettings.SerialSettings.N;
            this.numNumChannels.Value = N;
        }

        public override void saveSettings()
        {
            int newN = Decimal.ToInt32(this.numNumChannels.Value);

            GlobalSettings.SerialSettings.N = newN;

            settingsChanged = false;
        }

        public override bool setVisible(bool visible)
        {
            DialogResult result = DialogResult.OK;

            if (visible && !Visible)
            {
                bool connected = ViewUtils.attempConnection(false);
                Visible = connected;
                result = connected ? DialogResult.OK : DialogResult.Cancel;
            } else
            {
                Visible = visible;
            }

            return Visible;
        }

        private void ControlUnitSettingsPanelLoad(object sender, EventArgs e)
        {
            //ViewUtils.attempConnection(false);
            loadSettings();
            loaded = true;
        }

        private void numNumChannelsValueChanged(object sender, EventArgs e)
        {
            componentChanged();
        }
    }
}
