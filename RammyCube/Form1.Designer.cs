namespace RammyCube
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.numOfPlayers = new System.Windows.Forms.NumericUpDown();
            this.btnOkNumOfPlayers = new System.Windows.Forms.Button();
            this.pnlplayer1 = new System.Windows.Forms.Panel();
            this.cbKindPlayer1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNamePlayer1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.משחקToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.חדשToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.פתחמשחקשמורToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.יציאהToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.יציאהToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.עזרהToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.אודותToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.כלליהמשחקToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlplayer3 = new System.Windows.Forms.Panel();
            this.cbKindPlayer3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNamePlayer3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlplayer2 = new System.Windows.Forms.Panel();
            this.cbKindPlayer2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNamePlayer2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlplayer4 = new System.Windows.Forms.Panel();
            this.cbKindPlayer4 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNamePlayer4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOkNamesKinds = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numOfPlayers)).BeginInit();
            this.pnlplayer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlplayer3.SuspendLayout();
            this.pnlplayer2.SuspendLayout();
            this.pnlplayer4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Agency FB", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(93, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "ברוך הבא למשחק הרמי";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numOfPlayers
            // 
            this.numOfPlayers.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.numOfPlayers.Location = new System.Drawing.Point(150, 28);
            this.numOfPlayers.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numOfPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numOfPlayers.Name = "numOfPlayers";
            this.numOfPlayers.Size = new System.Drawing.Size(65, 20);
            this.numOfPlayers.TabIndex = 3;
            this.numOfPlayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOfPlayers.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numOfPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnOkNumOfPlayers
            // 
            this.btnOkNumOfPlayers.Location = new System.Drawing.Point(57, 28);
            this.btnOkNumOfPlayers.Name = "btnOkNumOfPlayers";
            this.btnOkNumOfPlayers.Size = new System.Drawing.Size(58, 23);
            this.btnOkNumOfPlayers.TabIndex = 4;
            this.btnOkNumOfPlayers.Text = "אישור";
            this.btnOkNumOfPlayers.UseVisualStyleBackColor = true;
            this.btnOkNumOfPlayers.Click += new System.EventHandler(this.btnOkNumOfPlayers_Click);
            // 
            // pnlplayer1
            // 
            this.pnlplayer1.Controls.Add(this.cbKindPlayer1);
            this.pnlplayer1.Controls.Add(this.label7);
            this.pnlplayer1.Controls.Add(this.txtNamePlayer1);
            this.pnlplayer1.Controls.Add(this.label3);
            this.pnlplayer1.Location = new System.Drawing.Point(44, 176);
            this.pnlplayer1.Name = "pnlplayer1";
            this.pnlplayer1.Size = new System.Drawing.Size(329, 33);
            this.pnlplayer1.TabIndex = 5;
            this.pnlplayer1.Visible = false;
            // 
            // cbKindPlayer1
            // 
            this.cbKindPlayer1.FormattingEnabled = true;
            this.cbKindPlayer1.Items.AddRange(new object[] {
            "מחשב",
            "שחקן"});
            this.cbKindPlayer1.Location = new System.Drawing.Point(11, 6);
            this.cbKindPlayer1.Name = "cbKindPlayer1";
            this.cbKindPlayer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbKindPlayer1.Size = new System.Drawing.Size(66, 21);
            this.cbKindPlayer1.TabIndex = 3;
            this.cbKindPlayer1.Text = "שחקן";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(83, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = ":סוג שחקן";
            // 
            // txtNamePlayer1
            // 
            this.txtNamePlayer1.Enabled = false;
            this.txtNamePlayer1.Location = new System.Drawing.Point(158, 7);
            this.txtNamePlayer1.Name = "txtNamePlayer1";
            this.txtNamePlayer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNamePlayer1.Size = new System.Drawing.Size(102, 20);
            this.txtNamePlayer1.TabIndex = 1;
            this.txtNamePlayer1.Tag = "אני";
            this.txtNamePlayer1.Text = "אני";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = ":שם שחקן 1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.משחקToolStripMenuItem,
            this.עזרהToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(408, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // משחקToolStripMenuItem
            // 
            this.משחקToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.חדשToolStripMenuItem,
            this.פתחמשחקשמורToolStripMenuItem,
            this.יציאהToolStripMenuItem,
            this.יציאהToolStripMenuItem1});
            this.משחקToolStripMenuItem.Name = "משחקToolStripMenuItem";
            this.משחקToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.משחקToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.משחקToolStripMenuItem.Text = "משחק";
            // 
            // חדשToolStripMenuItem
            // 
            this.חדשToolStripMenuItem.Name = "חדשToolStripMenuItem";
            this.חדשToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.חדשToolStripMenuItem.Text = "משחק חדש";
            this.חדשToolStripMenuItem.Click += new System.EventHandler(this.חדשToolStripMenuItem_Click);
            // 
            // פתחמשחקשמורToolStripMenuItem
            // 
            this.פתחמשחקשמורToolStripMenuItem.Name = "פתחמשחקשמורToolStripMenuItem";
            this.פתחמשחקשמורToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.פתחמשחקשמורToolStripMenuItem.Text = "פתח משחק שמור";
            // 
            // יציאהToolStripMenuItem
            // 
            this.יציאהToolStripMenuItem.Name = "יציאהToolStripMenuItem";
            this.יציאהToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.יציאהToolStripMenuItem.Text = "סטטיסטיקה";
            // 
            // יציאהToolStripMenuItem1
            // 
            this.יציאהToolStripMenuItem1.Name = "יציאהToolStripMenuItem1";
            this.יציאהToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.יציאהToolStripMenuItem1.Text = "יציאה";
            this.יציאהToolStripMenuItem1.Click += new System.EventHandler(this.יציאהToolStripMenuItem1_Click);
            // 
            // עזרהToolStripMenuItem
            // 
            this.עזרהToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.אודותToolStripMenuItem,
            this.כלליהמשחקToolStripMenuItem});
            this.עזרהToolStripMenuItem.Name = "עזרהToolStripMenuItem";
            this.עזרהToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.עזרהToolStripMenuItem.Text = "עזרה";
            // 
            // אודותToolStripMenuItem
            // 
            this.אודותToolStripMenuItem.Name = "אודותToolStripMenuItem";
            this.אודותToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.אודותToolStripMenuItem.Text = "RemmyCub אודות";
            this.אודותToolStripMenuItem.Click += new System.EventHandler(this.אודותToolStripMenuItem_Click);
            // 
            // כלליהמשחקToolStripMenuItem
            // 
            this.כלליהמשחקToolStripMenuItem.Name = "כלליהמשחקToolStripMenuItem";
            this.כלליהמשחקToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.כלליהמשחקToolStripMenuItem.Text = "כללי המשחק";
            // 
            // pnlplayer3
            // 
            this.pnlplayer3.Controls.Add(this.cbKindPlayer3);
            this.pnlplayer3.Controls.Add(this.label4);
            this.pnlplayer3.Controls.Add(this.txtNamePlayer3);
            this.pnlplayer3.Controls.Add(this.label5);
            this.pnlplayer3.Location = new System.Drawing.Point(44, 258);
            this.pnlplayer3.Name = "pnlplayer3";
            this.pnlplayer3.Size = new System.Drawing.Size(329, 33);
            this.pnlplayer3.TabIndex = 5;
            this.pnlplayer3.Visible = false;
            // 
            // cbKindPlayer3
            // 
            this.cbKindPlayer3.FormattingEnabled = true;
            this.cbKindPlayer3.Items.AddRange(new object[] {
            "מחשב",
            "שחקן"});
            this.cbKindPlayer3.Location = new System.Drawing.Point(11, 6);
            this.cbKindPlayer3.Name = "cbKindPlayer3";
            this.cbKindPlayer3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbKindPlayer3.Size = new System.Drawing.Size(66, 21);
            this.cbKindPlayer3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = ":סוג שחקן";
            // 
            // txtNamePlayer3
            // 
            this.txtNamePlayer3.Location = new System.Drawing.Point(158, 7);
            this.txtNamePlayer3.Name = "txtNamePlayer3";
            this.txtNamePlayer3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNamePlayer3.Size = new System.Drawing.Size(102, 20);
            this.txtNamePlayer3.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = ":שם שחקן 3";
            // 
            // pnlplayer2
            // 
            this.pnlplayer2.Controls.Add(this.cbKindPlayer2);
            this.pnlplayer2.Controls.Add(this.label6);
            this.pnlplayer2.Controls.Add(this.txtNamePlayer2);
            this.pnlplayer2.Controls.Add(this.label8);
            this.pnlplayer2.Location = new System.Drawing.Point(44, 217);
            this.pnlplayer2.Name = "pnlplayer2";
            this.pnlplayer2.Size = new System.Drawing.Size(329, 33);
            this.pnlplayer2.TabIndex = 5;
            this.pnlplayer2.Visible = false;
            // 
            // cbKindPlayer2
            // 
            this.cbKindPlayer2.FormattingEnabled = true;
            this.cbKindPlayer2.Items.AddRange(new object[] {
            "מחשב",
            "שחקן"});
            this.cbKindPlayer2.Location = new System.Drawing.Point(11, 6);
            this.cbKindPlayer2.Name = "cbKindPlayer2";
            this.cbKindPlayer2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbKindPlayer2.Size = new System.Drawing.Size(66, 21);
            this.cbKindPlayer2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = ":סוג שחקן";
            // 
            // txtNamePlayer2
            // 
            this.txtNamePlayer2.Location = new System.Drawing.Point(158, 7);
            this.txtNamePlayer2.Name = "txtNamePlayer2";
            this.txtNamePlayer2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNamePlayer2.Size = new System.Drawing.Size(102, 20);
            this.txtNamePlayer2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = ":שם שחקן 2";
            // 
            // pnlplayer4
            // 
            this.pnlplayer4.Controls.Add(this.cbKindPlayer4);
            this.pnlplayer4.Controls.Add(this.label9);
            this.pnlplayer4.Controls.Add(this.txtNamePlayer4);
            this.pnlplayer4.Controls.Add(this.label10);
            this.pnlplayer4.Location = new System.Drawing.Point(44, 299);
            this.pnlplayer4.Name = "pnlplayer4";
            this.pnlplayer4.Size = new System.Drawing.Size(329, 33);
            this.pnlplayer4.TabIndex = 5;
            this.pnlplayer4.Visible = false;
            // 
            // cbKindPlayer4
            // 
            this.cbKindPlayer4.FormattingEnabled = true;
            this.cbKindPlayer4.Items.AddRange(new object[] {
            "מחשב",
            "שחקן"});
            this.cbKindPlayer4.Location = new System.Drawing.Point(11, 6);
            this.cbKindPlayer4.Name = "cbKindPlayer4";
            this.cbKindPlayer4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbKindPlayer4.Size = new System.Drawing.Size(66, 21);
            this.cbKindPlayer4.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(83, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = ":סוג שחקן";
            // 
            // txtNamePlayer4
            // 
            this.txtNamePlayer4.Location = new System.Drawing.Point(158, 7);
            this.txtNamePlayer4.Name = "txtNamePlayer4";
            this.txtNamePlayer4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNamePlayer4.Size = new System.Drawing.Size(102, 20);
            this.txtNamePlayer4.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = ":שם שחקן 4";
            // 
            // btnOkNamesKinds
            // 
            this.btnOkNamesKinds.Location = new System.Drawing.Point(161, 364);
            this.btnOkNamesKinds.Name = "btnOkNamesKinds";
            this.btnOkNamesKinds.Size = new System.Drawing.Size(75, 23);
            this.btnOkNamesKinds.TabIndex = 8;
            this.btnOkNamesKinds.Text = "אישור";
            this.btnOkNamesKinds.UseVisualStyleBackColor = true;
            this.btnOkNamesKinds.Visible = false;
            this.btnOkNamesKinds.Click += new System.EventHandler(this.btnOkNamesKinds_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numOfPlayers);
            this.groupBox1.Controls.Add(this.btnOkNumOfPlayers);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.Location = new System.Drawing.Point(72, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(262, 65);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "מספר שחקנים";
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox2.Location = new System.Drawing.Point(17, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(371, 191);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "מאפייני שחקנים";
            this.groupBox2.Visible = false;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnOkNumOfPlayers;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(408, 399);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOkNamesKinds);
            this.Controls.Add(this.pnlplayer2);
            this.Controls.Add(this.pnlplayer4);
            this.Controls.Add(this.pnlplayer3);
            this.Controls.Add(this.pnlplayer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numOfPlayers)).EndInit();
            this.pnlplayer1.ResumeLayout(false);
            this.pnlplayer1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlplayer3.ResumeLayout(false);
            this.pnlplayer3.PerformLayout();
            this.pnlplayer2.ResumeLayout(false);
            this.pnlplayer2.PerformLayout();
            this.pnlplayer4.ResumeLayout(false);
            this.pnlplayer4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numOfPlayers;
        private System.Windows.Forms.Button btnOkNumOfPlayers;
        private System.Windows.Forms.Panel pnlplayer1;
        private System.Windows.Forms.TextBox txtNamePlayer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem משחקToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem חדשToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem פתחמשחקשמורToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem יציאהToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbKindPlayer1;
        private System.Windows.Forms.Panel pnlplayer3;
        private System.Windows.Forms.ComboBox cbKindPlayer3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNamePlayer3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlplayer2;
        private System.Windows.Forms.ComboBox cbKindPlayer2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNamePlayer2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlplayer4;
        private System.Windows.Forms.ComboBox cbKindPlayer4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNamePlayer4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOkNamesKinds;
        private System.Windows.Forms.ToolStripMenuItem יציאהToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem עזרהToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem אודותToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem כלליהמשחקToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;




    }
}

