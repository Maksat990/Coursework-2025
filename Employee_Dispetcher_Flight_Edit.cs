using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coursework
{
    public partial class Employee_Dispetcher_Flight_Edit : Form
    {
        private int id_employee = 0;
        private int id_flight = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        public Employee_Dispetcher_Flight_Edit()
        {
            InitializeComponent();
        }
        public void Get_ID(int id_emp, int id_fl)
        {
            id_employee = id_emp;
            id_flight=id_fl;
        }

        private void Employee_Dispetcher_Flight_Edit_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm";
            label3.Location = new Point(14,298);

            if (Employee_Dispetcher.is_exit == true)
            {
                label6.Visible = true;
                label3.Visible = false;

                string queryemployee = "SELECT flight, departure_location, departure_time, departure_status, departure_terminal, arrival_location,arrival_time FROM Flights where id_employee=@id and id_flight=@id_2";
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand command = new MySqlCommand(queryemployee, conn);
                command.Parameters.AddWithValue("@id", id_employee);
                command.Parameters.AddWithValue("@id_2", id_flight);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader["flight"].ToString();
                    textBox2.Text = reader["departure_location"].ToString();
                    textBox3.Text = reader["arrival_location"].ToString();
                    textBox4.Text = reader["departure_terminal"].ToString();
                    textBox5.Text = reader["departure_status"].ToString();
                    dateTimePicker1.Value = (DateTime)reader["departure_time"];
                    dateTimePicker2.Value = (DateTime)reader["arrival_time"];
                }
                conn.Close();
            }
            if (Employee_Dispetcher.is_enter == true)
            {
                label3.Visible=true;
                label6.Visible = false;
                string queryemployee = "SELECT flight, departure_location, departure_time, arrival_status, arrival_terminal, arrival_location,arrival_time FROM Flights where id_employee=@id and id_flight=@id_2";
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand command = new MySqlCommand(queryemployee, conn);
                command.Parameters.AddWithValue("@id", id_employee);
                command.Parameters.AddWithValue("@id_2", id_flight);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader["flight"].ToString();
                    textBox2.Text = reader["departure_location"].ToString();
                    textBox3.Text = reader["arrival_location"].ToString();
                    textBox4.Text = reader["arrival_terminal"].ToString();
                    textBox5.Text = reader["arrival_status"].ToString();
                    dateTimePicker1.Value = (DateTime)reader["departure_time"];
                    dateTimePicker2.Value = (DateTime)reader["arrival_time"];
                }
                conn.Close();
            }

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (Employee_Dispetcher.is_exit == true)
            {
                string queryemployer = "Update Flights set flight=@fl, departure_location=@dp_l, departure_time=@time, departure_status=@st,departure_terminal=@ter,arrival_location=@arr,arrival_time=@time_2  where id_employee=@id and id_flight=@id_2";
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand command = new MySqlCommand(queryemployer, conn);
                command.Parameters.AddWithValue("@fl", textBox1.Text);
                command.Parameters.AddWithValue("@dp_l", textBox2.Text);
                command.Parameters.AddWithValue("@time", dateTimePicker1.Value);
                command.Parameters.AddWithValue("@st", textBox5.Text);
                command.Parameters.AddWithValue("@ter", textBox4.Text);
                command.Parameters.AddWithValue("@arr", textBox3.Text);
                command.Parameters.AddWithValue("@time_2", dateTimePicker2.Value);
                command.Parameters.AddWithValue("@id", id_employee);
                command.Parameters.AddWithValue("@id_2", id_flight);
                command.ExecuteNonQuery();
                conn.Close();
                this.DialogResult = DialogResult.OK;
            }
            if (Employee_Dispetcher.is_enter == true)
            {
                string queryemployer = "Update Flights set flight=@fl, departure_location=@dp_l, departure_time=@time, arrival_status=@st,arrival_location=@arr,arrival_time=@time_2,arrival_terminal=@ter  where id_employee=@id and id_flight=@id_2";
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand command = new MySqlCommand(queryemployer, conn);
                command.Parameters.AddWithValue("@fl", textBox1.Text);
                command.Parameters.AddWithValue("@dp_l", textBox2.Text);
                command.Parameters.AddWithValue("@time", dateTimePicker1.Value);
                command.Parameters.AddWithValue("@st", textBox5.Text);
                command.Parameters.AddWithValue("@arr", textBox3.Text);
                command.Parameters.AddWithValue("@time_2", dateTimePicker2.Value);
                command.Parameters.AddWithValue("@ter", textBox4.Text);
                command.Parameters.AddWithValue("@id", id_employee);
                command.Parameters.AddWithValue("@id_2", id_flight);
                command.ExecuteNonQuery();
                conn.Close();
                this.DialogResult = DialogResult.OK;
            }

        }
    }
}
