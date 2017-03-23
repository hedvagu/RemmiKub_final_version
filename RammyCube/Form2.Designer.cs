namespace RammyCube
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btnTurnFinished = new System.Windows.Forms.Button();
            this.pnlMainPlayBoard = new System.Windows.Forms.Panel();
            this.pnlPlayer2 = new System.Windows.Forms.Panel();
            this.pnlPlayer3 = new System.Windows.Forms.Panel();
            this.pnlPlayer4 = new System.Windows.Forms.Panel();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTurnFinished
            // 
            resources.ApplyResources(this.btnTurnFinished, "btnTurnFinished");
            this.btnTurnFinished.Name = "btnTurnFinished";
            this.btnTurnFinished.UseVisualStyleBackColor = true;
            this.btnTurnFinished.Click += new System.EventHandler(this.btnTurnFinished_Click);
            // 
            // pnlMainPlayBoard
            // 
            this.pnlMainPlayBoard.AllowDrop = true;
            resources.ApplyResources(this.pnlMainPlayBoard, "pnlMainPlayBoard");
            this.pnlMainPlayBoard.BackColor = System.Drawing.Color.Silver;
            this.pnlMainPlayBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMainPlayBoard.Name = "pnlMainPlayBoard";
            this.pnlMainPlayBoard.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlMainPlayBoard_DragDrop);
            this.pnlMainPlayBoard.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlMainPlayBoard_DragEnter);
            this.pnlMainPlayBoard.DragLeave += new System.EventHandler(this.pnlMainPlayBoard_DragLeave);
            this.pnlMainPlayBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainPlayBoard_Paint);
            this.pnlMainPlayBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainPlayBoard_MouseDown);
            // 
            // pnlPlayer2
            // 
            this.pnlPlayer2.BackColor = System.Drawing.Color.Sienna;
            this.pnlPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pnlPlayer2, "pnlPlayer2");
            this.pnlPlayer2.Name = "pnlPlayer2";
            this.pnlPlayer2.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPlayer2_Paint);
            // 
            // pnlPlayer3
            // 
            resources.ApplyResources(this.pnlPlayer3, "pnlPlayer3");
            this.pnlPlayer3.BackColor = System.Drawing.Color.Sienna;
            this.pnlPlayer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPlayer3.Name = "pnlPlayer3";
            // 
            // pnlPlayer4
            // 
            resources.ApplyResources(this.pnlPlayer4, "pnlPlayer4");
            this.pnlPlayer4.BackColor = System.Drawing.Color.Sienna;
            this.pnlPlayer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPlayer4.Name = "pnlPlayer4";
            // 
            // lblPlayerName
            // 
            resources.ApplyResources(this.lblPlayerName, "lblPlayerName");
            this.lblPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerName.ForeColor = System.Drawing.Color.Khaki;
            this.lblPlayerName.Name = "lblPlayerName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Name = "label1";
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.pnlPlayer2);
            this.Controls.Add(this.pnlPlayer3);
            this.Controls.Add(this.pnlPlayer4);
            this.Controls.Add(this.pnlMainPlayBoard);
            this.Controls.Add(this.btnTurnFinished);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTurnFinished;
        public System.Windows.Forms.Panel pnlMainPlayBoard;
        private System.Windows.Forms.Panel pnlPlayer2;
        private System.Windows.Forms.Panel pnlPlayer3;
        private System.Windows.Forms.Panel pnlPlayer4;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label label1;



    }
}