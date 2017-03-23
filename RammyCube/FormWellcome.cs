using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using BL;

namespace RammyCube
{
    public partial class FormWellcome : Form
    {
        MDIParent1 mainForm;
        public FormWellcome(MDIParent1 mdiForm)
        {
            mainForm = mdiForm;
            InitializeComponent();
          
        }
        Audio a = new Audio();
        private void button1_Click(object sender, EventArgs e)
        {
            if (tbMyName.Text == "")
            
                MessageBox.Show("enter your name!");
              
            
            else
            {
                a.Play(RammyCube.Properties.Resources.chimes, Microsoft.VisualBasic.AudioPlayMode.Background);   
                mainForm.userName = tbMyName.Text;
                Form fa = new FormAttributes(mainForm);
                fa.MdiParent = mainForm;
                mainForm.childFormNumber++;
                fa.Show();

                this.Close();
            }
        }

        private void FormWellcome_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
