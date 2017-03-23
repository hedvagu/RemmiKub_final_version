using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualBasic.Devices;
using System.IO;
using BL;

namespace RammyCube
{
    
    public partial class FormGame : Form
    {
        public bool b_start = false;
        const int width_card_in_board = 40,height_card_in_board=60,space_card_in_board=1;

        public List<List<ccCard>> currentBoard = new List<List<ccCard>> { },retBoard=new List<List<ccCard>>();
        public ucPlayerBoard currentPB;
        public List<ccCard> currentPlayerList = new List<ccCard> { };
        public ucGame currentUcGame;
        public MDIParent1 mainForm;

        public int indCurrPlayer;
        public string path;

        public int PnlX = 15 * space_card_in_board;
        public int PnlY = 15 * space_card_in_board;

        Audio a = new Audio();

        public FormGame(ucGame uc,MDIParent1 mdi)
        {
        
            InitializeComponent();
            mainForm = mdi;
            currentUcGame = uc;
            //רישום לאירוע
            currentUcGame.eComputerFinished += new dComputerFinishedEventHandler(currentUcGame_eComputerFinished);

            currentUcGame.eLoadChangesFinished += new dLoadChangesFinishedEventHandler(currentUcGame_eLoadChangesFinished);//@@

            this.Text = "משחק";

            if (mainForm.isNetworkGame)
            {
                if (currentUcGame.playersBoards[0].name == mainForm.userName)
                    indCurrPlayer = 0;
                else
                    indCurrPlayer = 1;

                uc.playersBoards[indCurrPlayer].Location = new Point(pnlMainPlayBoard.Location.X + 100, pnlMainPlayBoard.Location.Y + pnlMainPlayBoard.Height + 5);
                uc.playersBoards[indCurrPlayer].Name = "ucPlayerBoard1";
            }

            else
            {
                //this.pnlPlayer1.Controls.Add(uc.playersBoards[0]);
                //uc.playersBoards[0].Location = new Point(103, 551);
                uc.playersBoards[uc.turn].Location = new Point(pnlMainPlayBoard.Location.X + 100, pnlMainPlayBoard.Location.Y + pnlMainPlayBoard.Height + 5);
                uc.playersBoards[uc.turn].Name = "ucPlayerBoard" + (uc.turn + 1).ToString();
            }

            #region network//@@
            if (currentUcGame.netWorkGame)
            {
                if (currentUcGame.turn == 0)
                {
                    if (mainForm.userName == currentUcGame.playersBoards[0].name)
                        lblPlayerName.Text = currentUcGame.playersBoards[0].name;
                    else
                        lblPlayerName.Text = currentUcGame.playersBoards[1].name;
                }
                else
                {
                    if (mainForm.userName == currentUcGame.playersBoards[1].name)
                        lblPlayerName.Text = currentUcGame.playersBoards[1].name;
                    else
                        lblPlayerName.Text = currentUcGame.playersBoards[0].name;
                }
                currentUcGame.setCurrentName(mainForm.userName);
            }
            else
                lblPlayerName.Text = currentUcGame.playersBoards[currentUcGame.turn].name; 
            #endregion
           // uc.playersBoards[0].Name = "ucPlayerBoard1";
            if(mainForm.isNetworkGame)
                this.Controls.Add(uc.playersBoards[indCurrPlayer]);
            else
                this.Controls.Add(uc.playersBoards[uc.turn]);
          //  this.pnlPlayer2.Controls.Add(uc.playersBoards[1]);
            //labelnmp1.Text = uc.playersBoards[0].name;
            //labelnp2.Text = uc.playersBoards[1].name;
            if (uc.playersBoards.Count() > 2)
            {
                this.BackgroundImage = global::RammyCube.Properties.Resources._2;
                //pnlPlayer3.Visible = true;//כשמוסיפיפ תמונה- למחק
               // this.pnlPlayer3.Controls.Add(uc.playersBoards[2]);
            }
            if (uc.playersBoards.Count() > 3)
            {
                this.BackgroundImage = global::RammyCube.Properties.Resources._3;
               // pnlPlayer4.Visible = true;//כשמוסיפיפ תמונה- למחק
               // this.pnlPlayer4.Controls.Add(uc.playersBoards[3]);
            }
            if (mainForm.isOpenSaveGame)
                LoadSerias("SavedGame");

          
        }

        

