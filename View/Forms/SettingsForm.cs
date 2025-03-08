using ApplicationSettings;
using Serial;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using View.Controls.SettingsPanel;

namespace View.Forms
{
    public partial class SettingsForm : Form
    {
        List<SettingsPanelInterface> settingsPanels = new List<SettingsPanelInterface>();
        bool connectedOnLoad = false;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void trvSettingsBeforeSelect(Object sender, TreeViewCancelEventArgs e)
        {
            bool oldVisible = false;
            bool newVisible = true;

            int oldIndex = getNodeIndex(((TreeView)sender).SelectedNode);
            int newIndex = getNodeIndex(e.Node);

            if (oldIndex == newIndex) return;

            bool connected = true;
            if (newIndex > 0) connected = attempConnection();

            if (!connected)
            {
                e.Cancel = true;
                return;
            }

            oldVisible = settingsPanels[oldIndex].setVisible(false);
            newVisible = settingsPanels[newIndex].setVisible(true);

            if (!(!oldVisible && newVisible))
                e.Cancel = true;

            /*switch (index)
            {
                case 0:
                    pnlGlobalSettingsPanel.setVisible(true);
                    break;
                default:
                    result = pnlGlobalSettingsPanel.setVisible(false);
                    if (result == DialogResult.Cancel)
                        e.Cancel = true;
                    break;
            }*/
        }

        private bool attempConnection()
        {
            if (ViewUtils.IsConnected) return true;

            bool connected = ViewUtils.attempConnection(false);

            if (connected) {
                initChannelPanels();
                trvSettings.Nodes[1].Expand();
            }

            return connected;
        }

        private void initChannelPanels()
        {
            trvSettings.BeginUpdate();

            foreach(SettingsPanelImpl panel in settingsPanels)
            {
                Controls.Remove(panel);
            }
            Controls.Add(pnlGlobalSettingsPanel);
            Controls.Add(pnlControlUnitSettingsPanel);

            settingsPanels.Clear();
            settingsPanels.Add(pnlGlobalSettingsPanel);
            settingsPanels.Add(pnlControlUnitSettingsPanel);

            trvSettings.Nodes.Clear();
            trvSettings.Nodes.Add(new TreeNode("TempLog"));
            trvSettings.Nodes.Add(new TreeNode("Centralina"));

            ChannelSettingsPanel pnlChannelSettings = null;
            TreeNode newNode = null;
            TreeNode parentNode = trvSettings.Nodes[1];
            for (int i = 0; i < GlobalSettings.SerialSettings.N; i++)
            {
                pnlChannelSettings = new ChannelSettingsPanel(i);
                pnlChannelSettings.Location = new System.Drawing.Point(128, 0);
                pnlChannelSettings.MinimumSize = new System.Drawing.Size(414, 77);
                pnlChannelSettings.Name = "pnlControlUnitSettingsPanel" + i;
                pnlChannelSettings.SettingsChanged = false;
                pnlChannelSettings.Size = new System.Drawing.Size(420, 88);
                pnlChannelSettings.TabIndex = 7;
                pnlChannelSettings.Visible = false;
                settingsPanels.Add(pnlChannelSettings);
                Controls.Add(pnlChannelSettings);
                newNode = new TreeNode(ChannelSettingsPanel.TITLE + i);
                parentNode.Nodes.Add(newNode);
            }
            trvSettings.EndUpdate();
        }

        private int getNodeIndex(TreeNode node)
        {
            if (node == null) return 0;
            int index = node.Index;
            if (node.Parent != null)
                index += node.Parent.Index + 1;

            return index;
        }

        private void trvSettingsBeforeExpand(Object sender, TreeViewCancelEventArgs e)
        {
            int node = getNodeIndex(e.Node);
            bool connected = true;
            if (node > 0) connected = attempConnection();
            if (!connected) e.Cancel = true;
        }

        private void enableApply()
        {
            this.btnApply.Enabled = true;
        }

        private void disableApply()
        {
            this.btnApply.Enabled = false;
        }

        private void btnOkClick(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void SettingsFormLoad(object sender, EventArgs e)
        {
            settingsPanels.Add(pnlGlobalSettingsPanel);
            settingsPanels.Add(pnlControlUnitSettingsPanel);

            pnlGlobalSettingsPanel.settingsChangedHandler += enableApply;
            pnlControlUnitSettingsPanel.settingsChangedHandler += enableApply;

            GlobalSettings.settingsSavedHandler += disableApply;

            if (ViewUtils.IsConnected)
            {
                connectedOnLoad = true;
                initChannelPanels();
            }
        }

        private void SettingsFormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalSettings.settingsSavedHandler -= disableApply;
            pnlGlobalSettingsPanel.settingsChangedHandler -= enableApply;
            pnlControlUnitSettingsPanel.settingsChangedHandler -= enableApply;

            if (!connectedOnLoad && ViewUtils.IsConnected)
                ViewUtils.disconnect();
        }

        private void saveSettings()
        {
            for (int i = 0; i < settingsPanels.Count; i++)
                settingsPanels[i].saveSettings();

            if (SerialThread.Instance.isConnected)
                SerialThread.Instance.SendSettings(GlobalSettings.SerialSettings);
        }

        private void btnApplyClick(object sender, EventArgs e)
        {
            saveSettings();
            initChannelPanels();
        }

        private void btnCancelClick(object sender, EventArgs e)
        {

        }
    }
}
