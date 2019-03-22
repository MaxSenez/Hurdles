using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Hurdles
{
    public partial class GameScreen : UserControl
    {
        Runner r;
        SolidBrush p1Brush = new SolidBrush(Color.Red);
        Font scoreFont = new Font("Tandysoft", 25);
        Random rand = new Random();
        List<ScreenHurdles> osHurdles = new List<ScreenHurdles>();
        SoundPlayer jumpSound = new SoundPlayer(Properties.Resources.collision);
        SoundPlayer crashSound = new SoundPlayer(Properties.Resources.score);
        int type = 1;
        int jumpTime = 9;
        int hurdleSpeed = 8;
        int gameTimer = 0;
        int xSize, ySize;
        public int score;
        int interval = 90;
        bool spaceDown;
        Random typeRand = new Random();

        public GameScreen()
        {
            InitializeComponent();
            r = new Runner(30, Height - 100, 15, 30);
        }


        private void GameLoop_Tick(object sender, EventArgs e)
        {
            gameTimer++;
            score = gameTimer;

            if (score % 150 == 0)
            {
                hurdleSpeed++;
            }
            if (score % 500 == 0)
            {
                interval = interval - 10;
            }

            if (spaceDown) // if space pressed Jump player 
            {

                r.Jump(jumpTime);
                jumpTime--;
                if (jumpTime < -9)
                {
                    jumpTime = 9;
                    spaceDown = false;
                }
            }
            #region hurdles


            if(gameTimer % interval == 1) // adding new boxes (this happens at a regular interval)
            {
                           
                type = typeRand.Next(1, 7);
                switch (type)
                {
                    case 1:
                        xSize = 15;
                        ySize = 15;
                        break;
                    case 2:
                        xSize = 30;
                        ySize = 15;
                        break;
                    case 3:
                        xSize = 45;
                        ySize = 15;
                        break;
                    case 4:
                        xSize = 15;
                        ySize = 30;
                        break;
                    case 5:
                        xSize = 30;
                        ySize = 30;
                        break;
                    case 6:
                        xSize = 45;
                        ySize = 30;
                        break;
                }
                ScreenHurdles hurdle = new ScreenHurdles(Width - xSize, Height - ySize - 70, xSize, ySize);
                osHurdles.Add(hurdle);
            }

            foreach ( ScreenHurdles hurdle in osHurdles)
            {
                hurdle.Move(hurdleSpeed);
            }
            if (osHurdles[0].rec.X <0) //removing boxes when they move offscreen
            {
                osHurdles.RemoveAt(0);
            }

            foreach (ScreenHurdles hurdle in osHurdles)
            {
                if (hurdle.death(r) == true)
                {
                    crashSound.Play();
                    GameLoop.Stop();
                    Thread.Sleep(750);
                    crashSound.Stop();
                    GameScreen gs = new GameScreen();
                    TitleScreen ts = new TitleScreen();
                    Form1.f1Score = score;
                    this.Controls.Remove(gs);
                    this.Controls.Add(ts);
                    ts.Location = new Point((Width - gs.Width) / 2, (Height - gs.Height) / 2);
                    ts.Focus();
                }
            }


            #endregion

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(p1Brush, r.x, r.y, r.width, r.height);
            e.Graphics.DrawString("" + score, scoreFont, p1Brush, Width - 125, 30);

            foreach (ScreenHurdles hurdle in osHurdles)
            {
                e.Graphics.FillRectangle(p1Brush, hurdle.x, hurdle.y, hurdle.width, hurdle.height);
            }
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            Refresh();
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceDown = false;
                    jumpSound.Stop();
                break;
            }

        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceDown = true;
                    jumpSound.Play();
                    break;
                case Keys.Escape:
                    ((Form1)this.TopLevelControl).Close();
                    break;
            }
        }
    }
}
