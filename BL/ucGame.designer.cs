namespace BL
{
    partial class ucGame
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fswNetork = new System.IO.FileSystemWatcher();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fswNetork)).BeginInit();
            this.SuspendLayout();
            // 
            // fswNetork
            // 
            this.fswNetork.EnableRaisingEvents = true;
            this.fswNetork.Filter = "*.xml";
            this.fswNetork.SynchronizingObject = this;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucGame";
            this.Size = new System.Drawing.Size(263, 238);
            this.Load += new System.EventHandler(this.ucGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fswNetork)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher fswNetork;
        private System.Windows.Forms.Timer timer1;
    }
}
