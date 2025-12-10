using HotelBookingSystem.Data;
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
    
    public partial class Form1 : Form
    {
        int move;
        int movx;
        int movy;
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        

       

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {





            using (var db = new HotelContext())
            {
                var user = db.Users
                             .FirstOrDefault(x => x.Name.Trim().ToLower() == textName.Text.Trim().ToLower()
                                               && x.Password == textPassword.Text.Trim()
                                               );

                if (user == null)
                {
                    MessageBox.Show("❌ اسم المستخدم أو كلمة المرور غير صحيحة");
                    return;
                }

                Global.CurrentUserId = user.Id;

                if (user.Role.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    this.Hide();
                    Form3 form3= new Form3();
                    form3.ShowDialog();

                }

                else
                {
                    this.Hide();
                    Form4 form4 = new Form4();
                    form4.ShowDialog();

                }
                
            }

        }




        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            movx = e.X;
            movy=e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move==1)
            {
                this.SetDesktopLocation(MousePosition.X-movx, MousePosition.Y - movy);
            }
        }
    }
}
