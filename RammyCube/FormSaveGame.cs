using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Dal;
using BL;


namespace RammyCube
{
    public partial class FormSaveGame : Form
    {
        SaveToXml saveToXml;
       
        FormGame formG;
        public FormSaveGame(Form curForm)
        {
            InitializeComponent();
           
             formG = (FormGame) curForm;
            
        }

        private void FormSaveGame_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int nmOfPlayers = formG.currentUcGame.numOfPlayers;
            int trn = formG.currentUcGame.turn;           
            List<ccCard> lstBx = formG.currentUcGame.box;
            List<List<ccCard>> mainBoard = formG.currentUcGame.mainBoard;
            string[] pl = new string[4];
            bool[] kn = new bool[4];
            List<Point> location = new List<Point> { };
            saveToXml = new SaveToXml();
            List<ccCard>[] lstcrds = new List<ccCard>[4];
            //if (File.Exists("C:\\Users\\tzipi\\Desktop\\סופי סופי\\RammyCube\\RammyCube\\bin\\Debug\\SavedGame.xml"))
            {
                if ((MessageBox.Show("there is an older saved game, do you want to save this game?", "saving game", MessageBoxButtons.YesNo).ToString()) == "Yes")
                {

                    for (int i = 0; i < nmOfPlayers; i++)
                    {
                        pl[i] = formG.currentUcGame.playersBoards[i].name;
                        kn[i] = formG.currentUcGame.playersBoards[i].computer;
                        lstcrds[i] = formG.currentUcGame.playersBoards[i].listCards;
                    }

                    for (int i = 0; i < mainBoard.Count; i++)
                    {

                        location.Add(formG.pnlMainPlayBoard.Controls[i].Location);
                    }
                    saveToXml.SaveProperties(nmOfPlayers, trn, pl, kn, lstcrds, lstBx, mainBoard, location);
                }
            }

            if (formG.mainForm.isOpenNewGame)
            {
                Form fa = new FormAttributes(formG.mainForm);
                fa.MdiParent = formG.mainForm;
                formG.Close();
                fa.Show();
                formG.mainForm.isOpenNewGame = false;
            }
            if (formG.mainForm.isExitGame)
            {
                formG.Close();
                formG.mainForm.isExitGame = false;
            }

            this.Close();
         
         

        }

        private void btnNotSave_Click(object sender, EventArgs e)
        {

            if (!formG.mainForm.isExitGame && formG.mainForm.isOpenNewGame) //btnCancelSve.Visible == true &&  
            {
                Form fa = new FormAttributes(formG.mainForm);
                fa.MdiParent = formG.mainForm;
                formG.Close();
                fa.Show();
                formG.mainForm.isOpenNewGame = false;
            }
            if (formG.mainForm.isExitGame)
            {
                formG.Close();
                formG.mainForm.isExitGame = false;
            }
            this.Close();
        }

        private void btnCancelSve_Click(object sender, EventArgs e)
        {
            formG.mainForm.isExitGame = false;
            this.Close();
        }

       
    }
}
