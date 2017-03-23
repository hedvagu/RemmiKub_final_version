using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BL
{
     
    public partial class ccCard : Button,ICloneable
    {
        //statrt_x,y

        public const  int width_card = 60;
        public const int height_card = 90;
        public const int l_space_between_cards = 2,t_space_between_cards=10;
        private readonly byte number;

        public static Point dragedCardLocation;
        public static ccCard dragedCard;
        public static Control dragedCardParent;
        public static bool toDrag = true;
       
        public byte Number
        {
            get { return number; }
        }

        readonly eColor color;

        public eColor getColor
        {
            get { return color; }
        } 

        eStatus status;
        private int k;
        //private eColor eColor;

        public eStatus Status
        {
            get { return status; }
            set { status = value; }
        }


        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    base.OnPaint(pe);
        //}
        public ccCard(byte bdika_num, eColor bdika_clr, bool itchul)
        {
            number = bdika_num;
            color = bdika_clr;
        }
        
        public ccCard(byte num, eColor col)
        {

            InitializeComponent();
            number = num;

            color = col;

            switch (color)
            {
                case eColor.Blue:
                    this.ForeColor = Color.Blue;
                    break;
                case eColor.Red:
                    this.ForeColor = Color.Red;
                    break;
                case eColor.Green:
                    this.ForeColor = Color.Green;
                    break;
                case eColor.Orange:
                    this.ForeColor = Color.Orange;
                    break;
            }

            this.Text = number.ToString();
            this.Height = height_card;
            this.Width = width_card;

            if (this.number == 14)
            {
                this.Text = "";
                switch (color)
                {
                    case eColor.Blue:
                        this.BackgroundImage = global::RammyCube.Properties.Resources.JBlue;
                        break;
                    case eColor.Red:
                        this.BackgroundImage = global::RammyCube.Properties.Resources.JRed;
                        break;
                    case eColor.Green:
                        this.BackgroundImage = global::RammyCube.Properties.Resources.JGreen;
                        break;
                    case eColor.Orange:
                        this.BackgroundImage = global::RammyCube.Properties.Resources.JYellow;
                        break;
                }
            }


            this.Show();      
                    
        }

        public ccCard(byte num, eColor col, eStatus stat)
        {
            InitializeComponent();
            number = num;

            color = col;

            status = stat;

            switch (color)
            {
                case eColor.Blue:
                    this.ForeColor = Color.Blue;
                    break;
                case eColor.Red:
                    this.ForeColor = Color.Red;
                    break;
                case eColor.Green:
                    this.ForeColor = Color.Green;
                    break;
                case eColor.Orange:
                    this.ForeColor = Color.Orange;
                    break;
            }

            this.Text = number.ToString();
            this.Height = height_card;
            this.Width = width_card;

            if (this.number == 14)
            {
                this.Text = "";
                switch (color)
                {
                    case eColor.Blue:
                        this.BackgroundImage = global::RammyCube.Properties.Resources.JBlue;
                        break;
                    case eColor.Red:
                        this.BackgroundImage = global::RammyCube.Properties.Resources.JRed;
                        break;
                    case eColor.Green:
                        this.BackgroundImage = global::RammyCube.Properties.Resources.JGreen;
                        break;
                    case eColor.Orange:
                        this.BackgroundImage = global::RammyCube.Properties.Resources.JYellow;
                        break;
                }
            }
            this.Show();       
        }
     
        public object Clone()
        {
            ccCard cloneCard = new ccCard(this.number, this.color,false);
            return cloneCard;
        }


       
        void ccCard_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            dragedCard = (sender as ccCard);
            //dragedCardLocation = dragedCard.Location;
           // dragedCardLocation = RelativeLocation(dragedCard);
            dragedCardParent = dragedCard.Parent;
            //if(toDrag)
            (sender as ccCard).DoDragDrop((sender as ccCard), DragDropEffects.Move);

            //b_strat=true
            //x_start=e.x staRTY=E.Y
        }

        public Point RelativeLocation(Control cnt)
        {
            int x = 0, y = 0;
            while (!(cnt is Form))
            {
                x += cnt.Location.X;
                y += cnt.Location.Y;
                cnt = cnt.Parent;    
            }
            return new Point(x, y);
        }

        private void ccCard_MouseMove(object sender, MouseEventArgs e)
        {

        }

    }
}
