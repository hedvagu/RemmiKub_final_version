using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data ;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;

namespace RammyCube
{
    public partial class Form1 : Form
    {
        public Form2 f2;
        public Form1()
        {
            InitializeComponent();
            this.Text = "מסך פתיחה";
            BL.ucPlayerBoard ucp = new BL.ucPlayerBoard();
            //ucp.Show();
            //ccCard c1 = new ccCard(1, eColor.Red);
            //ccCard c2 = new ccCard(8, eColor.Green);
            //int top = 0, left = 0;
            //ccCard c3 = new ccCard(5, eColor.Yellow);
            //c1.Top = top;
            //c1.Left = left;
            //c1.Width = 40;
            //c1.Height = 60;
            //left += c1.Width+1;
            //this.Controls.Add(c1);

            //c2.Top = top;
            //c2.Left = left;
            //c2.Width = 40;
            //c2.Height = 60;
            //left += c2.Width+1;
            //this.Controls.Add(c2);

            //c3.Top = top;
            //c3.Left = left;
            //c3.Width = 40;
            //c3.Height = 60;

            ////c3.Font.Size = 16;
            //left += c3.Width+1;
            //this.Controls.Add(ucp);
        }

        private void btnOkNumOfPlayers_Click(object sender, EventArgs e)
        {
            this.AcceptButton = btnOkNamesKinds;
            groupBox1.Enabled = false;
            btnOkNamesKinds.Visible = true;
            pnlplayer1.Visible = true;
            pnlplayer2.Visible = true;
            groupBox2.Visible = true;
            if (numOfPlayers.Value >2)
                pnlplayer3.Visible = true;
            if (numOfPlayers.Value > 3)
                pnlplayer4.Visible = true;

        }


        private void btnOkNamesKinds_Click(object sender, EventArgs e)
        {
            //חיבים לוודא שכל השדות מולאו

            
           // try 
            {
                //אתחול רשימת השמות
                List<string> names = new List<string>();
                names.Add(txtNamePlayer1.Text);
                names.Add(txtNamePlayer2.Text);
                if (numOfPlayers.Value > 2)
                    names.Add(txtNamePlayer3.Text);
                if (numOfPlayers.Value > 3)
                    names.Add(txtNamePlayer4.Text);

                //אתחול רשימת סוגי שחקנים
                List<bool> kinds = new List<bool>();

                kinds.Add(cbKindPlayer1.SelectedItem.ToString() == "מחשב" ? true : false);
                kinds.Add(cbKindPlayer2.SelectedItem.ToString() == "מחשב" ? true : false);
                if (numOfPlayers.Value > 2)
                    kinds.Add(cbKindPlayer3.SelectedItem.ToString() == "מחשב" ? true : false);
                if (numOfPlayers.Value > 3)
                    kinds.Add(cbKindPlayer4.SelectedItem.ToString() == "מחשב" ? true : false);
                ucGame ucg = new ucGame((int)numOfPlayers.Value, names, kinds);
                //names.Add("אני");
                //names.Add("Rutty");
                //kinds.Add(false);
                //kinds.Add(false);
                //ucGame ucg = new ucGame(2, names, kinds);
               
                 f2 = new Form2(ucg);
                f2.Show();
                
                
            }

            //catch (Exception ex)
            //{
            //    if(ex.GetType().Name=="NullReferenceException")
            //        MessageBox.Show("!!חובה למלא את שמות וסוגי השחקנים");              
            //}
            //this.Close();      
        }

        private void אודותToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void Form1_Load(object sender, EventArgs e)
        {
         

        }

        private void יציאהToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
