namespace RammyCube
{
    partial class FormHelp
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
            this.btnprev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnprev
            // 
            this.btnprev.Location = new System.Drawing.Point(833, 357);
            this.btnprev.Name = "btnprev";
            this.btnprev.Size = new System.Drawing.Size(54, 53);
            this.btnprev.TabIndex = 0;
            this.btnprev.Text = "button1";
            this.btnprev.UseVisualStyleBackColor = true;
            this.btnprev.Click += new System.EventHandler(this.btnprev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(12, 357);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(54, 53);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "button1";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnprev_Click);
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 422);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnprev);
            this.Name = "FormHelp";
            this.Text = "FormHelp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnprev;
        private System.Windows.Forms.Button btnNext;
    }
}