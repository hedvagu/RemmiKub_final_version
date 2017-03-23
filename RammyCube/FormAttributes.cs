using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data ;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using System.Xml.Linq;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace RammyCube
{
    public partial class FormAttributes : Form
    {
       
        MDIParent1 mainForm;
        public List<string> names = new List<string>();
        public List<bool> kinds = new List<bool>();
        public BL.ucPlayerBoard ucp = new BL.ucPlayerBoard();
        public ucGame ucg;
        Audio a = new Audio();//@@ TODO: להוציא מהערה כשמעתיקים
        public string path;//@@
        public StreamReader stRead;//@@
        public StreamWriter stWrite;//@@
        public bool networkGame = false; //@@
        public string nameplay2; //@@
        public string join = "Dina";

        public FormAttributes(MDIParent1 mdi)
        {
            InitializeComponent();
            mainForm = mdi;
           
            // במקרה שנפתח במצב של פתיחת משחק שמור יש לטעון את שמות השחקנים ומאפייניהם
            if (mainForm.isOpenSaveGame)
            {
                LoadProperties();
            }
            else
                txtNamePlayer1.Text = mainForm.userName;

        }

      

        private void btnOkNumOfPlayers_Click(object sender, EventArgs e)
        {
            this.AcceptButton = btnOkNamesKinds;
            groupBox1.Enabled = false;
            groupBox3.Visible = true;

            rbComputer.Checked = true;
            
            btnOkNamesKinds.Visible = true;
            pnlplayer1.Visible = true;

            pnlplayer2.Visible = true;
            txtNamePlayer2.Text = "computer";
            cbKindPlayer2.Text = "computer";
            

            if (numOfPlayers.Value > 2)
                pnlplayer3.Visible = true;
            if (numOfPlayers.Value > 3)
                pnlplayer4.Visible = true;
            groupBox2.Visible = true;

        }


        private void btnOkNamesKinds_Click(object sender, EventArgs e)
        {
            if (rbNetwork.Checked == true)
            {
                if (rbNew.Checked == true)
                {
                    int drive = Microsoft.VisualBasic.FileIO.FileSystem.Drives.Count;
                    int i;
                    for (i = 0; i < drive; i++)
                    {
                        if (Microsoft.VisualBasic.FileIO.FileSystem.Drives[i].DriveType == DriveType.Removable)
                        {
                            path = Microsoft.VisualBasic.FileIO.FileSystem.Drives[i].Name;
                            break;
                        }
                    }
                    stWrite = File.CreateText( txtNamePlayer1.Text + ".rom");
                    stWrite.WriteLine("1");
                    stWrite.WriteLine(txtNamePlayer1.Text);
                    stWrite.Close();
                    timer1.Start();
                    MessageBox.Show("wait for joiner", "Rammy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    progressBar1.Visible = true;
                }
                else if (rbJoiner.Checked == true)
                {
                    if (cbJoinersNames.Text == "")
                    {
                        MessageBox.Show("fill name of player", "Rammi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        cbJoinersNames.Focus();
                    }
                    else
                    {
                        InitializNamesAttrib();
                        //stWrite = File.CreateText(path + txtNamePlayer1.Text + ".rom");
                        stWrite = File.CreateText(path + cbJoinersNames.Text + ".rom");
                        stWrite.WriteLine("2");
                        //stWrite.WriteLine(cbJoinersNames.Text);
                        stWrite.WriteLine(txtNamePlayer1.Text);
                        stWrite.Close();
                        timer2.Start();
                        MessageBox.Show("wait for ok that someone join for you", "Rammi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        progressBar1.Visible = true;
                    }
                }
            }
            else
            {
               

                //חיבים לוודא שכל השדות מולאו
                try
                {
                    //@@ TODO: להוציא מהערה כשמעתיקים
                    a.Play(RammyCube.Properties.Resources.chimes, Microsoft.VisualBasic.AudioPlayMode.Background);   
                    InitializNamesAttrib();

                    if (mainForm.isOpenSaveGame)
                        LoadUcGame();
                    else
                        ucg = new ucGame((int)numOfPlayers.Value, names, kinds, false,mainForm.userName);

                    FormGame fGame;
                    fGame = new FormGame(ucg, mainForm);
                    fGame.MdiParent = mainForm;
                    fGame.WindowState = FormWindowState.Maximized;
                    fGame.Show();
                    this.Close();
                   
                }

                catch (Exception ex)
                {
                    if (ex.GetType().Name == "NullReferenceException")
                        MessageBox.Show("you must fill the names and the kinds of players");
                }
            }
            
        }

        private void אודותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();

        }

        private void חדשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Visible = false;
            pnlplayer1.Visible = false;
            pnlplayer2.Visible = false;
            pnlplayer3.Visible = false;
            pnlplayer4.Visible = false;
            btnOkNamesKinds.Visible = false;
        }

        private void FormAttributes_Load(object sender, EventArgs e)
        {

            #region network//@@
            int drive = Microsoft.VisualBasic.FileIO.FileSystem.Drives.Count;
            int i;
            for (i = 0; i < drive; i++)
            {
                if (Microsoft.VisualBasic.FileIO.FileSystem.Drives[i].DriveType == DriveType.Removable)
                {
                    path = Microsoft.VisualBasic.FileIO.FileSystem.Drives[i].Name;
                    //break;
                }
            }
           DirectoryInfo dirs = new DirectoryInfo(path);
            FileInfo[] files = dirs.GetFiles("*.rom");
            foreach (FileInfo file in files)
            {
           string joinerName = file.Name.Remove(file.Name.Length - 4);
                cbJoinersNames.Items.Add(joinerName);
            }
            cbJoinersNames.Items.Add(join);
            #endregion

        }

        public void LoadProperties()
        {

            XDocument doc = XDocument.Load("SavedGame.xml");


            var prop = doc.Element("properties");
            // קודם כל העלמת כל הקונטרולים ואז הצגתם לפי הצורך
            groupBox3.Visible = false;
            pnlradio.Visible = false;
            groupBox2.Visible = false;
            pnlplayer1.Visible = false;
            pnlplayer2.Visible = false;
            pnlplayer3.Visible = false;
            pnlplayer4.Visible = false;
            btnOkNamesKinds.Visible = false;
            //שליפת מספר השחקנים
            numOfPlayers.Value = (decimal)prop.Attribute("numOfPlayers");
           
            // שליפת מאפייני השחקנים 
            txtNamePlayer1.Text = (string)prop.Element("player1").Attribute("name");
            cbKindPlayer1.Text = (bool)prop.Element("player1").Attribute("computer")? "computer":"player";

            txtNamePlayer2.Text = (string)prop.Element("player2").Attribute("name");
            cbKindPlayer2.Text = (bool)prop.Element("player2").Attribute("computer") ? "computer" : "player";

            if (cbKindPlayer2.Text == "computer")
            {
                groupBox3.Visible = true;
                rbComputer.Visible = true;
                rbComputer.Checked = true;

            }
            else
            {
                groupBox3.Visible = true;
                rbNetwork.Checked = true;
            }

            if (numOfPlayers.Value > 2)
            {
                txtNamePlayer3.Text = (string)prop.Element("player3").Attribute("name");
                cbKindPlayer3.Text = (bool)prop.Element("player3").Attribute("computer") ? "computer" : "player";
            }
            if (numOfPlayers.Value > 3)
            {
                txtNamePlayer4.Text = (string)prop.Element("player4").Attribute("name");
                cbKindPlayer4.Text = (bool)prop.Element("player4").Attribute("computer") ? "computer" : "player";
            }
            // הצגת מאפייני השחקנים
            groupBox1.Enabled = false;
            btnOkNamesKinds.Visible = true;
            pnlplayer1.Visible = true;
            pnlplayer2.Visible = true;
            
            
            if (numOfPlayers.Value > 2)
                pnlplayer3.Visible = true;
            if (numOfPlayers.Value > 3)
                pnlplayer4.Visible = true;
            groupBox2.Visible = true;
        }
         public void LoadUcGame()
        {
            ucg = new ucGame();
            try
            {
                eColor tmpec = new eColor();
                eStatus tmpes = new eStatus();
                string curName;
                bool curKind;
                List<ccCard> curCards = new List<ccCard> { };
                //InitializNamesAttrib();
                XDocument doc = XDocument.Load("SavedGame.xml");
                var prop = doc.Element("properties");
                //שליפת מספר השחקנים
                ucg.numOfPlayers = (int)prop.Attribute("numOfPlayers");
                // שליפת התור הנוכחי
                ucg.turn = (int)prop.Attribute("turn");
                ucg.playersBoards = new ucPlayerBoard[ucg.numOfPlayers];
                // שליפת מאפייני השחקנים ואבניהם
                for (int i = 0; i < ucg.numOfPlayers; i++)
                {
                    
                    curName = (string)prop.Element("player" + (i + 1)).Attribute("name");
                    curKind = (bool)prop.Element("player" + (i + 1)).Attribute("computer");
                    var curPlyr = prop.Element("player" + (i + 1));
                    //ריקון רשימת הקלפים של השחקן כדי לאתחלה לפי המשחק השמור
                    //ucg.playersBoards[i].listCards.Clear();
                    curCards.Clear();
                    for (int j = 0; j < (int)curPlyr.Attribute("cntCard"); j++)
                    {
                        int curNum = (int)curPlyr.Element("card" + (j + 1)).Attribute("number");
                        string curColor = (string)curPlyr.Element("card" + (j + 1)).Attribute("color");                        
                        tmpec = ucg.ToEColor(curColor);
                        curCards.Add(new ccCard((byte)curNum,tmpec));
                    }
                    ucg.playersBoards[i] = new ucPlayerBoard(curCards.ToList(), curName, curKind);
                }
                // שליפת אבני הקופה
                ucg.box.Clear();  //ריקון אבני הקופה כדי לאתחלה לפי המשחק השמור
                foreach (XElement crd in prop.Element("box").Elements())
                {
                    int curNum = (int)crd.Attribute("number");
                    string curColor = (string)crd.Attribute("color");
                    string stt = (string)crd.Attribute("status");
                    tmpec = ucg.ToEColor(curColor);
                    tmpes = ucg.ToEStatus(stt);
                    ucg.box.Add(new ccCard((byte)curNum, tmpec, tmpes));

                }

                // שליפת לוח המשחק
                if (ucg.mainBoard.Count > 0)
                    ucg.mainBoard.Clear(); //ריקון לוח המשחק כדי לאתחלה לפי המשחק השמור
                else
                    ucg.mainBoard = new List<List<ccCard>> { };
                foreach (XElement seria in prop.Element("mainBoard").Elements())
                {
                    List<ccCard> tmp = new List<ccCard> { };
                    int i = 0;
                    
                    foreach (XElement crd in seria.Elements())
                    {
                        int curNum = (int)crd.Attribute("number");
                        string curColor = (string)crd.Attribute("color");
                        string stt = (string)crd.Attribute("status");
                        tmpec = ucg.ToEColor(curColor);
                        tmpes = ucg.ToEStatus(stt);
                        tmp.Add(new ccCard((byte)curNum, tmpec, tmpes));
                    }
                    ucg.mainBoard.Add(tmp);
                    i++;
                }
                ucg.Show_Cards(ucg.turn);
              
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

         private void InitializNamesAttrib()
         {
             //אתחול רשימת השמות                    
             names.Add(txtNamePlayer1.Text);
             if (networkGame)
             {
                 if (rbNew.Checked)
                     names.Add(nameplay2);
                 if (rbJoiner.Checked)
                     names.Add(cbJoinersNames.Text);
             }
             else
                 names.Add(txtNamePlayer2.Text);

             if (numOfPlayers.Value > 2)
                 names.Add(txtNamePlayer3.Text);
             if (numOfPlayers.Value > 3)
                 names.Add(txtNamePlayer4.Text);

             //אתחול רשימת סוגי שחקנים
             if (networkGame)
             {
                 kinds.Add(false);
                 kinds.Add(false);
             }
             else
             {
                 kinds.Add(cbKindPlayer1.Text.ToString() == "computer" ? true : false);
                 kinds.Add(cbKindPlayer2.Text.ToString() == "computer" ? true : false);
                 if (numOfPlayers.Value > 2)
                     kinds.Add(cbKindPlayer3.Text.ToString() == "computer" ? true : false);
                 if (numOfPlayers.Value > 3)
                     kinds.Add(cbKindPlayer4.Text.ToString() == "computer" ? true : false);
             }
         }
            
        private void יציאהToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbKindPlayer2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbKindPlayer2.SelectedItem.ToString() == "player")
                mainForm.isNetworkGame = true;
        }

        private void rbComputer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbComputer.Checked)
            {
                mainForm.isNetworkGame = false;
                networkGame = false;
                rbNew.Visible = false;
                rbJoiner.Visible = false;
                pnlplayer1.Visible = true;

                pnlplayer2.Visible = true;
                txtNamePlayer2.Text = "computer";
                cbKindPlayer2.Text = "computer";
                cbKindPlayer2.Enabled = false;

            }
            

        }

        private void rbNetwork_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rbNetwork.Checked)
            {
              
                mainForm.isNetworkGame = true;
                networkGame = true;
                rbNew.Visible = true;
                rbJoiner.Visible = true;
                pnlplayer1.Visible = false;
                pnlplayer2.Visible = false;
                pnlplayer3.Visible = false;
                pnlplayer4.Visible = false;

            }

        }

        private void rbNew_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNew.Checked)
            {
                pnlplayer1.Visible = true;
                pnlplayer2.Visible = false;
            }

        }

        private void rbJoiner_CheckedChanged(object sender, EventArgs e)
        {
            if (rbJoiner.Checked)
            {
                pnlplayer1.Visible = true;
                pnlplayer2.Visible = true;
                txtNamePlayer2.Text = "";
                txtNamePlayer2.Visible = false;
                cbJoinersNames.Visible = true;
                cbKindPlayer2.Text = "player";
                cbKindPlayer2.Enabled = false;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                stRead = File.OpenText(path + txtNamePlayer1.Text + ".rom");
                string player = stRead.ReadLine();
                if (player == "2")
                {
                    nameplay2 = stRead.ReadLine();
                    stRead.Close();
                    File.Delete(path + txtNamePlayer1.Text + ".rom");
                    timer1.Stop();
                    MessageBox.Show("!" + nameplay2 + " join for you", "Rammi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //חיבים לוודא שכל השדות מולאו
                    try
                    {
                       
                        a.Play(RammyCube.Properties.Resources.chimes, Microsoft.VisualBasic.AudioPlayMode.Background);   
                        InitializNamesAttrib();                        
                        ucg = new ucGame((int)numOfPlayers.Value, names, kinds, networkGame,mainForm.userName);
                        FormGame fGame;
                        fGame = new FormGame(ucg, mainForm);
                        fGame.MdiParent = mainForm;
                        fGame.WindowState = FormWindowState.Maximized;
                        fGame.Show();
                        this.Close();
                    }

                    catch (Exception ex)
                    {
                        if (ex.GetType().Name == "NullReferenceException")
                            MessageBox.Show("!!חובה למלא את שמות וסוגי השחקנים");
                    }
                    
                }
                stRead.Close();
            }
            catch (Exception ex) { }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                
                //if (File.Exists(path + txtNamePlayer1.Text + cbJoinersNames.Text+".xml"))
                //if (File.Exists(path + txtNamePlayer1.Text + cbJoinersNames.Text + ".xml"))
                if (File.Exists(path + cbJoinersNames.Text + txtNamePlayer1.Text + ".xml"))
                {
                    // 10.6.2011- לקרוא לטעינת המשחק  מקובץ ה-XML ולשלוף ממנו
                    timer2.Stop();
                    File.Delete(path + cbJoinersNames.Text + ".rom");
                    //חיבים לוודא שכל השדות מולאו
                    try
                    {
                        a.Play(RammyCube.Properties.Resources.chimes, Microsoft.VisualBasic.AudioPlayMode.Background);   
                        //InitializNamesAttrib();
                        names.Reverse(0, 2);
                        ucg = new ucGame((int)numOfPlayers.Value, names, kinds, networkGame,mainForm.userName);
                        FormGame fGame;
                        fGame = new FormGame(ucg, mainForm);
                        fGame.MdiParent = mainForm;
                        fGame.WindowState = FormWindowState.Maximized;
                        fGame.Show();
                        this.Close();
                    }

                    catch (Exception ex)
                    {
                        if (ex.GetType().Name == "NullReferenceException")
                            MessageBox.Show("!!חובה למלא את שמות וסוגי השחקנים");
                    }
                    MessageBox.Show("Game start", "Rammi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //stRead.Close();
                    ucg.startPlayNetwork(ucg.turn);

                    
                }
                //stRead.Close();
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

       
    }
}
