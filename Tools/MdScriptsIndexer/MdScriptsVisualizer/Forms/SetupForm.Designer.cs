namespace MdScriptsVisualizer
{
    partial class SetupForm
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
            label1 = new Label();
            TxtDirectoryPath = new TextBox();
            BtnSelectDirectory = new Button();
            label2 = new Label();
            BtnConfirm = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 0;
            label1.Text = "Selected Directory:";
            // 
            // TxtDirectoryPath
            // 
            TxtDirectoryPath.Location = new Point(12, 27);
            TxtDirectoryPath.Name = "TxtDirectoryPath";
            TxtDirectoryPath.ReadOnly = true;
            TxtDirectoryPath.Size = new Size(395, 23);
            TxtDirectoryPath.TabIndex = 1;
            // 
            // BtnSelectDirectory
            // 
            BtnSelectDirectory.Location = new Point(219, 56);
            BtnSelectDirectory.Name = "BtnSelectDirectory";
            BtnSelectDirectory.Size = new Size(188, 32);
            BtnSelectDirectory.TabIndex = 2;
            BtnSelectDirectory.Text = "Select Directory";
            BtnSelectDirectory.UseVisualStyleBackColor = true;
            BtnSelectDirectory.Click += BtnSelectDirectory_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(201, 30);
            label2.TabIndex = 3;
            label2.Text = "Please select the directory where the \r\nunpacked md files are located.";
            // 
            // BtnConfirm
            // 
            BtnConfirm.Enabled = false;
            BtnConfirm.Location = new Point(12, 94);
            BtnConfirm.Name = "BtnConfirm";
            BtnConfirm.Size = new Size(395, 32);
            BtnConfirm.TabIndex = 4;
            BtnConfirm.Text = "Confirm";
            BtnConfirm.UseVisualStyleBackColor = true;
            BtnConfirm.Click += BtnConfirm_Click;
            // 
            // SetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 133);
            Controls.Add(BtnConfirm);
            Controls.Add(label2);
            Controls.Add(BtnSelectDirectory);
            Controls.Add(TxtDirectoryPath);
            Controls.Add(label1);
            Name = "SetupForm";
            Text = "Directory Setup";
            Load += SetupForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TxtDirectoryPath;
        private Button BtnSelectDirectory;
        private Label label2;
        private Button BtnConfirm;
    }
}