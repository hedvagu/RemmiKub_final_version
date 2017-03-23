namespace RammyCube
{
    partial class FormAttributes
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numOfPlayers = new System.Windows.Forms.NumericUpDown();
            this.btnOkNumOfPlayers = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlradio = new System.Windows.Forms.Panel();
            this.rbJoiner = new System.Windows.Forms.RadioButton();
            this.rbNew = new System.Windows.Forms.RadioButton();
            this.rbNetwork = new System.Windows.Forms.RadioButton();
            this.rbComputer = new System.Windows.Forms.RadioButton();
            this.pnlplayer1 = new System.Windows.Forms.Panel();
            this.cbKindPlayer1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNamePlayer1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlplayer2 = new System.Windows.Forms.Panel();
            this.cbJoinersNames = new System.Windows.Forms.ComboBox();
            this.cbKindPlayer2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNamePlayer2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlplayer4 = new System.Windows.Forms.Panel();
            this.cbKindPlayer4 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNamePlayer4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlplayer3 = new System.Windows.Forms.Panel();
            this.cbKindPlayer3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNamePlayer3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOkNamesKinds = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOfPlayers)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.pnlradio.SuspendLayout();
            this.pnlplayer1.SuspendLayout();
            this.pnlplayer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlplayer4.SuspendLayout();
            this.pnlplayer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(101, 538);
            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(371, 20);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Agency FB", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(171, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Attributes Game";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.numOfPlayers);
            this.groupBox1.Controls.Add(this.btnOkNumOfPlayers);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(147, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(291, 65);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "number of players";
            // 
            // numOfPlayers
            // 
            this.numOfPlayers.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.numOfPlayers.Location = new System.Drawing.Point(150, 27);
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
            this.numOfPlayers.Size = new System.Drawing.Size(65, 23);
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
            this.btnOkNumOfPlayers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNumOfPlayers.Location = new System.Drawing.Point(37, 27);
            this.btnOkNumOfPlayers.Name = "btnOkNumOfPlayers";
            this.btnOkNumOfPlayers.Size = new System.Drawing.Size(58, 23);
            this.btnOkNumOfPlayers.TabIndex = 4;
            this.btnOkNumOfPlayers.Text = "o.k";
            this.btnOkNumOfPlayers.UseVisualStyleBackColor = true;
            this.btnOkNumOfPlayers.Click += new System.EventHandler(this.btnOkNumOfPlayers_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.pnlradio);
            this.groupBox3.Controls.Add(this.rbNetwork);
            this.groupBox3.Controls.Add(this.rbComputer);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox3.Location = new System.Drawing.Point(117, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(350, 72);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "kind of game";
            this.groupBox3.Visible = false;
            // 
            // pnlradio
            // 
            this.pnlradio.Controls.Add(this.rbJoiner);
            this.pnlradio.Controls.Add(this.rbNew);
            this.pnlradio.Location = new System.Drawing.Point(1, 11);
            this.pnlradio.Name = "pnlradio";
            this.pnlradio.Size = new System.Drawing.Size(80, 55);
            this.pnlradio.TabIndex = 4;
            // 
            // rbJoiner
            // 
            this.rbJoiner.AutoSize = true;
            this.rbJoiner.Location = new System.Drawing.Point(12, 32);
            this.rbJoiner.Name = "rbJoiner";
            this.rbJoiner.Size = new System.Drawing.Size(61, 21);
            this.rbJoiner.TabIndex = 5;
            this.rbJoiner.TabStop = true;
            this.rbJoiner.Text = "joiner";
            this.rbJoiner.UseVisualStyleBackColor = true;
            this.rbJoiner.Visible = false;
            this.rbJoiner.CheckedChanged += new System.EventHandler(this.rbJoiner_CheckedChanged);
            // 
            // rbNew
            // 
            this.rbNew.AutoSize = true;
            this.rbNew.Location = new System.Drawing.Point(27, 5);
            this.rbNew.Name = "rbNew";
            this.rbNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbNew.Size = new System.Drawing.Size(51, 21);
            this.rbNew.TabIndex = 4;
            this.rbNew.TabStop = true;
            this.rbNew.Text = "new";
            this.rbNew.UseVisualStyleBackColor = true;
            this.rbNew.Visible = false;
            this.rbNew.CheckedChanged += new System.EventHandler(this.rbNew_CheckedChanged);
            // 
            // rbNetwork
            // 
            this.rbNetwork.AutoSize = true;
            this.rbNetwork.Location = new System.Drawing.Point(78, 30);
            this.rbNetwork.Name = "rbNetwork";
            this.rbNetwork.Size = new System.Drawing.Size(114, 21);
            this.rbNetwork.TabIndex = 1;
            this.rbNetwork.TabStop = true;
            this.rbNetwork.Text = "network game";
            this.rbNetwork.UseVisualStyleBackColor = true;
            this.rbNetwork.CheckedChanged += new System.EventHandler(this.rbNetwork_CheckedChanged);
            // 
            // rbComputer
            // 
            this.rbComputer.AutoSize = true;
            this.rbComputer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rbComputer.Location = new System.Drawing.Point(190, 30);
            this.rbComputer.Name = "rbComputer";
            this.rbComputer.Size = new System.Drawing.Size(156, 19);
            this.rbComputer.TabIndex = 0;
            this.rbComputer.TabStop = true;
            this.rbComputer.Text = "player against computer";
            this.rbComputer.UseVisualStyleBackColor = true;
            this.rbComputer.CheckedChanged += new System.EventHandler(this.rbComputer_CheckedChanged);
            // 
            // pnlplayer1
            // 
            this.pnlplayer1.BackColor = System.Drawing.Color.Transparent;
            this.pnlplayer1.Controls.Add(this.cbKindPlayer1);
            this.pnlplayer1.Controls.Add(this.label7);
            this.pnlplayer1.Controls.Add(this.txtNamePlayer1);
            this.pnlplayer1.Controls.Add(this.label3);
            this.pnlplayer1.Location = new System.Drawing.Point(124, 252);
            this.pnlplayer1.Name = "pnlplayer1";
            this.pnlplayer1.Size = new System.Drawing.Size(350, 33);
            this.pnlplayer1.TabIndex = 16;
            this.pnlplayer1.Visible = false;
            // 
            // cbKindPlayer1
            // 
            this.cbKindPlayer1.Enabled = false;
            this.cbKindPlayer1.FormattingEnabled = true;
            this.cbKindPlayer1.Items.AddRange(new object[] {
            "computer",
            "player"});
            this.cbKindPlayer1.Location = new System.Drawing.Point(11, 6);
            this.cbKindPlayer1.Name = "cbKindPlayer1";
            this.cbKindPlayer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbKindPlayer1.Size = new System.Drawing.Size(66, 21);
            this.cbKindPlayer1.TabIndex = 3;
            this.cbKindPlayer1.Text = "player";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(83, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "kind of player";
            // 
            // txtNamePlayer1
            // 
            this.txtNamePlayer1.Enabled = false;
            this.txtNamePlayer1.Location = new System.Drawing.Point(181, 7);
            this.txtNamePlayer1.Name = "txtNamePlayer1";
            this.txtNamePlayer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNamePlayer1.Size = new System.Drawing.Size(102, 20);
            this.txtNamePlayer1.TabIndex = 1;
            this.txtNamePlayer1.Tag = "user";
            this.txtNamePlayer1.Text = "user";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(284, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "player 1";
            // 
            // pnlplayer2
            // 
            this.pnlplayer2.BackColor = System.Drawing.Color.Transparent;
            this.pnlplayer2.Controls.Add(this.cbJoinersNames);
            this.pnlplayer2.Controls.Add(this.cbKindPlayer2);
            this.pnlplayer2.Controls.Add(this.label6);
            this.pnlplayer2.Controls.Add(this.txtNamePlayer2);
            this.pnlplayer2.Controls.Add(this.label8);
            this.pnlplayer2.Location = new System.Drawing.Point(124, 293);
            this.pnlplayer2.Name = "pnlplayer2";
            this.pnlplayer2.Size = new System.Drawing.Size(350, 33);
            this.pnlplayer2.TabIndex = 15;
            this.pnlplayer2.Visible = false;
            // 
            // cbJoinersNames
            // 
            this.cbJoinersNames.FormattingEnabled = true;
            this.cbJoinersNames.Location = new System.Drawing.Point(181, 7);
            this.cbJoinersNames.Name = "cbJoinersNames";
            this.cbJoinersNames.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbJoinersNames.Size = new System.Drawing.Size(102, 21);
            this.cbJoinersNames.TabIndex = 4;
            this.cbJoinersNames.Visible = false;
            // 
            // cbKindPlayer2
            // 
            this.cbKindPlayer2.FormattingEnabled = true;
            this.cbKindPlayer2.Items.AddRange(new object[] {
            "computer",
            "player"});
            this.cbKindPlayer2.Location = new System.Drawing.Point(11, 6);
            this.cbKindPlayer2.Name = "cbKindPlayer2";
            this.cbKindPlayer2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbKindPlayer2.Size = new System.Drawing.Size(66, 21);
            this.cbKindPlayer2.TabIndex = 3;
            this.cbKindPlayer2.SelectedValueChanged += new System.EventHandler(this.cbKindPlayer2_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(83, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "kind of player";
            // 
            // txtNamePlayer2
            // 
            this.txtNamePlayer2.Location = new System.Drawing.Point(181, 7);
            this.txtNamePlayer2.Name = "txtNamePlayer2";
            this.txtNamePlayer2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNamePlayer2.Size = new System.Drawing.Size(102, 20);
            this.txtNamePlayer2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(285, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "player 2";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.pnlplayer4);
            this.groupBox2.Controls.Add(this.pnlplayer3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(97, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(390, 191);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attributes players";
            this.groupBox2.Visible = false;
            // 
            // pnlplayer4
            // 
            this.pnlplayer4.BackColor = System.Drawing.Color.Transparent;
            this.pnlplayer4.Controls.Add(this.cbKindPlayer4);
            this.pnlplayer4.Controls.Add(this.label9);
            this.pnlplayer4.Controls.Add(this.txtNamePlayer4);
            this.pnlplayer4.Controls.Add(this.label10);
            this.pnlplayer4.Location = new System.Drawing.Point(26, 148);
            this.pnlplayer4.Name = "pnlplayer4";
            this.pnlplayer4.Size = new System.Drawing.Size(350, 33);
            this.pnlplayer4.TabIndex = 7;
            this.pnlplayer4.Visible = false;
            // 
            // cbKindPlayer4
            // 
            this.cbKindPlayer4.FormattingEnabled = true;
            this.cbKindPlayer4.Items.AddRange(new object[] {
            "computer",
            "player"});
            this.cbKindPlayer4.Location = new System.Drawing.Point(11, 6);
            this.cbKindPlayer4.Name = "cbKindPlayer4";
            this.cbKindPlayer4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbKindPlayer4.Size = new System.Drawing.Size(66, 24);
            this.cbKindPlayer4.TabIndex = 3;
            this.cbKindPlayer4.SelectedValueChanged += new System.EventHandler(this.cbKindPlayer2_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(83, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "kind of player";
            // 
            // txtNamePlayer4
            // 
            this.txtNamePlayer4.Location = new System.Drawing.Point(185, 7);
            this.txtNamePlayer4.Name = "txtNamePlayer4";
            this.txtNamePlayer4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNamePlayer4.Size = new System.Drawing.Size(102, 23);
            this.txtNamePlayer4.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(287, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "player 4";
            // 
            // pnlplayer3
            // 
            this.pnlplayer3.BackColor = System.Drawing.Color.Transparent;
            this.pnlplayer3.Controls.Add(this.cbKindPlayer3);
            this.pnlplayer3.Controls.Add(this.label4);
            this.pnlplayer3.Controls.Add(this.txtNamePlayer3);
            this.pnlplayer3.Controls.Add(this.label5);
            this.pnlplayer3.Location = new System.Drawing.Point(26, 107);
            this.pnlplayer3.Name = "pnlplayer3";
            this.pnlplayer3.Size = new System.Drawing.Size(350, 33);
            this.pnlplayer3.TabIndex = 6;
            this.pnlplayer3.Visible = false;
            // 
            // cbKindPlayer3
            // 
            this.cbKindPlayer3.FormattingEnabled = true;
            this.cbKindPlayer3.Items.AddRange(new object[] {
            "computer",
            "player"});
            this.cbKindPlayer3.Location = new System.Drawing.Point(11, 6);
            this.cbKindPlayer3.Name = "cbKindPlayer3";
            this.cbKindPlayer3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbKindPlayer3.Size = new System.Drawing.Size(66, 24);
            this.cbKindPlayer3.TabIndex = 3;
            this.cbKindPlayer3.SelectedValueChanged += new System.EventHandler(this.cbKindPlayer2_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(83, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "kind of player";
            // 
            // txtNamePlayer3
            // 
            this.txtNamePlayer3.Location = new System.Drawing.Point(183, 7);
            this.txtNamePlayer3.Name = "txtNamePlayer3";
            this.txtNamePlayer3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNamePlayer3.Size = new System.Drawing.Size(102, 23);
            this.txtNamePlayer3.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(286, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "player 3";
            // 
            // btnOkNamesKinds
            // 
            this.btnOkNamesKinds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnOkNamesKinds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOkNamesKinds.Location = new System.Drawing.Point(255, 451);
            this.btnOkNamesKinds.Name = "btnOkNamesKinds";
            this.btnOkNamesKinds.Size = new System.Drawing.Size(75, 23);
            this.btnOkNamesKinds.TabIndex = 18;
            this.btnOkNamesKinds.Text = "o.k";
            this.btnOkNamesKinds.UseVisualStyleBackColor = true;
            this.btnOkNamesKinds.Visible = false;
            this.btnOkNamesKinds.Click += new System.EventHandler(this.btnOkNamesKinds_Click);
            // 
            // FormAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImage = global::RammyCube.Properties.Resources.KlaliBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.btnOkNamesKinds);
            this.Controls.Add(this.pnlplayer1);
            this.Controls.Add(this.pnlplayer2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "FormAttributes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attributes Game";
            this.Load += new System.EventHandler(this.FormAttributes_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numOfPlayers)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnlradio.ResumeLayout(false);
            this.pnlradio.PerformLayout();
            this.pnlplayer1.ResumeLayout(false);
            this.pnlplayer1.PerformLayout();
            this.pnlplayer2.ResumeLayout(false);
            this.pnlplayer2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.pnlplayer4.ResumeLayout(false);
            this.pnlplayer4.PerformLayout();
            this.pnlplayer3.ResumeLayout(false);
            this.pnlplayer3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numOfPlayers;
        private System.Windows.Forms.Button btnOkNumOfPlayers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pnlradio;
        private System.Windows.Forms.RadioButton rbJoiner;
        private System.Windows.Forms.RadioButton rbNew;
        private System.Windows.Forms.RadioButton rbNetwork;
        private System.Windows.Forms.RadioButton rbComputer;
        private System.Windows.Forms.Panel pnlplayer1;
        private System.Windows.Forms.ComboBox cbKindPlayer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNamePlayer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlplayer2;
        private System.Windows.Forms.ComboBox cbJoinersNames;
        private System.Windows.Forms.ComboBox cbKindPlayer2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNamePlayer2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlplayer4;
        private System.Windows.Forms.ComboBox cbKindPlayer4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNamePlayer4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlplayer3;
        private System.Windows.Forms.ComboBox cbKindPlayer3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNamePlayer3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOkNamesKinds;




    }
}

