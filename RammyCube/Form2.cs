using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;

namespace RammyCube
{
    //לבדוק אם מספרים עוקבים- אם קטן להוסף להתחלה ואם לא- לסוף
    public partial class Form2 : Form
    {
        public bool b_start = false;
        const int width_card_in_board = 30,height_card_in_board=45,space_card_in_board=2;


        public List<List<ccCard>> currentBoard = new List<List<ccCard>> { },retBoard=new List<List<ccCard>>();
        public ucPlayerBoard currentPB;
        public List<ccCard> currentPlayerList = new List<ccCard> { };
        public ucGame currentUcGame;
        public Form2(ucGame uc)
        {
            
            InitializeComponent();
            currentUcGame = uc;            
            this.Text = "משחק";
            this.Controls.Add(uc);
            //this.pnlPlayer1.Controls.Add(uc.playersBoards[0]);
            //uc.playersBoards[0].Location = new Point(103, 551);
            uc.playersBoards[uc.turn].Location = new Point(113, 551);
            uc.playersBoards[uc.turn].Name = "ucPlayerBoard" + (uc.turn+1).ToString();
            lblPlayerName.Text = currentUcGame.playersBoards[currentUcGame.turn].name;
           // uc.playersBoards[0].Name = "ucPlayerBoard1";
            this.Controls.Add(uc.playersBoards[uc.turn]);
          //  this.pnlPlayer2.Controls.Add(uc.playersBoards[1]);
            //labelnmp1.Text = uc.playersBoards[0].name;
            //labelnp2.Text = uc.playersBoards[1].name;
            if (uc.playersBoards.Count() > 2)
            {
                pnlPlayer3.Visible = true;
               // this.pnlPlayer3.Controls.Add(uc.playersBoards[2]);
            }
            if (uc.playersBoards.Count() > 3)
            {
                pnlPlayer4.Visible = true;
               // this.pnlPlayer4.Controls.Add(uc.playersBoards[3]);
            }
        }
        private void btnTurnFinished_Click(object sender, EventArgs e)
        {
            string currentUcPlayer;
            List<ccCard> temp = new List<ccCard> { };

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

          
            currentUcPlayer = "ucPlayerBoard" + (currentUcGame.turn+1).ToString();


            foreach (Control p in this.Controls)
            {
               
                if (p.Name == currentUcPlayer)
                {
                    foreach (ccCard card in p.Controls)
                    {
                        currentPlayerList.Add(card);
                     }
                    retBoard = currentUcGame.endTurn(currentBoard.ToList(), currentPlayerList.ToList());

                    for (int k = 0; k < pnlMainPlayBoard.Controls.Count; k++)
                    {
                        
                    
                    //foreach (Panel pnl in pnlMainPlayBoard.Controls)
                   // {

                        for (int j = 0; j < pnlMainPlayBoard.Controls[k].Controls.Count; j++)
                        {
                            if ((pnlMainPlayBoard.Controls[k].Controls[j] as ccCard).Status != eStatus.mainBoard)
                            {
                                for (int i = j; i < pnlMainPlayBoard.Controls[k].Controls.Count - 1; i++)
                                {
                                    pnlMainPlayBoard.Controls[k].Controls[i + 1].Left -= 32;//(card.Width + 2);
                                }
                                pnlMainPlayBoard.Controls[k].Controls.Remove(pnlMainPlayBoard.Controls[k].Controls[j--]);
                                //j--;
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
            currentUcGame.playersBoards[currentUcGame.turn].Location = new Point(113, 551);
            currentUcGame.playersBoards[currentUcGame.turn].Name = "ucPlayerBoard" + (currentUcGame.turn + 1).ToString();
            lblPlayerName.Text = currentUcGame.playersBoards[currentUcGame.turn].name;
            this.Controls.Add(currentUcGame.playersBoards[currentUcGame.turn]);

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
                   
                        if (ccCard.dragedCard.Number < ((ccCard)pnl.Controls[j]).Number)
                        {
                            ccCard tmp;
                            int x = space_card_in_board, y = 2,i;
                            Panel newpnl = new Panel();
                            newpnl.Location = pnl.Location;
                            newpnl.Size = new System.Drawing.Size(width_card_in_board+space_card_in_board, height_card_in_board + 4);
                            ccCard.dragedCard.Location = ((ccCard)pnl.Controls[j]).Location;//new Point(x, y);
                            for (i = 0; i < j; i++)
                            {
                                tmp = new ccCard(((ccCard)pnl.Controls[i]).Number, ((ccCard)pnl.Controls[i]).getColor);
                                tmp.Status = ((ccCard)pnl.Controls[i]).Status;
                                tmp.Size = ((ccCard)pnl.Controls[i]).Size;
                                tmp.Font = ((ccCard)pnl.Controls[i]).Font;
                                tmp.Location =((ccCard)pnl.Controls[i]).Location;
                                newpnl.Width += width_card_in_board + space_card_in_board;
                                newpnl.Controls.Add(tmp);
                                //x = tmp.Location.X;
                                //y = tmp.Location.Y;
                            }
                            ccCard.dragedCard.Location = ((ccCard)pnl.Controls[j]).Location;
                            x = ((ccCard)pnl.Controls[j]).Location.X;
                            y = ((ccCard)pnl.Controls[j]).Location.Y;
                            newpnl.Controls.Add(ccCard.dragedCard);
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
                            }
                            pnlMainPlayBoard.Controls.Remove(pnl);
                            pnlMainPlayBoard.Controls.Add(newpnl);
                            flgsmall=true;
                        }
                    }
                    //אם המספר קטן מהראשון- יש להחליף את סדר הקונטרולים על הפאנל הנוכחי- אבל איך?
                    //for (int i = 0; i < pnl.Controls.Count; i++)
                    //{
                    //    if(((ccCard)pnl.Controls[i]).Number<ccCard.dragedCard.Number)
                    //        continue;
                    //    else
                    //        while (ccCard.dragedCard.Number < ((ccCard)pnl.Controls[i]).Number)
                    //        { 
                    //            pnl.Controls[i].Left+=32;
                    //           // pnl.Controls.SetChildIndex(pnl.Controls[i],++i);
                    //        }
                    //}


                    //{
                    //    for (int i = 0; i > pnl.Controls.Count - 2; i++)
                    //    {
                    //        pnl.Controls.SetChildIndex(pnl.Controls[i], i + 1);
                    //        //pnl.Controls[i]=pnl.Controls[i - 1];
                    //    }
                    //}
                    //שומר את פאנל האב 
                    //ccCard.dragedCard.Parent = pnl;
                    if(!flgsmall)
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
                                pnl.Controls[i].Left -= (width_card_in_board+space_card_in_board);//(card.Width + 2);
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
                p.Height = height_card_in_board+6;
                p.Width = width_card_in_board+(4*space_card_in_board);                
                pnlMainPlayBoard.Controls.Add(p);
            }
            
            //בדיקה אם ישנו פאנל ריק לאחר גרירה
            foreach (Panel pnl in pnlMainPlayBoard.Controls)
            {
                if (pnl.Controls.Count == 0)
                    pnlMainPlayBoard.Controls.Remove(pnl);
            }
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void pnlPlayer2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlPlayer1_DragDrop(object sender, DragEventArgs e)
        {
            //bool flag = false;
            //ccCard.dragedCard.Width = ccCard.width_card;
            //ccCard.dragedCard.Height = ccCard.height_card;
            //ccCard.dragedCard.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            //Point pnt = PointToClient(Cursor.Position);
            //pnt.X -= pnlMainPlayBoard.Location.X;
            //pnt.Y -= pnlMainPlayBoard.Location.Y;
            
            //foreach (Panel pnl in pnlMainPlayBoard.Controls)
            //{
                
            //    //MessageBox.Show(ccCard.dragedCard.Location.ToString() + pnl.Location.ToString());
            //   // if (ccCard.dragedCard.Location.Y + pnl.Location.Y > pnl.Location.Y && ccCard.dragedCard.Location.Y + pnl.Location.Y < (pnl.Location.Y + pnl.Height) && ccCard.dragedCard.Location.X + pnl.Location.X > pnl.Location.X && ccCard.dragedCard.Location.X + pnl.Location.X < (pnl.Location.X + pnl.Width))
            //    if (pnl.Controls.Contains(ccCard.dragedCard))
            //    {
                    
            //        pnl.Width -= 30;
            //        pnl.Controls.Remove(ccCard.dragedCard);


            //        flag = true;
            //        //continue;
            //    }
            //    if (flag)
            //    {
            //        if (pnl.Controls.Count == 0)
            //            pnlMainPlayBoard.Controls.Remove(pnl);
            //        break;
            //    }
            //}
            //e.Effect = DragDropEffects.Move;
            //ccCard.dragedCard.Location = new Point(pnlPlayer1.Controls[0].Controls[pnlPlayer1.Controls[0].Controls.Count - 1].Location.X + 32, pnlPlayer1.Controls[0].Controls[pnlPlayer1.Controls[0].Controls.Count - 1].Location.Y);
            //pnlPlayer1.Controls[0].Controls.Add(ccCard.dragedCard);
           
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

        private void pnlMainPlayBoard_Paint(object sender, PaintEventArgs e)
        {

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
    }
}