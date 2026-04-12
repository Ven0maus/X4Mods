namespace MdScriptsVisualizer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            MdFiles = new ListBox();
            MdScripts = new ListBox();
            CmbMdValuesFilter = new ComboBox();
            label2 = new Label();
            CmbFilterMode = new ComboBox();
            label3 = new Label();
            TxtSearch = new TextBox();
            label4 = new Label();
            label5 = new Label();
            BtnSetupDirectory = new Button();
            label7 = new Label();
            MdCalls = new ListBox();
            label8 = new Label();
            label9 = new Label();
            MdUsedBy = new ListBox();
            SearchTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(12, 112);
            label1.Name = "label1";
            label1.Size = new Size(73, 21);
            label1.TabIndex = 0;
            label1.Text = "MdFiles:";
            // 
            // MdFiles
            // 
            MdFiles.FormattingEnabled = true;
            MdFiles.Location = new Point(12, 136);
            MdFiles.Name = "MdFiles";
            MdFiles.Size = new Size(391, 274);
            MdFiles.TabIndex = 1;
            MdFiles.SelectedIndexChanged += MdFiles_SelectedIndexChanged;
            // 
            // MdScripts
            // 
            MdScripts.FormattingEnabled = true;
            MdScripts.Location = new Point(409, 138);
            MdScripts.Name = "MdScripts";
            MdScripts.Size = new Size(362, 274);
            MdScripts.TabIndex = 2;
            MdScripts.SelectedIndexChanged += MdScripts_SelectedIndexChanged;
            // 
            // CmbMdValuesFilter
            // 
            CmbMdValuesFilter.FormattingEnabled = true;
            CmbMdValuesFilter.Items.AddRange(new object[] { "Show All", "Cues", "Libraries", "Macros" });
            CmbMdValuesFilter.Location = new Point(627, 114);
            CmbMdValuesFilter.Name = "CmbMdValuesFilter";
            CmbMdValuesFilter.Size = new Size(144, 23);
            CmbMdValuesFilter.TabIndex = 3;
            CmbMdValuesFilter.Text = "Show All";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(579, 115);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 4;
            label2.Text = "Filter:";
            // 
            // CmbFilterMode
            // 
            CmbFilterMode.FormattingEnabled = true;
            CmbFilterMode.Items.AddRange(new object[] { "Filename search", "File content search", "MD function search" });
            CmbFilterMode.Location = new Point(12, 33);
            CmbFilterMode.Name = "CmbFilterMode";
            CmbFilterMode.Size = new Size(197, 23);
            CmbFilterMode.TabIndex = 5;
            CmbFilterMode.Text = "Filename search";
            CmbFilterMode.SelectedIndexChanged += CmbFilterMode_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(104, 21);
            label3.TabIndex = 6;
            label3.Text = "Search Mode:";
            // 
            // TxtSearch
            // 
            TxtSearch.Location = new Point(12, 83);
            TxtSearch.Name = "TxtSearch";
            TxtSearch.Size = new Size(391, 23);
            TxtSearch.TabIndex = 7;
            TxtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 59);
            label4.Name = "label4";
            label4.Size = new Size(60, 21);
            label4.TabIndex = 8;
            label4.Text = "Search:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(409, 114);
            label5.Name = "label5";
            label5.Size = new Size(148, 21);
            label5.TabIndex = 9;
            label5.Text = "MdScript Content:";
            // 
            // BtnSetupDirectory
            // 
            BtnSetupDirectory.Location = new Point(215, 31);
            BtnSetupDirectory.Name = "BtnSetupDirectory";
            BtnSetupDirectory.Size = new Size(188, 24);
            BtnSetupDirectory.TabIndex = 12;
            BtnSetupDirectory.Text = "Setup Directory Path";
            BtnSetupDirectory.UseVisualStyleBackColor = true;
            BtnSetupDirectory.Click += BtnSetupDirectory_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label7.Location = new Point(486, 43);
            label7.Name = "label7";
            label7.Size = new Size(285, 37);
            label7.TabIndex = 13;
            label7.Text = "Md Scripts Visualizer";
            // 
            // MdCalls
            // 
            MdCalls.FormattingEnabled = true;
            MdCalls.Location = new Point(12, 439);
            MdCalls.Name = "MdCalls";
            MdCalls.Size = new Size(391, 259);
            MdCalls.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(12, 416);
            label8.Name = "label8";
            label8.Size = new Size(50, 21);
            label8.TabIndex = 17;
            label8.Text = "Calls:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.Location = new Point(409, 415);
            label9.Name = "label9";
            label9.Size = new Size(75, 21);
            label9.TabIndex = 19;
            label9.Text = "Used By:";
            // 
            // MdUsedBy
            // 
            MdUsedBy.FormattingEnabled = true;
            MdUsedBy.Location = new Point(409, 439);
            MdUsedBy.Name = "MdUsedBy";
            MdUsedBy.Size = new Size(421, 259);
            MdUsedBy.TabIndex = 18;
            // 
            // SearchTimer
            // 
            SearchTimer.Interval = 300;
            SearchTimer.Tick += SearchTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 708);
            Controls.Add(label9);
            Controls.Add(MdUsedBy);
            Controls.Add(label8);
            Controls.Add(MdCalls);
            Controls.Add(label7);
            Controls.Add(BtnSetupDirectory);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(TxtSearch);
            Controls.Add(label3);
            Controls.Add(CmbFilterMode);
            Controls.Add(label2);
            Controls.Add(CmbMdValuesFilter);
            Controls.Add(MdScripts);
            Controls.Add(MdFiles);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Md Scripts Visualizer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox MdFiles;
        private ListBox MdScripts;
        private ComboBox CmbMdValuesFilter;
        private Label label2;
        private ComboBox CmbFilterMode;
        private Label label3;
        private TextBox TxtMdValuesSearch;
        private TextBox TxtMdScriptsSearch;
        private TextBox TxtSearch;
        private Label label4;
        private Label label5;
        private Button BtnSetupDirectory;
        private Label label7;
        private ListBox MdCalls;
        private Label label8;
        private Label label9;
        private ListBox MdUsedBy;
        private System.Windows.Forms.Timer SearchTimer;
    }
}
