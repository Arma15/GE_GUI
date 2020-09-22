namespace GEGUI
{
    partial class GE_GUI
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
            this.PartNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ItemDescription = new System.Windows.Forms.TextBox();
            this.Hcat = new System.Windows.Forms.TextBox();
            this.AddAllBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ToolResult = new System.Windows.Forms.TextBox();
            this.LoopUpBtn = new System.Windows.Forms.Button();
            this.EdhrTag = new System.Windows.Forms.TextBox();
            this.MiniPreview = new System.Windows.Forms.TextBox();
            this.AddTagBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TypeCmb = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ToolName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.FolderPath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.RobotPose = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SubJobName = new System.Windows.Forms.TextBox();
            this.RemoveTool = new System.Windows.Forms.Button();
            this.ToolRemove = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.NewPartNumberbtn = new System.Windows.Forms.Button();
            this.SetPartNumberbtn = new System.Windows.Forms.Button();
            this.ApproachCmb = new System.Windows.Forms.ComboBox();
            this.PounceCmb = new System.Windows.Forms.ComboBox();
            this.SubjobSetBtn = new System.Windows.Forms.Button();
            this.PoseSetBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PartNumber
            // 
            this.PartNumber.Location = new System.Drawing.Point(134, 102);
            this.PartNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PartNumber.Name = "PartNumber";
            this.PartNumber.Size = new System.Drawing.Size(452, 26);
            this.PartNumber.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hcat";
            // 
            // ItemDescription
            // 
            this.ItemDescription.Location = new System.Drawing.Point(134, 143);
            this.ItemDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.ReadOnly = true;
            this.ItemDescription.Size = new System.Drawing.Size(452, 26);
            this.ItemDescription.TabIndex = 3;
            // 
            // Hcat
            // 
            this.Hcat.Location = new System.Drawing.Point(134, 58);
            this.Hcat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Hcat.Name = "Hcat";
            this.Hcat.Size = new System.Drawing.Size(452, 26);
            this.Hcat.TabIndex = 1;
            this.Hcat.TextChanged += new System.EventHandler(this.Model_TextChanged);
            // 
            // AddAllBtn
            // 
            this.AddAllBtn.Location = new System.Drawing.Point(715, 1098);
            this.AddAllBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddAllBtn.Name = "AddAllBtn";
            this.AddAllBtn.Size = new System.Drawing.Size(198, 46);
            this.AddAllBtn.TabIndex = 13;
            this.AddAllBtn.Text = "Add Data";
            this.AddAllBtn.UseVisualStyleBackColor = true;
            this.AddAllBtn.Click += new System.EventHandler(this.AddAllBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Part Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Item Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 416);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Expected Tool Result";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(526, 416);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "eDHR Tag";
            // 
            // ToolResult
            // 
            this.ToolResult.Location = new System.Drawing.Point(320, 441);
            this.ToolResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ToolResult.Name = "ToolResult";
            this.ToolResult.ReadOnly = true;
            this.ToolResult.Size = new System.Drawing.Size(202, 26);
            this.ToolResult.TabIndex = 9;
            // 
            // LoopUpBtn
            // 
            this.LoopUpBtn.Location = new System.Drawing.Point(717, 29);
            this.LoopUpBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LoopUpBtn.Name = "LoopUpBtn";
            this.LoopUpBtn.Size = new System.Drawing.Size(186, 60);
            this.LoopUpBtn.TabIndex = 39;
            this.LoopUpBtn.Text = "Lookup";
            this.LoopUpBtn.UseVisualStyleBackColor = true;
            this.LoopUpBtn.Click += new System.EventHandler(this.LookUpBtn_Click);
            // 
            // EdhrTag
            // 
            this.EdhrTag.Location = new System.Drawing.Point(530, 441);
            this.EdhrTag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EdhrTag.Name = "EdhrTag";
            this.EdhrTag.ReadOnly = true;
            this.EdhrTag.Size = new System.Drawing.Size(250, 26);
            this.EdhrTag.TabIndex = 10;
            // 
            // MiniPreview
            // 
            this.MiniPreview.Location = new System.Drawing.Point(12, 477);
            this.MiniPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MiniPreview.Multiline = true;
            this.MiniPreview.Name = "MiniPreview";
            this.MiniPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MiniPreview.Size = new System.Drawing.Size(901, 606);
            this.MiniPreview.TabIndex = 15;
            // 
            // AddTagBtn
            // 
            this.AddTagBtn.Location = new System.Drawing.Point(12, 416);
            this.AddTagBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddTagBtn.Name = "AddTagBtn";
            this.AddTagBtn.Size = new System.Drawing.Size(114, 51);
            this.AddTagBtn.TabIndex = 12;
            this.AddTagBtn.Text = "Add";
            this.AddTagBtn.UseVisualStyleBackColor = true;
            this.AddTagBtn.Click += new System.EventHandler(this.AddToolBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 228);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Pounce Region";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 192);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "Approach Side";
            // 
            // TypeCmb
            // 
            this.TypeCmb.Enabled = false;
            this.TypeCmb.FormattingEnabled = true;
            this.TypeCmb.Items.AddRange(new object[] {
            "PF",
            "OCR",
            "QR"});
            this.TypeCmb.Location = new System.Drawing.Point(788, 439);
            this.TypeCmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TypeCmb.Name = "TypeCmb";
            this.TypeCmb.Size = new System.Drawing.Size(86, 28);
            this.TypeCmb.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(784, 414);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "Type";
            // 
            // ToolName
            // 
            this.ToolName.Location = new System.Drawing.Point(134, 441);
            this.ToolName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ToolName.Name = "ToolName";
            this.ToolName.ReadOnly = true;
            this.ToolName.Size = new System.Drawing.Size(178, 26);
            this.ToolName.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(130, 414);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 20);
            this.label10.TabIndex = 29;
            this.label10.Text = "Tool Name";
            // 
            // FolderPath
            // 
            this.FolderPath.Location = new System.Drawing.Point(134, 18);
            this.FolderPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.Size = new System.Drawing.Size(452, 26);
            this.FolderPath.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 29);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 20);
            this.label11.TabIndex = 31;
            this.label11.Text = "Folder Path";
            // 
            // RobotPose
            // 
            this.RobotPose.Location = new System.Drawing.Point(134, 383);
            this.RobotPose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RobotPose.Name = "RobotPose";
            this.RobotPose.ReadOnly = true;
            this.RobotPose.Size = new System.Drawing.Size(452, 26);
            this.RobotPose.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 389);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 20);
            this.label12.TabIndex = 33;
            this.label12.Text = "Working Pose";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(594, 386);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 20);
            this.label13.TabIndex = 34;
            this.label13.Text = "EX: {0,1,2,3,4,5,6}";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 353);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 20);
            this.label14.TabIndex = 35;
            this.label14.Text = "SubJob";
            // 
            // SubJobName
            // 
            this.SubJobName.Location = new System.Drawing.Point(134, 347);
            this.SubJobName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SubJobName.Name = "SubJobName";
            this.SubJobName.ReadOnly = true;
            this.SubJobName.Size = new System.Drawing.Size(452, 26);
            this.SubJobName.TabIndex = 6;
            // 
            // RemoveTool
            // 
            this.RemoveTool.Location = new System.Drawing.Point(12, 1093);
            this.RemoveTool.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RemoveTool.Name = "RemoveTool";
            this.RemoveTool.Size = new System.Drawing.Size(114, 56);
            this.RemoveTool.TabIndex = 36;
            this.RemoveTool.Text = "Remove Tool";
            this.RemoveTool.UseVisualStyleBackColor = true;
            this.RemoveTool.Click += new System.EventHandler(this.RemoveTool_Click);
            // 
            // ToolRemove
            // 
            this.ToolRemove.Location = new System.Drawing.Point(138, 1118);
            this.ToolRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ToolRemove.Name = "ToolRemove";
            this.ToolRemove.Size = new System.Drawing.Size(178, 26);
            this.ToolRemove.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(134, 1093);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 20);
            this.label15.TabIndex = 38;
            this.label15.Text = "Tool Name";
            // 
            // NewPartNumberbtn
            // 
            this.NewPartNumberbtn.Location = new System.Drawing.Point(717, 102);
            this.NewPartNumberbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NewPartNumberbtn.Name = "NewPartNumberbtn";
            this.NewPartNumberbtn.Size = new System.Drawing.Size(186, 60);
            this.NewPartNumberbtn.TabIndex = 40;
            this.NewPartNumberbtn.Text = "New Part Number";
            this.NewPartNumberbtn.UseVisualStyleBackColor = true;
            this.NewPartNumberbtn.Click += new System.EventHandler(this.NewPartNumberbtn_Click);
            // 
            // SetPartNumberbtn
            // 
            this.SetPartNumberbtn.Enabled = false;
            this.SetPartNumberbtn.Location = new System.Drawing.Point(594, 101);
            this.SetPartNumberbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SetPartNumberbtn.Name = "SetPartNumberbtn";
            this.SetPartNumberbtn.Size = new System.Drawing.Size(81, 31);
            this.SetPartNumberbtn.TabIndex = 40;
            this.SetPartNumberbtn.Text = "Set";
            this.SetPartNumberbtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SetPartNumberbtn.UseVisualStyleBackColor = true;
            this.SetPartNumberbtn.Click += new System.EventHandler(this.SetPartNumberbtn_Click);
            // 
            // ApproachCmb
            // 
            this.ApproachCmb.Enabled = false;
            this.ApproachCmb.FormattingEnabled = true;
            this.ApproachCmb.Items.AddRange(new object[] {
            "Front",
            "Back"});
            this.ApproachCmb.Location = new System.Drawing.Point(134, 184);
            this.ApproachCmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ApproachCmb.Name = "ApproachCmb";
            this.ApproachCmb.Size = new System.Drawing.Size(104, 28);
            this.ApproachCmb.TabIndex = 4;
            // 
            // PounceCmb
            // 
            this.PounceCmb.Enabled = false;
            this.PounceCmb.FormattingEnabled = true;
            this.PounceCmb.Items.AddRange(new object[] {
            "Q1",
            "Q2",
            "Q3",
            "Q4"});
            this.PounceCmb.Location = new System.Drawing.Point(135, 222);
            this.PounceCmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PounceCmb.Name = "PounceCmb";
            this.PounceCmb.Size = new System.Drawing.Size(103, 28);
            this.PounceCmb.TabIndex = 5;
            // 
            // SubjobSetBtn
            // 
            this.SubjobSetBtn.Enabled = false;
            this.SubjobSetBtn.Location = new System.Drawing.Point(812, 339);
            this.SubjobSetBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SubjobSetBtn.Name = "SubjobSetBtn";
            this.SubjobSetBtn.Size = new System.Drawing.Size(81, 34);
            this.SubjobSetBtn.TabIndex = 43;
            this.SubjobSetBtn.Text = "Set";
            this.SubjobSetBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SubjobSetBtn.UseVisualStyleBackColor = true;
            this.SubjobSetBtn.Click += new System.EventHandler(this.SubjobSetBtn_Click);
            // 
            // PoseSetBtn
            // 
            this.PoseSetBtn.Enabled = false;
            this.PoseSetBtn.Location = new System.Drawing.Point(812, 383);
            this.PoseSetBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PoseSetBtn.Name = "PoseSetBtn";
            this.PoseSetBtn.Size = new System.Drawing.Size(81, 34);
            this.PoseSetBtn.TabIndex = 44;
            this.PoseSetBtn.Text = "Set";
            this.PoseSetBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PoseSetBtn.UseVisualStyleBackColor = true;
            this.PoseSetBtn.Click += new System.EventHandler(this.PoseSetBtn_Click);
            // 
            // GE_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 1158);
            this.Controls.Add(this.PoseSetBtn);
            this.Controls.Add(this.SubjobSetBtn);
            this.Controls.Add(this.PounceCmb);
            this.Controls.Add(this.ApproachCmb);
            this.Controls.Add(this.SetPartNumberbtn);
            this.Controls.Add(this.NewPartNumberbtn);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ToolRemove);
            this.Controls.Add(this.RemoveTool);
            this.Controls.Add(this.SubJobName);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.RobotPose);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.FolderPath);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ToolName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TypeCmb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AddTagBtn);
            this.Controls.Add(this.MiniPreview);
            this.Controls.Add(this.EdhrTag);
            this.Controls.Add(this.LoopUpBtn);
            this.Controls.Add(this.ToolResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddAllBtn);
            this.Controls.Add(this.Hcat);
            this.Controls.Add(this.ItemDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PartNumber);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GE_GUI";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PartNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ItemDescription;
        private System.Windows.Forms.TextBox Hcat;
        private System.Windows.Forms.Button AddAllBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ToolResult;
        private System.Windows.Forms.Button LoopUpBtn;
        private System.Windows.Forms.TextBox EdhrTag;
        private System.Windows.Forms.TextBox MiniPreview;
        private System.Windows.Forms.Button AddTagBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox TypeCmb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ToolName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox FolderPath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox RobotPose;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox SubJobName;
        private System.Windows.Forms.Button RemoveTool;
        private System.Windows.Forms.TextBox ToolRemove;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button NewPartNumberbtn;
        private System.Windows.Forms.Button SetPartNumberbtn;
        private System.Windows.Forms.ComboBox ApproachCmb;
        private System.Windows.Forms.ComboBox PounceCmb;
        private System.Windows.Forms.Button SubjobSetBtn;
        private System.Windows.Forms.Button PoseSetBtn;
    }
}

