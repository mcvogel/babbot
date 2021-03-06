﻿/*
    This file is part of BabBot.

    BabBot is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    BabBot is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with BabBot.  If not, see <http://www.gnu.org/licenses/>.
  
    Copyright 2009 BabBot Team
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BabBot.Manager;
using BabBot.Common;

namespace BabBot.Forms
{
    public partial class AppOptionsForm : GenericDialog
    {
        public string Msg;
        
        public AppOptionsForm() 
            : base("app_config")
        {
            InitializeComponent();
            cbWoWVersion.DataSource = DataManager.WoWVersions;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbLuaCallback.Text.Equals(""))
                MessageBox.Show(this, "Lua Callback Address is empty");
            else if (cbWoWVersion.SelectedIndex < 0)
                MessageBox.Show(this, "WoW Version field is empty");
            else {
                try
                {
                    Config config = ProcessManager.Config;

                    config.WoWInfo.ExePath = tbWowExePath.Text;
                    config.WoWInfo.GuestUsername = tbGuestUsername.Text;
                    config.WoWInfo.GuestPassword = tbGuestPassword.Text;
                    config.WoWInfo.NoSound = cbNoSound.Checked;
                    config.WoWInfo.Windowed = cbWindowed.Checked;
                    config.WoWInfo.Resize = cbResize.Checked;
                    config.WoWInfo.Version = cbWoWVersion.Text;
                    config.WoWInfo.RefreshTime = (int)numRefresh.Value;
                    config.WoWInfo.IdleSleepTime = (int)numIdleSleep.Value * 1000;

                    config.LogParams.Dir = tbLogsPath.Text;
                    config.LogParams.DisplayLogs = chkLogOutput.Checked;
                    
                    config.DebugMode = cbDebugMode.Checked;
                    config.LuaExePath = tbLuaExePath.Text;
                    config.ProfilesDir = tbProfilesPath.Text;

                    config.CustomParams.LuaCallback = tbLuaCallback.Text;
                    config.CustomParams.WinTitle = tbWinTitle.Text;

                    IsChanged = false;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AppOptionsForm_Load(object sender, EventArgs e)
        {
            Config config = ProcessManager.Config;

            tbWowExePath.Text = config.WoWInfo.ExePath;
            tbGuestUsername.Text = config.WoWInfo.GuestUsername;
            tbGuestPassword.Text = config.WoWInfo.GuestPassword;
            cbNoSound.Checked = config.WoWInfo.NoSound;
            cbWindowed.Checked = config.WoWInfo.Windowed;
            cbResize.Checked = config.WoWInfo.Resize;
            cbWoWVersion.Text = config.WoWInfo.Version;

            if (cbWoWVersion.Text.Equals("") && (cbWoWVersion.Items.Count == 1))
                // Auto Select first
                cbWoWVersion.SelectedIndex = 0;

            cbDebugMode.Checked = config.DebugMode;
            tbLuaExePath.Text = config.LuaExePath;
            tbProfilesPath.Text = config.ProfilesDir;

            tbLogsPath.Text = config.LogParams.Dir;
            chkLogOutput.Checked = config.LogParams.DisplayLogs;


            tbLuaCallback.Text = config.CustomParams.LuaCallback;
            tbWinTitle.Text = config.CustomParams.WinTitle;

            numRefresh.Minimum = ProcessManager.AppConfig.MinBotRefreshTime;
            numRefresh.Value = config.WoWInfo.RefreshTime;
            numIdleSleep.Value = (int)(config.WoWInfo.IdleSleepTime/1000);

            // Check debug view
            cbDebugMode_CheckedChanged(sender, e);
            
            IsChanged = false;

            if (Msg != null)
            {
                MessageBox.Show(this, Msg);
                btnSave.Enabled = true;
            }
        }

        private void btnBrowseWowExec_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog { Multiselect = false, Filter = "WoW Executable (*.exe)|*.exe" };
            if (dlg.ShowDialog() == DialogResult.OK)
                tbWowExePath.Text = dlg.FileName;
        }

        private void btnFindWowExePath_Click(object sender, EventArgs e)
        {
            string wowPath = AppHelper.GetWowInstallationPath();
            if (!string.IsNullOrEmpty(wowPath))
                tbWowExePath.Text = wowPath;
            else
                MessageBox.Show("Cannot find WoW's installation path.");
        }

        private void btnBrowseLogPath_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                tbLogsPath.Text = dlg.SelectedPath;
        }

        private void btnProfilesPath_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                tbProfilesPath.Text = dlg.SelectedPath;
        }

        protected override void RegisterChange(object sender, EventArgs e)
        {
            base.RegisterChange(sender, e);
        }

        private void btnLuaPath_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog { Multiselect = false, Filter = "Lua Executable (lua.exe)|lua.exe" };
            if (dlg.ShowDialog() == DialogResult.OK)
                tbLuaExePath.Text = dlg.FileName;
        }

        private void cbDebugMode_CheckedChanged(object sender, EventArgs e)
        {
            labelLuaPath.Visible = cbDebugMode.Checked;
            tbLuaExePath.Visible = cbDebugMode.Checked;
            btnLuaPath.Visible = cbDebugMode.Checked;

            RegisterChange(sender, e);

        }
    }
}
