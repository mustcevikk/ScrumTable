namespace ScrumTable
{
    partial class frm_ScrumTable
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
            this.lbl_BaslikDne = new System.Windows.Forms.Label();
            this.lbl_BaslikInP = new System.Windows.Forms.Label();
            this.lbl_AddStory = new System.Windows.Forms.Label();
            this.lbl_BaslikNotS = new System.Windows.Forms.Label();
            this.lbl_BaslikSto = new System.Windows.Forms.Label();
            this.pnl_Done = new System.Windows.Forms.Panel();
            this.pnl_NotStarted = new System.Windows.Forms.Panel();
            this.pnl_InProgress = new System.Windows.Forms.Panel();
            this.pnl_Stories = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnl_Stories.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_BaslikDne
            // 
            this.lbl_BaslikDne.AutoSize = true;
            this.lbl_BaslikDne.Location = new System.Drawing.Point(712, 15);
            this.lbl_BaslikDne.Name = "lbl_BaslikDne";
            this.lbl_BaslikDne.Size = new System.Drawing.Size(38, 13);
            this.lbl_BaslikDne.TabIndex = 2;
            this.lbl_BaslikDne.Text = "DONE";
            // 
            // lbl_BaslikInP
            // 
            this.lbl_BaslikInP.AutoSize = true;
            this.lbl_BaslikInP.Location = new System.Drawing.Point(484, 15);
            this.lbl_BaslikInP.Name = "lbl_BaslikInP";
            this.lbl_BaslikInP.Size = new System.Drawing.Size(81, 13);
            this.lbl_BaslikInP.TabIndex = 3;
            this.lbl_BaslikInP.Text = "IN PROGRESS";
            // 
            // lbl_AddStory
            // 
            this.lbl_AddStory.AutoSize = true;
            this.lbl_AddStory.Location = new System.Drawing.Point(133, 15);
            this.lbl_AddStory.Name = "lbl_AddStory";
            this.lbl_AddStory.Size = new System.Drawing.Size(59, 13);
            this.lbl_AddStory.TabIndex = 10;
            this.lbl_AddStory.Text = "+ add story";
            this.lbl_AddStory.Click += new System.EventHandler(this.AddStoryLabelineTiklama);
            // 
            // lbl_BaslikNotS
            // 
            this.lbl_BaslikNotS.AutoSize = true;
            this.lbl_BaslikNotS.Location = new System.Drawing.Point(281, 15);
            this.lbl_BaslikNotS.Name = "lbl_BaslikNotS";
            this.lbl_BaslikNotS.Size = new System.Drawing.Size(84, 13);
            this.lbl_BaslikNotS.TabIndex = 4;
            this.lbl_BaslikNotS.Text = "NOT STARTED";
            // 
            // lbl_BaslikSto
            // 
            this.lbl_BaslikSto.AutoSize = true;
            this.lbl_BaslikSto.Location = new System.Drawing.Point(73, 15);
            this.lbl_BaslikSto.Name = "lbl_BaslikSto";
            this.lbl_BaslikSto.Size = new System.Drawing.Size(54, 13);
            this.lbl_BaslikSto.TabIndex = 5;
            this.lbl_BaslikSto.Text = "STORIES";
            // 
            // pnl_Done
            // 
            this.pnl_Done.Location = new System.Drawing.Point(638, 31);
            this.pnl_Done.Name = "pnl_Done";
            this.pnl_Done.Size = new System.Drawing.Size(180, 615);
            this.pnl_Done.TabIndex = 6;
            // 
            // pnl_NotStarted
            // 
            this.pnl_NotStarted.Location = new System.Drawing.Point(226, 31);
            this.pnl_NotStarted.Name = "pnl_NotStarted";
            this.pnl_NotStarted.Size = new System.Drawing.Size(180, 615);
            this.pnl_NotStarted.TabIndex = 7;
            // 
            // pnl_InProgress
            // 
            this.pnl_InProgress.Location = new System.Drawing.Point(431, 31);
            this.pnl_InProgress.Name = "pnl_InProgress";
            this.pnl_InProgress.Size = new System.Drawing.Size(180, 615);
            this.pnl_InProgress.TabIndex = 8;
            // 
            // pnl_Stories
            // 
            this.pnl_Stories.Controls.Add(this.button1);
            this.pnl_Stories.Location = new System.Drawing.Point(21, 31);
            this.pnl_Stories.Name = "pnl_Stories";
            this.pnl_Stories.Size = new System.Drawing.Size(180, 615);
            this.pnl_Stories.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_ScrumTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(834, 661);
            this.Controls.Add(this.lbl_BaslikDne);
            this.Controls.Add(this.lbl_BaslikInP);
            this.Controls.Add(this.lbl_AddStory);
            this.Controls.Add(this.lbl_BaslikNotS);
            this.Controls.Add(this.lbl_BaslikSto);
            this.Controls.Add(this.pnl_Done);
            this.Controls.Add(this.pnl_NotStarted);
            this.Controls.Add(this.pnl_InProgress);
            this.Controls.Add(this.pnl_Stories);
            this.Name = "frm_ScrumTable";
            this.Text = "Scrum Table";
            this.pnl_Stories.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_BaslikDne;
        private System.Windows.Forms.Label lbl_BaslikInP;
        private System.Windows.Forms.Label lbl_AddStory;
        private System.Windows.Forms.Label lbl_BaslikNotS;
        private System.Windows.Forms.Label lbl_BaslikSto;
        private System.Windows.Forms.Panel pnl_Done;
        private System.Windows.Forms.Panel pnl_NotStarted;
        private System.Windows.Forms.Panel pnl_InProgress;
        private System.Windows.Forms.Panel pnl_Stories;
        private System.Windows.Forms.Button button1;
    }
}

