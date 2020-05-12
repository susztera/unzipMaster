using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
