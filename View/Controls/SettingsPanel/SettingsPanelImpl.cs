using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace View.Controls.SettingsPanel
{
    public abstract partial class SettingsPanelImpl : UserControl, SettingsPanelInterface
    {
        protected bool settingsChanged = false;
        protected bool loaded = false;

        public bool SettingsChanged { get => settingsChanged; set => settingsChanged=value; }

        public event SettingsChangedHandler settingsChangedHandler;

        public SettingsPanelImpl()
        {
            InitializeComponent();
        }

        public abstract bool isSettingsChanged();


        public abstract void loadSettings();

        public abstract void saveSettings();

        public abstract bool setVisible(bool visible);

        protected void componentChanged()
        {
            if (!settingsChanged && loaded)
            {
                settingsChangedHandler?.Invoke();
                settingsChanged = true;
            }
        }
    }
}
