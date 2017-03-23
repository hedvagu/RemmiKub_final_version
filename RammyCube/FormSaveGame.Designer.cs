namespace RammyCube
{
    partial class FormSaveGame
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNotSave = new System.Windows.Forms.Button();
            this.btnCancelSve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(292, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "yes";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(88, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Do you want to save the game?";
            // 
            // btnNotSave
            // 
            this.btnNotSave.Location = new System.Drawing.Point(190, 131);
            this.btnNotSave.Name = "btnNotSave";
            this.btnNotSave.Size = new System.Drawing.Size(75, 23);
            this.btnNotSave.TabIndex = 0;
            this.btnNotSave.Text = "no";
            this.btnNotSave.UseVisualStyleBackColor = true;
            this.btnNotSave.Click += new System.EventHandler(this.btnNotSave_Click);
            // 
            // btnCancelSve
            // 
            this.btnCancelSve.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelSve.Location = new System.Drawing.Point(89, 131);
            this.btnCancelSve.Name = "btnCancelSve";
            this.btnCancelSve.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSve.TabIndex = 0;
            this.btnCancelSve.Text = "cancel";
            this.btnCancelSve.UseVisualStyleBackColor = true;
            this.btnCancelSve.Visible = false;
            this.btnCancelSve.Click += new System.EventHandler(this.btnCancelSve_Click);
            // 
            // FormSaveGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RammyCube.Properties.Resources.KlaliBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.btnCancelSve;
            this.ClientSize = new System.Drawing.Size(472, 223);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelSve);
            this.Controls.Add(this.btnNotSave);
            this.Controls.Add(this.btnSave);
            this.Name = "FormSaveGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Game";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSaveGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNotSave;
        private System.Windows.Forms.Button btnCancelSve;
    }
}