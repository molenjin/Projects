namespace ColorLinkSolver
{
    partial class FormMain
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
            this.cbTasks = new System.Windows.Forms.ComboBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.pnBoard = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblBoardStatus = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbTasks
            // 
            this.cbTasks.FormattingEnabled = true;
            this.cbTasks.Location = new System.Drawing.Point(40, 25);
            this.cbTasks.Name = "cbTasks";
            this.cbTasks.Size = new System.Drawing.Size(121, 23);
            this.cbTasks.TabIndex = 0;
            this.cbTasks.SelectedIndexChanged += new System.EventHandler(this.cbTasks_SelectedIndexChanged);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(167, 24);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 1;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // pnBoard
            // 
            this.pnBoard.BackColor = System.Drawing.Color.White;
            this.pnBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnBoard.Location = new System.Drawing.Point(40, 60);
            this.pnBoard.Name = "pnBoard";
            this.pnBoard.Size = new System.Drawing.Size(640, 640);
            this.pnBoard.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(605, 726);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblBoardStatus
            // 
            this.lblBoardStatus.AutoSize = true;
            this.lblBoardStatus.Location = new System.Drawing.Point(248, 28);
            this.lblBoardStatus.Name = "lblBoardStatus";
            this.lblBoardStatus.Size = new System.Drawing.Size(70, 15);
            this.lblBoardStatus.TabIndex = 4;
            this.lblBoardStatus.Text = "BoardStatus";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(40, 726);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(74, 15);
            this.lblTimer.TabIndex = 5;
            this.lblTimer.Text = "Elapsed time";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 761);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblBoardStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnBoard);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.cbTasks);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Link Solver by MO 2023";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbTasks;
        private Button btnSolve;
        private Panel pnBoard;
        private Button btnClose;
        private Label lblBoardStatus;
        private Label lblTimer;
    }
}