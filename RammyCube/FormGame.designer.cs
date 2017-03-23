namespace RammyCube
{
    partial class FormGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.pnlMainPlayBoard = new System.Windows.Forms.Panel();
            this.btnTurnFinished = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            resources.ApplyResources(this.lblPlayerName, "lblPlayerName");
            this.lblPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerName.ForeColor = System.Drawing.Color.Khaki;
            this.lblPlayerName.Name = "lblPlayerName";
            // 
            // pnlMainPlayBoard
            // 
            this.pnlMainPlayBoard.AllowDrop = true;
            this.pnlMainPlayBoard.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlMainPlayBoard.BackgroundImage = global::RammyCube.Properties.Resources.MainBoard1;
            resources.ApplyResources(this.pnlMainPlayBoard, "pnlMainPlayBoard");
            this.pnlMainPlayBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMainPlayBoard.Name = "pnlMainPlayBoard";
            this.pnlMainPlayBoard.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlMainPlayBoard_DragDrop);
            this.pnlMainPlayBoard.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlMainPlayBoard_DragEnter);
            this.pnlMainPlayBoard.DragLeave += new System.EventHandler(this.pnlMainPlayBoard_DragLeave);
            this.pnlMainPlayBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainPlayBoard_Paint);
            this.pnlMainPlayBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainPlayBoard_MouseDown);
            // 
            // btnTurnFinished
            // 
            this.btnTurnFinished.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.btnTurnFinished, "btnTurnFinished");
            this.btnTurnFinished.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btnTurnFinished.ForeColor = System.Drawing.Color.Teal;
            this.btnTurnFinished.Name = "btnTurnFinished";
            this.btnTurnFinished.UseVisualStyleBackColor = false;
            this.btnTurnFinished.Click += new System.EventHandler(this.btnTurnFinished_Click);
            // 
            // FormGame
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::RammyCube.Properties.Resources.חדש_חדש;
            this.Controls.Add(this.btnTurnFinished);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.pnlMainPlayBoard);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "FormGame";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pnlMainPlayBoard;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Button btnTurnFinished;



    }
}