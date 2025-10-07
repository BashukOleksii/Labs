using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabRob1
{
    public partial class MessageBoxMy : Form
    {
        bool all = false, one = false;
        public MessageBoxMy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            all = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            one = true;
            this.Close();
        }

        private void MessageBoxMy_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(all)
                DialogResult = DialogResult.OK;
            else if(one)
                DialogResult= DialogResult.Yes;
            else
                DialogResult = DialogResult.Cancel;
        }
    }
}
