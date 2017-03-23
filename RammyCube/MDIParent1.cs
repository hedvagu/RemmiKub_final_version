using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft;
using Word = Microsoft.Office.Interop.Word;

namespace RammyCube
{
    public partial class MDIParent1 : Form
    {
        public int childFormNumber = 0;
        public bool isOpenSaveGame = false;
        public bool isOpenNewGame = false;
        public bool isExitGame = false;
        public string userName;
        public bool isNetworkGame = false; 
        public string pathFileNetwork;
        public MDIParent1()
        {
            InitializeComponent();
            Form wellcome = new FormWellcome(this);
            wellcome.MdiParent = this;
            wellcome.Show();
            childFormNumber++;
            //Form openf = new FormOpen(this);
            //openf.MdiParent = this;
            //openf.Show();
            
        }
        

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }
       
        private void יציאהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isExitGame = true;
            if (ActiveMdiChild != null && ActiveMdiChild.Name == "FormGame")
            {
                if (!isNetworkGame)
                //{
                   
                //    FormGame fg;
                //    fg = (FormGame)ActiveMdiChild;
                //   // fg.writeFinishedToFile();

                //}
                //else
                {
                    Form fs = new FormSaveGame(ActiveMdiChild);
                    fs.Controls[1].Visible = true;//btnCancelSve
                    fs.Show();
                    //ActiveMdiChild.Close();
                    //Form fa = new FormAttributes(this);
                    //fa.MdiParent = this;                
                    //fa.Show();         
                }
                   
            }
            else
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                MessageBox.Show("       ....להתראות", "רמי");
                Application.Exit();
            }
        }

        private void אודותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //File.OpenFile "C:\My Projects\project1\Test1.css" /e:"Source Code (text) Editor"

            AboutBox1 ab = new AboutBox1();
            ab.Show();

        }

        private void משחקחדשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            isOpenSaveGame = false;
            isOpenNewGame = true;
            if (ActiveMdiChild!=null && ActiveMdiChild.Name == "FormAttributes")
            {
               
                //להעתיק את כל הקטע הזה         
                ActiveMdiChild.Controls[8].Visible = true;//label1
                ActiveMdiChild.Controls[2].Enabled = true;//groupBox1
                ActiveMdiChild.Controls[9].Visible = false;//groupBox2
                ActiveMdiChild.Controls[0].Visible = false;//groupBox3
                ActiveMdiChild.Controls[3].Visible = false;//pnlplayer1
                ActiveMdiChild.Controls[4].Visible = false;//pnlplayer2
                ActiveMdiChild.Controls[5].Visible = false;//pnlplayer4
                ActiveMdiChild.Controls[6].Visible = false;//pnlplayer3
                ActiveMdiChild.Controls[7].Visible = false;//btnOkNamesKinds
            }
            else if (ActiveMdiChild != null && ActiveMdiChild.Name == "FormGame")
            {
                if (!isNetworkGame)
                {
                    Form fs = new FormSaveGame(ActiveMdiChild);
                    fs.Show();
                }
                else
                    ActiveMdiChild.Close();
            }
            else if (ActiveMdiChild == null)
            {
                Form fw = new FormWellcome(this);
                fw.MdiParent = this;
                fw.Show();      
            }
        }

        private void שמורמשחקToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild.Name == "FormGame")
            {
                Form fs = new FormSaveGame(ActiveMdiChild);
                fs.Show();
            }
        }

        private void פתיחתמשחקשמורToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isOpenSaveGame = true;
            FormAttributes fa;
            if (ActiveMdiChild != null && ActiveMdiChild.Name == "FormAttributes") 
            {
                fa = (FormAttributes)ActiveMdiChild;
                fa.LoadProperties();
            }
            else if (ActiveMdiChild == null)//TODO: לחזור לכאן בשביל לפתוח את החלון בפתיחת שמור
            {
                fa = new FormAttributes(this);
                fa.MdiParent = this;
                fa.LoadProperties();
                fa.Show();
            }

            
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {

        }

        private void מדריךלמשתמשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object fileName = Application.StartupPath + "\\help.htm";
            object missing = System.Reflection.Missing.Value;
            Word.Application oWord = new Word.Application();
            Word.Document oWordDoc = new Word.Document();
            oWord.Visible = true;
            oWordDoc = oWord.Documents.Add(ref fileName, ref missing, ref missing, ref missing);
            oWordDoc.Activate();


        }

     
    }
}
