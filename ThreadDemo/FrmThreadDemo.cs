using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadDemo
{
    public partial class FrmThreadDemo : Form
    {
        Thread _showNumberThread;
        public FrmThreadDemo()
        {
            InitializeComponent();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_showNumberThread == null ||
                _showNumberThread.ThreadState == ThreadState.Unstarted ||
                _showNumberThread.ThreadState == ThreadState.Aborted)
            {
                _showNumberThread = new Thread(new ThreadStart(DisplayRandomNumber));
                _showNumberThread.Name = "Display DateTime";
                _showNumberThread.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_showNumberThread.ThreadState != ThreadState.Aborted)
            {
                _showNumberThread.Abort();
                _showNumberThread = null;
            }
        }

        private void DisplayRandomNumber()
        {
            while (true)
            {
                rboxInfo.BeginInvoke((MethodInvoker)delegate () { rboxInfo.AppendText(DateTime.Now.ToString("dd'/'MM'/'yyyy hh:mm:ss ttt") + Environment.NewLine); });
                Thread.Sleep(10);
            }
        }
    }
}
