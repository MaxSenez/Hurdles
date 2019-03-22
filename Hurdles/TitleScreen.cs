using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hurdles
{
    public partial class TitleScreen : UserControl
    {
        Font titleFont = new Font("Tandysoft", 35);
        Font scoreFont = new Font("Tandysoft", 25);
        SolidBrush titleBrush = new SolidBrush(Color.Red);
        public int tsScore;

        GameScreen gs = new GameScreen();
        

        public TitleScreen()
        {
            InitializeComponent();
          
        }

        private void TitleScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:

                    Form f = this.FindForm();
                    this.Controls.Remove(this);
                    this.Controls.Add(gs);
                    gs.Focus();
                    break;
                case Keys.Escape:
                    ((Form1)this.TopLevelControl).Close();
                    break;
            }
        }

        private void TitleScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("PRESS SPACE TO PLAY", titleFont, titleBrush, Width /2 -278, Height /2 -50);
            e.Graphics.DrawString("Last Score: " + tsScore, scoreFont, titleBrush, Width / 2 - 175, Height / 2 + 15);
        }

        private void TitleScreen_Load(object sender, EventArgs e)
        {
           tsScore = Form1.f1Score;
        }
    }
}
