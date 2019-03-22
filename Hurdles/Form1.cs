using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hurdles
{
    public partial class Form1 : Form
    {
        public static int f1Score;
        public Form1()
        {
            InitializeComponent();
            TitleScreen ts = new TitleScreen();
            this.Controls.Add(ts);
            ts.Location = new Point((Width) / 2, (Height) /2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
