using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HotelBookingSystem
{
    public partial class CustomerManagment : UserControl
    {
        public CustomerManagment()
        {
            InitializeComponent();
        }

        SqlDataAdapter da;
        DataTable dt;
        private void LoadUsers()
        {
           


            string connStr = @"Data Source=.;Initial Catalog=prohoteldb;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                da = new SqlDataAdapter("SELECT * FROM Users", conn);

                // توليد أوامر Insert/Update/Delete تلقائيًا
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // السماح بالكتابة
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.ReadOnly = false;
            }
        }

        

       



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CustomerManagment_Load_1(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            using (var db = new HotelContext())
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue; // نتجاهل الصف الفارغ

                    var user = new UserModel
                    {
                        Name = row.Cells["Name"].Value?.ToString(),
                        Email = row.Cells["Email"].Value?.ToString(),
                        Phone = row.Cells["Phone"].Value?.ToString(),
                        Password = row.Cells["Password"].Value?.ToString(),
                        Role = row.Cells["Role"].Value?.ToString(),
                        Gender = row.Cells["Gender"].Value?.ToString(),
                        NationalId = row.Cells["NationalID"].Value?.ToString()
                    };

                    db.Users.Add(user);
                }

                db.SaveChanges();
                MessageBox.Show("✅ تمت إضافة المستخدمين بنجاح");
            }

            LoadUsers(); // دالة تعرض المستخدمين بعد الإضافة
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            using (var db = new HotelContext())
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue; // نتجاهل الصف الفارغ

                    // الحصول على الـ Id للمستخدم (مفتاح أساسي)
                    int userId = Convert.ToInt32(row.Cells["Id"].Value);

                    // البحث عن المستخدم في قاعدة البيانات
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);

                    if (user != null)
                    {
                        // تحديث بياناته من الـ DataGridView
                        user.Name = row.Cells["Name"].Value?.ToString();
                        user.Email = row.Cells["Email"].Value?.ToString();
                        user.Phone = row.Cells["Phone"].Value?.ToString();
                        user.Password = row.Cells["Password"].Value?.ToString();
                        user.Role = row.Cells["Role"].Value?.ToString();
                        user.Gender = row.Cells["Gender"].Value?.ToString();
                        user.NationalId = row.Cells["NationalID"].Value?.ToString();
                    }
                }

                db.SaveChanges();
                MessageBox.Show("✅ تم تعديل بيانات المستخدمين بنجاح");
            }

            LoadUsers(); // إعادة تحميل البيانات بعد التعديل
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // الحصول على الصف المحدد
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // استخراج الـ Id من العمود (تأكدي أن العمود اسمه "Id")
                int userId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                using (var db = new HotelContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == userId);

                    if (user != null)
                    {
                        db.Users.Remove(user);
                        db.SaveChanges();

                        MessageBox.Show("✅ تم حذف العميل بنجاح");

                        // إعادة تحميل البيانات بعد الحذف
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("❌ لم يتم العثور على العميل");
                    }
                }
            }
            else
            {
                MessageBox.Show("⚠️ الرجاء تحديد صف لحذفه");
            }
        

    }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
         
            using (var db = new HotelContext())
            {
                string searchText = txtSearch.Text.Trim();

                // إذا كان فارغ، نعرض كل العملاء
                if (string.IsNullOrEmpty(searchText))
                {
                    dataGridView1.DataSource = db.Users.ToList();
                }
                else
                {
                    // فلترة حسب الاسم
                    var result = db.Users
                                   .Where(u => u.Name.Contains(searchText))
                                   .ToList();

                    dataGridView1.DataSource = result;
                }
            }
        }

    
}
}




