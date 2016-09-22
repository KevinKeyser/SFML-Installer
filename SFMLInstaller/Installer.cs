using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFMLInstaller
{
    public partial class Installer : Form
    {
        public const string DESTINATIONPATH = @"C:\Program Files (x86)";

        public static int TotalFiles = 0;
        public static int CurrentFile = 0;

        Task installTask;

        public Installer()
        {
            InitializeComponent();
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            installTask = Task.Run(InstallFiles);
            progressTimer.Start();
        }

        public async Task InstallFiles()
        {
            string filepath = $"{Environment.CurrentDirectory}\\InstallationFiles";

            infoLabel.Text = "Gathering Files...";
            List<string> allFiles;
            try
            {
                allFiles = GetAllFilesIn(filepath + "\\SFML");
            }
            catch
            {
                MessageBox.Show("Error Gathering Files.");
                return;
            }


            infoLabel.Text = "Modifying Allocated Files...";
            try
            {
                for (int i = 0; i < allFiles.Count; i++)
                {
                    allFiles[i] = allFiles[i].Replace($"{filepath}\\", "");
                }
            }
            catch
            {
                MessageBox.Show("Failed To Modify Allocated Files.");
            }


            bool success = false;
            do
            {
                CurrentFile = 0;
                TotalFiles = allFiles.Count;
                installProgressBar.Maximum = TotalFiles;

                string lastFile = "";

                try
                {
                    foreach (string file in allFiles)
                    {
                        infoLabel.Text = $"Copying Files... {CurrentFile}\\{TotalFiles}";
                        lastFile = file;
                        File.Copy($"{filepath}\\{file}", $"{DESTINATIONPATH}\\{file}", true);
                        CurrentFile++;
                    }
                    success = true;
                }
                catch
                {
                    DialogResult processResult = MessageBox.Show($"Failed To Copy {lastFile} To {DESTINATIONPATH}.", "Error", MessageBoxButtons.AbortRetryIgnore);
                    if (processResult == DialogResult.Abort)
                    {
                        return;
                    }
                    else if (processResult == DialogResult.Ignore)
                    {
                        break;
                    }
                }
            }
            while (!success);

            infoLabel.Text = "Adding Environment Variables...";
            success = false;
            do
            {
                try
                {
                    Environment.SetEnvironmentVariable("SFML", $"{DESTINATIONPATH}\\SFML", EnvironmentVariableTarget.Machine);
                    success = true;
                }
                catch
                {
                    DialogResult processResult = MessageBox.Show($"Failed To Add Environment Variable", "Error", MessageBoxButtons.AbortRetryIgnore);
                    if (processResult == DialogResult.Abort)
                    {
                        return;
                    }
                    else if (processResult == DialogResult.Ignore)
                    {
                        break;
                    }
                }
            } while (!success);


            infoLabel.Text = "Installing Templates...";
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo($"{filepath}\\SFMLTemplates.vsix");
            process.Start();
            process.Exited += Process_Exited;
            process.ErrorDataReceived += Process_ErrorDataReceived;
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Process process = (Process)sender;
            DialogResult processResult = MessageBox.Show(e.Data, "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            if (processResult == DialogResult.Abort)
            {
                return;
            }
            else if (processResult == DialogResult.Retry)
            {
                process.Start();
                process.Exited += Process_Exited;
                return;
            }
            else
            {
                progressTimer.Stop();

                infoLabel.Text = "";
                MessageBox.Show("Installation Done.");
                installTask.Dispose();
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            Process process = (Process)sender;
            if(process.ExitCode != 0)
            {
                DialogResult processResult = MessageBox.Show("Templates Failed To Install.", "Warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                if (processResult == DialogResult.Abort)
                {
                    return;
                }
                else if (processResult == DialogResult.Retry)
                {
                    process.Start();
                    process.Exited += Process_Exited;
                    return;
                }
            }

            progressTimer.Stop();

            infoLabel.Text = "";
            MessageBox.Show("Installation Done.");
            installTask.Dispose();
        }

        public List<string> GetAllFilesIn(string filepath)
        {
            List<string> files = Directory.GetFiles(filepath).ToList();

            foreach (string path in Directory.GetDirectories(filepath))
            {
                files.AddRange(GetAllFilesIn(path));
            }

            return files;
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            installProgressBar.Value = CurrentFile;
        }
    }
}
