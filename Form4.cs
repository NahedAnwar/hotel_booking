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
    public partial class Form4 : Form
    {
        int move;
        int movx;
        int movy;
        public Form4()
        {
            InitializeComponent();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1= new Form1();  
            form1.ShowDialog();

        }

     

        

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            CustomerManagment customerview = new CustomerManagment();
            customerview.Dock = DockStyle.Fill;
            panel4.Controls.Add(customerview);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            RoomsManagment roomview = new RoomsManagment();
            roomview.Dock = DockStyle.Fill;
            panel4.Controls.Add(roomview);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            BookingManagment bookingview = new BookingManagment();
            bookingview.Dock = DockStyle.Fill;
            panel4.Controls.Add(bookingview);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            movx = e.X;
            movy = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movx, MousePosition.Y - movy);
            }
        }
    }
    }