        void currentUcGame_eLoadChangesFinished(string filePath)
        {
            //@@
            //if (mainForm.isNetworkGame) //@@
            mainForm.pathFileNetwork = filePath;//@@
            LoadSerias(filePath);//@@           
        }

        //הפונקציה שמגיבה לאירוע
        void currentUcGame_eComputerFinished(List<List<ccCard>> cards)
        {

          //לשאול איך משווים בין 2 אוביקטים אלו: if( !(currentUcGame.cloneMainBoard == cards))
                printComputerCard(cards);
            MessageBox.Show("computer finished");//@@
        }



        public void printComputerCard(List<List<ccCard>> compList)
        {
            // ניקוי הלוח מסדרות ישנות
            if(pnlMainPlayBoard.Controls.Count > 0)
                pnlMainPlayBoard.Controls.Clear();
            PnlX = 15 * space_card_in_board;
            PnlY = 15 * space_card_in_board;
            foreach (List<ccCard> lst in compList)
            {
                createNewPnl(lst);

            }

        }

        private void createNewPnl(List<ccCard> lst)
        {
            Panel p = new Panel();
            p.Width = 0;
            int x = space_card_in_board, y = space_card_in_board;
            p.BorderStyle = BorderStyle.None;
            p.Height = height_card_in_board + 6;
            
            // הגרלת מיקום הקלפים בתוך הפאנל
            foreach (ccCard card in lst)
            {
                card.Width = width_card_in_board;
                card.Height = height_card_in_board;
                card.Font = new System.Drawing.Font("OCR A Extended", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                card.Location = new Point(x, y);
                x += space_card_in_board + width_card_in_board;
                p.Controls.Add(card);
                p.Width += width_card_in_board + space_card_in_board;
                p.BackColor = System.Drawing.Color.Transparent;
            }

            #region חישוב נקודות
            p.Location = new Point(PnlX, PnlY);
            pnlMainPlayBoard.Controls.Add(p);
            PnlX += p.Width + 20 * space_card_in_board + width_card_in_board;
            if (PnlX + p.Width + space_card_in_board > pnlMainPlayBoard.Width - space_card_in_board)                
            {
                PnlX = 15 * space_card_in_board;
                PnlY += height_card_in_board + 10 * space_card_in_board;

            }
                      
              
            #endregion
        }

        public void LoadSerias(string FileName)
        {
            //@@ להעתיק את כ-ל הפונקציה
            //@@ שינוי עבור רשת network 
            XDocument doc = XDocument.Load(FileName + ".xml");
            var prop = doc.Element("properties");
            pnlMainPlayBoard.Controls.Clear();//$$$$$$            
               // הוספת הקלפים לפאנלים
               for (int k = 0; k < currentUcGame.mainBoard.Count; k++)
                {
                    var seria = prop.Element("mainBoard").Elements();
                    Point pnlLocation = new Point((int)seria.ElementAt(k).Attribute("x"), (int)seria.ElementAt(k).Attribute("y"));
                    Panel p = new Panel();
                    int x = space_card_in_board, y = space_card_in_board;
                    p.BorderStyle = BorderStyle.None;
                    p.Height = height_card_in_board + 6;
                    p.Width = 0;//@@

                    foreach (ccCard card in currentUcGame.mainBoard[k])
                    {

                        card.Width = width_card_in_board;
                        card.Height = height_card_in_board;
                        card.Font = new System.Drawing.Font("OCR A Extended", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                        card.Location = new Point(x, y);
                        x += space_card_in_board + width_card_in_board;
                        p.Controls.Add(card);
                        p.Width += width_card_in_board + space_card_in_board;
                        p.BackColor = System.Drawing.Color.Transparent;
                    }
                    p.Location = pnlLocation;

                    pnlMainPlayBoard.Controls.Add(p);
                }
              
        }

        private void btnTurnFinished_Click(object sender, EventArgs e)
        {
            
            
            a.Play(RammyCube.Properties.Resources.Speech_On, Microsoft.VisualBasic.AudioPlayMode.Background);
            if ((mainForm.isNetworkGame && mainForm.userName == currentUcGame.playersBoards[currentUcGame.turn].name)|| !mainForm.isNetworkGame)//###
            {
                currentBoard.Clear();//###
                currentPlayerList.Clear();//###
                string currentUcPlayer;
                List<ccCard> temp = new List<ccCard> { };
                List<Point> Seriaslocation = new List<Point> { }; //@@

                if (currentUcGame.PlayerClosed)//@@ TODO: במקרה ששחקן יצא מהמשחק- לא בטוח שמיקום השאלה נכון
                    this.Close();//@@

                for (int i = 0; i < pnlMainPlayBoard.Controls.Count; i++)
                {
                    //currentBoard[i] = new List<ccCard> { };
                    foreach (ccCard card in pnlMainPlayBoard.Controls[i].Controls)
                    {
                        temp.Add(card);
                        //currentBoard[i].Add(card);
                    }

                    currentBoard.Add(temp.ToList());
                    temp.Clear();
                }


                currentUcPlayer = "ucPlayerBoard" + (currentUcGame.turn + 1).ToString();


                foreach (Control p in this.Controls)
                {

                    if ((p.Name == currentUcPlayer) || (mainForm.isNetworkGame && p.Name == "ucPlayerBoard1"))
                    {
                        foreach (ccCard card in p.Controls)
                        {
                            currentPlayerList.Add(card);
                        }
                        //@@//אתחול מערך מיקומי הסריות עבור הרשת
                        for (int i = 0; i < pnlMainPlayBoard.Controls.Count; i++)
                        {
                            Seriaslocation.Add(pnlMainPlayBoard.Controls[i].Location);
                        }

                        currentUcGame.initalizeLocations(Seriaslocation);
                        //@@עד כאן

                        retBoard = currentUcGame.endTurn(currentBoard.ToList(), currentPlayerList.ToList());

                        //בדיקה אם הסתיים המשחק
                        if (retBoard == null)
                        {
                            this.Close();
                            //פתיחת חלון סיום משחק- שמירה או לא                       
                            break;
                        }
                        for (int k = 0; k < pnlMainPlayBoard.Controls.Count; k++)
                        {
                            for (int j = 0; j < pnlMainPlayBoard.Controls[k].Controls.Count; j++)
                            {
                                if ((pnlMainPlayBoard.Controls[k].Controls[j] as ccCard).Status != eStatus.mainBoard)
                                {
                                    for (int i = j; i < pnlMainPlayBoard.Controls[k].Controls.Count - 1; i++)
                                    {
                                        pnlMainPlayBoard.Controls[k].Controls[i + 1].Left -= 32;
                                    }
                                    pnlMainPlayBoard.Controls[k].Controls.Remove(pnlMainPlayBoard.Controls[k].Controls[j--]);

                                    pnlMainPlayBoard.Controls[k].Width -= 30;
                                }
                            }
                            //foreach (ccCard card in pnl.Controls)
                            //{
                            //    if (card.Status != eStatus.mainBoard)
                            //    {
                            //        for (int i = (pnl.Controls.GetChildIndex(card)); i < pnl.Controls.Count-1; i++)
                            //        {
                            //            pnl.Controls[i+1].Left -= 32;//(card.Width + 2);
                            //        }
                            //        pnl.Controls.Remove(card);
                            //        pnl.Width -= 30;
                            //    }
                            //}
                            //בדיקה אם ישנו פאנל ריק לאחר המחיקה
                            if (pnlMainPlayBoard.Controls[k].Controls.Count == 0)
                                pnlMainPlayBoard.Controls.Remove(pnlMainPlayBoard.Controls[k--]);

                        }


                        if (!currentUcGame.netWorkGame)//@@
                            this.Controls.Remove(p);

                        break;



                    }
                }




                currentBoard.Clear();
                currentPlayerList.Clear();

                //pnlMainPlayBoard.Controls
                //יש לשים את הלוח המוחזר מהפונ' בקונטרולס של הפאנל הראשי - איך??????????? 
                //ucPlayerBoard ucp = currentUcGame.endTurn(currentBoard, currentPlayerList);
                //pnlPlayer1.Controls.Clear();
                //pnlPlayer1.Controls.Add(ucp);
                //אתחול הקלפים לשחקן הנוכחי
                if (!currentUcGame.netWorkGame)//@@
                {
                    
                    currentUcGame.playersBoards[currentUcGame.turn].Location = new Point(pnlMainPlayBoard.Location.X + 100, pnlMainPlayBoard.Location.Y + pnlMainPlayBoard.Height + 5);
                    currentUcGame.playersBoards[currentUcGame.turn].Name = "ucPlayerBoard" + (currentUcGame.turn + 1).ToString();
                    lblPlayerName.Text = currentUcGame.playersBoards[currentUcGame.turn].name;
                    this.Controls.Add(currentUcGame.playersBoards[currentUcGame.turn]);
                }//@@
            }
            else
                MessageBox.Show(" wait for your turn!", "Rammy");

        }
        private void pnlPlayer1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (sender is ccCard)
                (sender as ccCard).DoDragDrop((sender as ccCard), DragDropEffects.All);

        }
        private void pnlMainPlayBoard_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link | DragDropEffects.Move;
           
           
        }
        private void pnlMainPlayBoard_DragDrop(object sender, DragEventArgs e)
        {
            if (currentUcGame.playersBoards[currentUcGame.turn].name != mainForm.userName)//@@
            {
                pnlMainPlayBoard.AllowDrop = false;//@@
                MessageBox.Show("you can't play now-it is not your turn!");//@@
                pnlMainPlayBoard.AllowDrop = true;//@@
            }
            else//@@
            {
                
                bool flag = false;
                ccCard.dragedCard.Width = width_card_in_board;
                ccCard.dragedCard.Height = height_card_in_board;
                ccCard.dragedCard.Font = new System.Drawing.Font("OCR A Extended", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                Point pnt = PointToClient(Cursor.Position);
                pnt.X -= pnlMainPlayBoard.Location.X;
                pnt.Y -= pnlMainPlayBoard.Location.Y;
                bool flgsmall = false;

                foreach (Panel pnl in pnlMainPlayBoard.Controls)
                {

                    //מציאת הפאנל אליו נגרר הקלף
                    if (pnt.Y > pnl.Location.Y && pnt.Y < (pnl.Location.Y + pnl.Height) && pnt.X > pnl.Location.X && pnt.X < (pnl.Location.X + pnl.Width))
                    {
                        //במקרה בו המספר שהוכנס אינו הגדול ביותר
                        for (int j = 0; j < pnl.Controls.Count && !flgsmall; j++)
                        {

                            if (ccCard.dragedCard.Number < ((ccCard)pnl.Controls[j]).Number && ((ccCard)pnl.Controls[j]).Number != 14)
                            {
                                ccCard tmp;
                                int x = space_card_in_board, y = 2, i;
                                Panel newpnl = new Panel();
                                newpnl.Location = pnl.Location;
                                newpnl.Size = new System.Drawing.Size(width_card_in_board + space_card_in_board, height_card_in_board + 4);
                                ccCard.dragedCard.Location = ((ccCard)pnl.Controls[j]).Location;//new Point(x, y);
                                for (i = 0; i < j; i++)
                                {

                                    tmp = new ccCard(((ccCard)pnl.Controls[i]).Number, ((ccCard)pnl.Controls[i]).getColor);
                                    tmp.Status = ((ccCard)pnl.Controls[i]).Status;
                                    tmp.Size = ((ccCard)pnl.Controls[i]).Size;
                                    tmp.Font = ((ccCard)pnl.Controls[i]).Font;
                                    tmp.Location = ((ccCard)pnl.Controls[i]).Location;
                                    newpnl.Width += width_card_in_board;
                                    newpnl.Controls.Add(tmp);
                                    //x = tmp.Location.X;
                                    //y = tmp.Location.Y;
                                }
                                ccCard.dragedCard.Location = ((ccCard)pnl.Controls[j]).Location;
                                x = ((ccCard)pnl.Controls[j]).Location.X;
                                y = ((ccCard)pnl.Controls[j]).Location.Y;
                                newpnl.Controls.Add(ccCard.dragedCard);
                                //להוריד את הכרטיס מהלוח
                                currentUcGame.playersBoards[currentUcGame.turn].listCards.Remove(ccCard.dragedCard);//@@
                                //int x = space_card_in_board, y = 2;
                                for (i = j; i < pnl.Controls.Count; i++)
                                {
                                    newpnl.Width += width_card_in_board + space_card_in_board;
                                    x += width_card_in_board + space_card_in_board;
                                    tmp = new ccCard(((ccCard)pnl.Controls[i]).Number, ((ccCard)pnl.Controls[i]).getColor);
                                    tmp.Status = ((ccCard)pnl.Controls[i]).Status;
                                    tmp.Size = ((ccCard)pnl.Controls[i]).Size;
                                    tmp.Font = ((ccCard)pnl.Controls[i]).Font;
                                    //tmp = ((ccCard)pnl.Controls[i]).Clone();
                                    tmp.Location = new Point(x, y);
                                    newpnl.Controls.Add(tmp);
                                    newpnl.BackColor = System.Drawing.Color.Transparent;
                                }
                                pnlMainPlayBoard.Controls.Remove(pnl);
                                pnlMainPlayBoard.Controls.Add(newpnl);
                                flgsmall = true;
                            }
                        }

                        //שומר את פאנל האב 
                        //ccCard.dragedCard.Parent = pnl;
                        if (!flgsmall)
                        {
                            ccCard.dragedCard.Location = new Point(pnl.Controls[pnl.Controls.Count - 1].Location.X + width_card_in_board + space_card_in_board, pnl.Controls[pnl.Controls.Count - 1].Location.Y);
                            pnl.Width += width_card_in_board + space_card_in_board;
                            pnl.Controls.Add(ccCard.dragedCard);
                        }
                        flag = true;
                        //continue;
                    }
                    if (!flag)
                    {
                        //מציאת הפאנל ממנו נגרר הקלף
                        //if (ccCard.dragedCard.Location.Y + pnl.Location.Y > pnl.Location.Y && ccCard.dragedCard.Location.Y + pnl.Location.Y < (pnl.Location.Y + pnl.Height) && ccCard.dragedCard.Location.X + pnl.Location.X > pnl.Location.X && ccCard.dragedCard.Location.X + pnl.Location.X < (pnl.Location.X + pnl.Width))
                        if (pnl.Controls.Contains(ccCard.dragedCard))
                        {
                            //הערה- להוסיף בדיקת מיקום גם ל-DRAGLEAVE
                            //האם הקלף שהוסר היה הראשון או האחרון
                            //אם האחרון-
                            // if (pnl.Controls.GetChildIndex(ccCard.dragedCard) == pnl.Controls.Count-1)
                            {
                                //for (int i = pnl.Controls.GetChildIndex(ccCard.dragedCard)-1; i < pnl.Controls.Count; i++)//אולי טוב יותר
                                for (int i = pnl.Controls.GetChildIndex(ccCard.dragedCard); i < pnl.Controls.Count; i++)
                                {
                                    pnl.Controls[i].Left -= (width_card_in_board + space_card_in_board);//(card.Width + 2);
                                }
                                pnl.Controls.Remove(ccCard.dragedCard);
                                //foreach (ccCard card in pnl.Controls)
                                //{
                                //    card.Left -= (card.Width + 2);//(ccCard.width_card + ccCard.l_space_between_cards);
                                //}
                                pnl.Width -= (width_card_in_board + space_card_in_board);
                            }
                        }
                        //else
                        //    break;
                    }
                }
                e.Effect = DragDropEffects.Move;
                if (!flag)
                {
                    Panel p = new Panel();
                    ccCard.dragedCard.Location = new Point(2, 2);
                    //שומר את פאנל האב 
                    //ccCard.dragedCard.Parent = p;
                    p.Controls.Add(ccCard.dragedCard);
                    p.Location = pnt;
                    p.BorderStyle = BorderStyle.None;
                    p.Height = height_card_in_board + 6;
                    p.Width = width_card_in_board + (4 * space_card_in_board);
                    p.BackColor = System.Drawing.Color.Transparent;
                    pnlMainPlayBoard.Controls.Add(p);
                }

                //בדיקה אם ישנו פאנל ריק לאחר גרירה
                foreach (Panel pnl in pnlMainPlayBoard.Controls)
                {
                    if (pnl.Controls.Count == 0)
                        pnlMainPlayBoard.Controls.Remove(pnl);
                }
            }
           
        }

        private void pnlPlayer1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void pnlMainPlayBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is ccCard)
                (sender as ccCard).DoDragDrop((sender as ccCard), DragDropEffects.All);
        }

     
        private void pnlMainPlayBoard_DragLeave(object sender, EventArgs e)
        {
               bool flag = false;
               Point ps = PointToScreen(ccCard.dragedCard.Location),pc=PointToClient(ccCard.dragedCard.Location);
               
               foreach (Panel pnl in pnlMainPlayBoard.Controls)
               {
                   Point pnls = PointToScreen(pnl.Location),pnlc=PointToClient(pnl.Location);
                   if(pnl.Controls.Contains(ccCard.dragedCard))                  
                   {

                      // if (ccCard.dragedCard.Status == eStatus.Player || ccCard.dragedCard.Number == 14)
                       {
                           //ccCard.toDrag = true;
                           for (int i = pnl.Controls.GetChildIndex(ccCard.dragedCard); i < pnl.Controls.Count; i++)
                           {
                               pnl.Controls[i].Left -= (width_card_in_board + space_card_in_board);//(card.Width + 2);
                           }
                           pnl.Controls.Remove(ccCard.dragedCard);
                           //foreach (ccCard card in pnl.Controls)
                           //{
                           //    card.Left -= (card.Width + 2);//(ccCard.width_card + ccCard.l_space_between_cards);
                           //}
                           pnl.Width -= width_card_in_board;

                           flag = true;
                           //continue;
                       }
                       //else
                       //    ccCard.toDrag = false;
                   }
                   if (flag)
                   {
                       if (pnl.Controls.Count == 0)
                           pnlMainPlayBoard.Controls.Remove(pnl);
                       break;
                   }
               }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSaveGame fs = new FormSaveGame(this);       
            fs.Show();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    LoadSerias();
        //}

        public void writeFinishedToFile()//@@network
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
            if (mainForm.isNetworkGame)
            {
                //mainForm.pathFileNetwork = path + currentUcGame.playersBoards[0].name + currentUcGame.playersBoards[1].name;
                ////XDocument doc = XDocument.Load(path + "exit.xml");
                ////var prop = doc.Element("properties");
                //XElement prop = new XElement("status", new XAttribute("userName", mainForm.userName), new XAttribute("status", "finished"));
                //prop.Save(path + "exit.xml");
                //mainForm.pathFileNetwork = path + currentUcGame.playersBoards[0].name + currentUcGame.playersBoards[1].name;
                //XDocument doc = XDocument.Load(path + currentUcGame.playersBoards[0].name + currentUcGame.playersBoards[1].name + ".xml");
                //var prop = doc.Element("properties");
                //prop.Add(new XElement("status", new XAttribute("userName", mainForm.userName), new XAttribute("status", "finished")));
                //prop.Save(path + currentUcGame.playersBoards[0].name + currentUcGame.playersBoards[1].name + ".xml");
            }
        }

        private void FormGame_Load(object sender, EventArgs e)
        {

        }

        private void pnlMainPlayBoard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}