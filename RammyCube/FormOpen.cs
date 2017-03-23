using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace RammyCube
{
    public partial class FormOpen : Form
    { 
        MDIParent1 mainForm;
        
        public FormOpen(MDIParent1 mdiForm)
        {
            mainForm = mdiForm;
            InitializeComponent();
        }

        public FormOpen()
        {
            InitializeComponent();
        }
        int num = 0;
        private void FormOpen_Load(object sender, EventArgs e)
        {
            Audio a = new Audio();
            a.Play(RammyCube.Properties.Resources.tada, Microsoft.VisualBasic.AudioPlayMode.Background);   
            this.UseWaitCursor = true;
            timer1.Start();
        }
        
   
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 5;
            if (progressBar1.Value == 100)
            {
                timer2.Start();
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            num++;
            if (num == 5)
            {
                this.UseWaitCursor = false;
                timer2.Stop();
                this.Hide();
                //Form wellcome = new FormWellcome(mainForm);
                //wellcome.MdiParent = mainForm;
                //wellcome.Show();
                Form mdi = new MDIParent1();
                
                mdi.Show();
            }
        }
    }
}
