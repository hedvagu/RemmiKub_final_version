using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BL
{
    public partial class ucPlayerBoard : UserControl,ICloneable
    {
        public bool computer;
        public string name;
        public List<ccCard> listCards;
      
        public ucPlayerBoard(List<ccCard> myList,string _name,bool kind)
        {
          //דרך אחת
            //switch (kind)
            //{   
            //    case true:
            //        ComputerPlayer player = new ComputerPlayer(_name, myList);
            //    break;
            //    case false:
            //        HumanPlayer player = new HumanPlayer(_name,myList);
            //}
            //דרך אחרת
            InitializeComponent();
            listCards= myList;
            name = _name;
            computer = kind;
          
           
           
           
        }

        public ucPlayerBoard()
        {
            // TODO: Complete member initialization
        }
        
        ~ucPlayerBoard()
        {
        
        }


        


        public object Clone()
        {
            ucPlayerBoard clonePB = new ucPlayerBoard(this.listCards, this.name, this.computer);
            return clonePB;
        }

        private void ucPlayerBoard_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (sender is ccCard)
                (sender as ccCard).DoDragDrop((sender as ccCard), DragDropEffects.All);
        }

        private void ucPlayerBoard_DragEnter(object sender, DragEventArgs e)
        {
           
            e.Effect = DragDropEffects.Move;
         
        }

        private void ucPlayerBoard_DragDrop(object sender, DragEventArgs e)
        {
            
            //אם לקח קלף שלא שיך אליו והוא לא ג'וקר
            if (ccCard.dragedCard.Status != eStatus.Player && ccCard.dragedCard.Number != 14)
            {
                //צריך לא לאפשר את הגרירה בצורה כלשהי ולהחזירו למקומו
                //this.AllowDrop = false;
                //MessageBox.Show(ccCard.dragedCardLocation.ToString());
                ccCard.dragedCard.Location = new Point(ccCard.dragedCardParent.Controls[ccCard.dragedCardParent.Controls.Count - 1].Right + 2, 2);
                ccCard.dragedCardParent.Width += 32;
                ccCard.dragedCardParent.Controls.Add(ccCard.dragedCard);
                //ccCard.dragedCard.Location = ccCard.dragedCardLocation;
                return;
            }
            //this.AllowDrop = true;
            ccCard.dragedCard.Width = ccCard.width_card;
            ccCard.dragedCard.Height = ccCard.height_card;
            ccCard.dragedCard.Font = new System.Drawing.Font("OCR A Extended", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
             bool flag = false;

            //foreach (Panel pnl in pnlMainPlayBoard.Controls)
            //{

            //    //MessageBox.Show(ccCard.dragedCard.Location.ToString() + pnl.Location.ToString());
            //    if (ccCard.dragedCard.Location.Y + pnl.Location.Y > pnl.Location.Y && ccCard.dragedCard.Location.Y + pnl.Location.Y < (pnl.Location.Y + pnl.Height) && ccCard.dragedCard.Location.X + pnl.Location.X > pnl.Location.X && ccCard.dragedCard.Location.X + pnl.Location.X < (pnl.Location.X + pnl.Width))
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
            e.Effect = DragDropEffects.Move;
           // ccCard.dragedCard.Location = new Point(pnlPlayer1.Controls[0].Controls[pnlPlayer1.Controls[0].Controls.Count - 1].Location.X + 32, pnlPlayer1.Controls[0].Controls[pnlPlayer1.Controls[0].Controls.Count - 1].Location.Y);
            //pnlPlayer1.Controls[0].Controls.Add(ccCard.dragedCard);
            if (this.Controls[this.Controls.Count - 1].Right + ccCard.dragedCard.Width > this.Width)
            {
                ccCard.dragedCard.Top += ccCard.height_card + ccCard.t_space_between_cards;
                ccCard.dragedCard.Left = ccCard.l_space_between_cards;
            }
            else
            {
                ccCard.dragedCard.Left = this.Controls[this.Controls.Count - 1].Right + ccCard.l_space_between_cards;
                ccCard.dragedCard.Top = this.Controls[this.Controls.Count - 1].Top;
            }
            this.Controls.Add(ccCard.dragedCard);
           
        }
    }
}
