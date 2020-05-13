namespace unzipMasterGUId
{
    partial class unzipMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(unzipMaster));
            this.browseButton = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.extract = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.targetPath = new System.Windows.Forms.TextBox();
            this.targetBrowseButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.setDefault = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(250, 38);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(85, 38);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(159, 20);
            this.txtPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select folder:";
            // 
            // extract
            // 
            this.extract.Location = new System.Drawing.Point(131, 180);
            this.extract.Name = "extract";
            this.extract.Size = new System.Drawing.Size(75, 23);
            this.extract.TabIndex = 6;
            this.extract.Text = "Extract all";
            this.extract.UseVisualStyleBackColor = true;
            this.extract.Click += new System.EventHandler(this.extract_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.ForeColor = System.Drawing.Color.Red;
            this.messageLabel.Location = new System.Drawing.Point(50, 113);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 13);
            this.messageLabel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target folder:";
            // 
            // targetPath
            // 
            this.targetPath.Location = new System.Drawing.Point(85, 87);
            this.targetPath.Name = "targetPath";
            this.targetPath.Size = new System.Drawing.Size(159, 20);
            this.targetPath.TabIndex = 4;
            // 
            // targetBrowseButton
            // 
            this.targetBrowseButton.Location = new System.Drawing.Point(250, 84);
            this.targetBrowseButton.Name = "targetBrowseButton";
            this.targetBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.targetBrowseButton.TabIndex = 5;
            this.targetBrowseButton.Text = "Browse";
            this.targetBrowseButton.UseVisualStyleBackColor = true;
            this.targetBrowseButton.Click += new System.EventHandler(this.targetBrowseButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(88, 64);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Extract into same folder";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // setDefault
            // 
            this.setDefault.Location = new System.Drawing.Point(131, 224);
            this.setDefault.Name = "setDefault";
            this.setDefault.Size = new System.Drawing.Size(75, 23);
            this.setDefault.TabIndex = 7;
            this.setDefault.Text = "Set defaults";
            this.setDefault.UseVisualStyleBackColor = true;
            this.setDefault.Click += new System.EventHandler(this.setDefault_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 148);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(310, 23);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            // 
            // unzipMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 271);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.setDefault);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.targetBrowseButton);
            this.Controls.Add(this.targetPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.extract);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.browseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "unzipMaster";
            this.Text = "Unzip Master";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button extract;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox targetPath;
        private System.Windows.Forms.Button targetBrowseButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button setDefault;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

