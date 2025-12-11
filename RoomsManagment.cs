using HotelBookingSystem.Data;
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
using System.Windows.Forms.VisualStyles;

namespace HotelBookingSystem
{
    public partial class RoomsManagment : UserControl
    {
        public RoomsManagment()
        {
            InitializeComponent();
        }
        private void LoadAllRooms()
        {
            string connStr = @"Data Source=.;Initial Catalog=prohoteldb;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Rooms";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void comboBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboBox2.SelectedItem.ToString();

            if (selectedType == "Single")
            {
                LoadRoomsByType("Single");
            }
            else if (selectedType == "Suite")
            {
                LoadRoomsByType("Suite");
            }
        }

        private void LoadRoomsByType(string type)
        {
            string connStr = @"Data Source=.;Initial Catalog=prohoteldb;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT * FROM Room WHERE Type = @type";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@type", type);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = comboBox1.SelectedItem.ToString();

            if (selectedStatus == "Reserved")
            {
                LoadRoomsByStatus("Reserved");
            }
            else if (selectedStatus == "Available ")
            {
                LoadRoomsByStatus("Available");
            }
        }

        private void LoadRoomsByStatus(string status)
        {
            string connStr = @"Data Source=.;Initial Catalog=prohoteldb;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT * FROM Room WHERE Status = @status";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@status", status);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void LoadRooms()
        {
            try
            {
                // نص الاتصال – عدّليه حسب إعدادات جهازك وقاعدة البيانات
                string connStr = @"Data Source=.;Initial Catalog=prohoteldb;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // الاستعلام لعرض جدول الغرف
                    string query = "SELECT * FROM Room";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;   // ربط الجدول بالـ DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء عرض بيانات الغرف: " + ex.Message);
            }
        }

        private void RoomsManagment_Load(object sender, EventArgs e)
        {
          
           



        LoadRooms();

            using (var db = new HotelContext())
            {
                var rooms = db.Room.ToList();
                dataGridView1.DataSource = rooms;
            }

            // تحسين أسماء الأعمدة للعرض
            dataGridView1.Columns["RoomId"].HeaderText = "RoomId";
            dataGridView1.Columns["RoomNumber"].HeaderText = "RoomNumber";
            dataGridView1.Columns["Type"].HeaderText = "Type";
            dataGridView1.Columns["Price"].HeaderText = "Price";
            dataGridView1.Columns["Status"].HeaderText = "Status";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedStatus = comboBox1.SelectedItem.ToString();
            LoadRoomsByStatus(selectedStatus);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboBox2.SelectedItem.ToString();
            LoadRoomsByType(selectedType);
        }
    }
}

