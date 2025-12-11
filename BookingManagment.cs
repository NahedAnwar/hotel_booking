using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelBookingSystem
{
    public partial class BookingManagment : UserControl
    {
        public BookingManagment()
        {
            InitializeComponent();
        }
        private void LoadReservations()
        {
            using (var db = new HotelContext())
            {
                dataGridView1.DataSource = db.Users.ToList();
            }
        }

        private void BookingManagment_Load(object sender, EventArgs e)
        {
            LoadReservations();
           


            try
            {
                // نص الاتصال – عدّله حسب جهازك
                string connStr = @"Data Source=.;Initial Catalog=prohoteldb;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT * FROM Reservations";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;   // ربط الجدول بالـ DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء عرض البيانات: " + ex.Message);
            }
        }
          


        

        private void button1_Click(object sender, EventArgs e)
        {
          
            using (var db = new HotelContext())
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue; // نتجاهل الصف الفارغ

                    var reservation = new Reservation
                    {
                      
                         ClientId= Convert.ToInt32(row.Cells["ClientId"].Value),
                     
                        RoomNumber = Convert.ToInt32(row.Cells["RoomNumber"].Value),
                        PersonsCount = Convert.ToInt32(row.Cells["PersonsCount"].Value),
                        StayDays = Convert.ToInt32(row.Cells["StayDays"].Value),
                        BookingDate = Convert.ToDateTime(row.Cells["BookingDate"].Value),
                        CheckInDate = Convert.ToDateTime(row.Cells["CheckInDate"].Value),
                        CheckOutDate = Convert.ToDateTime(row.Cells["CheckOutDate"].Value)
                    };

                    db.Reservations.Add(reservation);
                }

                db.SaveChanges();
                MessageBox.Show("تمت إضافة الحجوزات بنجاح");
            }

            LoadReservations(); // دالة تعرض الحجوزات بعد الإضافة
        }


           
        

        private void button2_Click(object sender, EventArgs e)
        {


         
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("لم يتم تحديد الحذف");
                return;
            }

            // الحصول على ID الحجز المحدد
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            using (var db = new HotelContext())
            {
                var reservation = db.Reservations.Find(id);

                if (reservation != null)
                {
                    db.Reservations.Remove(reservation);
                    db.SaveChanges();
                    MessageBox.Show("تم حذف الحجز بنجاح");
                }
                else
                {
                    MessageBox.Show("الحجز غير موجود");
                }
            }

            // تحديث العرض
            LoadReservations(); // تأكدي أن هذه الدالة تعرض الحجوزات
        }

    

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
    }
    
    
