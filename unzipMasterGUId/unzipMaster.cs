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
                    List<string> myarguments = new List<string>();
                    backgroundWorker1.DoWork += (obj, e1) => WorkerDoWork(path, target);
                    backgroundWorker1.RunWorkerAsync(argument: myarguments) ;
                            
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
        private void WorkerDoWork(string path1, string target1)
        {
            string[] fileEntries = Directory.GetFiles(path1); //get all files in the folder
            load load = new load();
            load.Show();
            load.progressBar1.Maximum = fileEntries.Where(y => y.Skip(y.Length - 3).ToString() == "zip").ToArray().Length;
            load.progressBar1.Step = 1;
            load.progressBar1.Value = 0;
            load.progressBar1.Visible = true;
            foreach (string fileName in fileEntries)
            {
                try
                {
                    //extract all the files into directories with the same name in the target directory
                    if (sameFolder)
                    {
                        load.messageLabel.Text = $"Extracting {fileName.Replace(path1, "")}...";
                        ZipFile.ExtractToDirectory(fileName, fileName.Replace(".zip", ""));
                        load.progressBar1.PerformStep();
                    }
                    else
                    {
                        load.messageLabel.Text = $"Extracting {fileName.Replace(path1, "")}...";
                        List<string> arguments = new List<string>();
                        arguments.Add(target1); arguments.Add(path1); arguments.Add(fileName);
                        ZipFile.ExtractToDirectory(fileName, target1 + fileName.Replace(path1, "").Replace(".zip", ""));
                        load.progressBar1.PerformStep();
                    }
                    //File.Delete(fileName);
                    ///TODO make zip file deletion optional for the user
                }
                catch (Exception)
                {
                    load.messageLabel.Text = "Itt a hiba ";
                    //if they're not zips, do nothing
                    ///TODO make this work for other compression types
                }
            }
            UseWaitCursor = false;
            Application.DoEvents();
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
        }
    }
}
