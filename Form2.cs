using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace HotelBookingSystem
{
    public partial class Form2 : Form
    {
        int move;
        int movx;
        int movy;
        public Form2()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0) ;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            string phone = textPhone.Text;
            string password = textPassword.Text;
            string national=textNational.Text;
            string gender = radioMale.Checked ? "Male" : radioFemale.Checked ? "Female" : "Other";



            //Validate Name
            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                MessageBox.Show("Name is requird", "valiation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textName.Focus();
                return;

            }
            //Validate phone
            if (string.IsNullOrWhiteSpace(phone))
            {

                MessageBox.Show("Phone is required ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPhone.Focus();
                return;
            }


            else if (textPhone.TextLength < 9)
            {
                MessageBox.Show("Phone must be at Least 9 Nunbers", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPhone.Focus();
                return;
            }

            if (textPassword.MaxLength < 9)
            {
                MessageBox.Show("Pasword must be at Least 9 characters!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPhone.Focus();
                return;
            }
            bool hasLetter = false;
            bool hasDigit = false;
            bool hasSymbol = false;
            foreach (char c in password)
            {
                if (char.IsLetter(c))
                
                    hasLetter = true;


                else if (char.IsDigit(c))

                        hasDigit = true;

                    else

                        hasSymbol = true;
                    


                }
            if (hasDigit && !hasLetter && !hasSymbol)
            {
                MessageBox.Show("The input can not contain  only numbers , but must contain numbers,symbols and characters","Validate Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textPassword.Focus();
                return;
            }
            else  if (!hasDigit || !hasLetter || !hasSymbol)
            {
                MessageBox.Show("The input must be contain numbers ,symbols and characters", "Validate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPassword.Focus();
                return;
            }
            else if (hasDigit && !hasLetter && !hasSymbol)
            {
                MessageBox.Show("The input must be contain numbers ,symbos and characters", "Validate Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPassword.Focus();
                return;
            }
            //Validate national
            if (textNational.TextLength< 10)
            {
                MessageBox.Show("National  must be at Least 10 characters!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textNational.Focus();
                return;
            }
            //Validate Gender
            if (!radioMale.Checked && !radioFemale.Checked && !radioOther.Checked)
            {
                MessageBox.Show("Please Selected a gender!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
                return;
            }

            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void textPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
