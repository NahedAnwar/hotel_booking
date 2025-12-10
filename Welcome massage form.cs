using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBookingSystem
{
    public partial class WlcomemessageForm : Form
    {
        public WlcomemessageForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Form1 form=new Form1();
            form.ShowDialog();

        }

        private void WlcomemessageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
