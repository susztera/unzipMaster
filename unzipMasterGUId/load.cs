using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace unzipMasterGUId
{
    public partial class load : Form
    {
        public load()
        {
            InitializeComponent();
        }

        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string file = (string)e.Argument;
        }

    }
}
