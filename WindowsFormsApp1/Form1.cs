using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void Button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Heyo");
            Form2 f2  = new Form2(this);
            f2.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @".\Background_music.wav";
            sp.PlayLooping();
        }

       
    }
}
