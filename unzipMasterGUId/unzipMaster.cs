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
            string path = @txtPath.Text;
            if (Directory.Exists(path)) //checks if the folder exists
            {
                string[] fileEntries = Directory.GetFiles(path); //get all files in the folder
                foreach (string fileName in fileEntries)
                {
                    try
                    {
                        //extract all the files into directories with the same name
                        ZipFile.ExtractToDirectory(fileName,fileName.Replace(".zip",""));
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
    }
}
