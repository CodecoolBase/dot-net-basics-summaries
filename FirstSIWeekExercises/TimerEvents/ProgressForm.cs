using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerEvents
{

    public partial class ProgressForm : Form
    {
        Timer _codecoolTimer;

        public ProgressForm()
        {
            InitializeComponent();
        }

        private void ProgressForm_Shown(object sender, EventArgs e)
        {
            _codecoolTimer = new Timer
            {
                Interval = 1000
            };
            _codecoolTimer.Tick += new EventHandler(t_Tick);

            _codecoolTimer.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 10;
            if (progressBar1.Value >= 100)
            {
                _codecoolTimer.Stop();
            }
        }
    }
}
