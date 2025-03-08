using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace View.Controls.SettingsPanel
{
    public delegate void SettingsChangedHandler();
    interface SettingsPanelInterface
    {
        bool SettingsChanged { get; set; }
        bool setVisible(bool visible);
        void loadSettings();
        void saveSettings();
        bool isSettingsChanged();
    }
}
