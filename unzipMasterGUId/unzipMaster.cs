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
            if (txtPath.Text != "" && (targetPath.Text != "" || sameFolder))
            {
                string path = @txtPath.Text;
                string target = @targetPath.Text;
                if (Directory.Exists(path) && Directory.Exists(target)) //checks if the folders exist
                {
                    string[] fileEntries = Directory.GetFiles(path); //get all files in the folder
                    foreach (string fileName in fileEntries)
                    {
                        try
                        {
                            //extract all the files into directories with the same name in the target directory
                            if (sameFolder)
                            {
                                ZipFile.ExtractToDirectory(fileName, fileName.Replace(".zip", ""));
                            }
                            else if (target != "")
                            {
                                ZipFile.ExtractToDirectory(fileName, target + fileName.Replace(path, "").Replace(".zip", ""));
                            }
                            else
                            {
                                messageLabel.Text = "Please give a target folder!";
                                break;
                            }
                            File.Delete(fileName);///TODO make zip file deletion optional for the user
                        }
                        catch (Exception)
                        {
                            //if they're not zips, do nothing
                            ///TODO make this work for other compression types
                        }
                    }
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
            targetPath.Text = "";
            targetBrowseButton.Enabled = !targetBrowseButton.Enabled;
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
    }
}
