using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace unzipMasterGUId
{
    public partial class unzipMaster : Form
    {
        bool sameFolder = false;
        public unzipMaster()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            if (File.Exists("defaults.txt"))
            {
                string[] def = File.ReadAllLines("defaults.txt");
                try
                {
                    txtPath.Text = def[0];
                    targetPath.Text = def[1];
                }
                catch { }
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            //opens file explorer
            using (FolderBrowserDialog fbd = new FolderBrowserDialog {Description= "Select target folder" })
            {
                if (fbd.ShowDialog()==DialogResult.OK) //folder has been selected
                {
                    txtPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void extract_Click(object sender, EventArgs e)
        {
            if (txtPath.Text != "" && targetPath.Text != "")
            {
                
                string path = @txtPath.Text;
                string target = @targetPath.Text;
                UseWaitCursor = true;
                Application.DoEvents();
                if (Directory.Exists(path) && Directory.Exists(target)) //checks if the folders exist
                {
                    string[] fileEntries = Directory.GetFiles(path); //get all files in the folder
                    progressBar1.Maximum = fileEntries.Where(x => x.Skip(x.Length - 3).ToString() == "zip").ToArray().Length;
                    progressBar1.Step = 1;
                    progressBar1.Value = 0;
                    progressBar1.Visible = true;
                    foreach (string fileName in fileEntries)
                    {
                        try
                        {
                            //extract all the files into directories with the same name in the target directory
                            if (sameFolder)
                            {
                                messageLabel.Text = $"Extracting {fileName.Replace(path, "")}...";
                                ZipFile.ExtractToDirectory(fileName, fileName.Replace(".zip", ""));
                                progressBar1.PerformStep();
                            }
                            else
                            {
                                messageLabel.Text = $"Extracting {fileName.Replace(path, "")}...";
                                ZipFile.ExtractToDirectory(fileName, target + fileName.Replace(path, "").Replace(".zip", ""));
                                progressBar1.PerformStep();
                            }
                            //File.Delete(fileName);
                            ///TODO make zip file deletion optional for the user
                        }
                        catch (Exception)
                        {
                            //if they're not zips, do nothing
                            ///TODO make this work for other compression types
                        }
                    }
                    messageLabel.Text = "";
                    UseWaitCursor = false;
                    Application.DoEvents();
                }
                else
                {
                    messageLabel.Text = "Folder does not exist!";
                }
            }
            else
            {
                messageLabel.Text = "Please fill all required fields!";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sameFolder = !sameFolder;
            targetPath.Enabled = !targetPath.Enabled;
            targetBrowseButton.Enabled = !targetBrowseButton.Enabled;
            if (sameFolder)
            {
                targetPath.Text = txtPath.Text;
            }
            else
            {
                targetPath.Text = "";
            }
        }

        private void targetBrowseButton_Click(object sender, EventArgs e)
        {
            //opens file explorer
            using (FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Select target folder" })
            {
                if (fbd.ShowDialog() == DialogResult.OK) //folder has been selected
                {
                    targetPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void setDefault_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("defaults.txt");
            sw.WriteLine(txtPath.Text);
            sw.Write(targetPath.Text);
            sw.Close();
        }
    }
}
