using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int[] t = new int[5];
            recAllOptions(1, t);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void recAllOptions(int x, int[] t)
        {

            for (int i = x; i <= 4 ; i++)
            {
                t[i] = i;
                string s = "";

                for (int j = 1; j <= 4; j++)
                    if (t[j] != 0)
                        s += t[j].ToString();
               MessageBox.Show(s);

                recAllOptions(i + 1, t);
                t[i] = 0;

            }

        }
    }
}
