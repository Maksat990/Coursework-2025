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
    public partial class Employee_Dispetcher_Flight_Add : Form
    {
        private int id_employee = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        public Employee_Dispetcher_Flight_Add()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm";

            label2.Location = new Point(14,298);

            if(Employee_Dispetcher.is_exit==true)
            {
                label6.Visible = true;
                label2.Visible = false;

            }
            if(Employee_Dispetcher.is_enter==true)
            {
                label6.Visible = false;
                label2.Visible = true;
            }

        }
        public void Get_ID(int id)
        {
            id_employee = id;
        }
        private void button_add_Click(object sender, EventArgs e)
        {

            if (Employee_Dispetcher.is_exit == true)
            {
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand command = new MySqlCommand("insert into Flights(flight,departure_location,departure_time,departure_terminal,arrival_location,arrival_time,id_employee) values(@fl,@dp_l,@dp_t,@dp_ter,@arr,@arr_t,@id)", conn);
                command.Parameters.AddWithValue("@fl", textBox1.Text);
                command.Parameters.AddWithValue("@dp_l", textBox2.Text);
                command.Parameters.AddWithValue("@dp_t", dateTimePicker1.Value);
                command.Parameters.AddWithValue("@dp_ter", textBox4.Text);
                command.Parameters.AddWithValue("@arr", textBox3.Text);
                command.Parameters.AddWithValue("@arr_t", dateTimePicker2.Value);
                command.Parameters.AddWithValue("@id", id_employee);
                command.ExecuteNonQuery();
                conn.Close();
                this.DialogResult = DialogResult.OK;
            }
            if(Employee_Dispetcher.is_enter==true)
            {
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                MySqlCommand command = new MySqlCommand("insert into Flights(flight,departure_location,departure_time,arrival_terminal,arrival_location,arrival_time,id_employee) values(@fl,@dp_l,@dp_t,@dp_ter,@arr,@arr_t,@id)", conn);
                command.Parameters.AddWithValue("@fl", textBox1.Text);
                command.Parameters.AddWithValue("@dp_l", textBox2.Text);
                command.Parameters.AddWithValue("@dp_t", dateTimePicker1.Value);
                command.Parameters.AddWithValue("@dp_ter", textBox4.Text);
                command.Parameters.AddWithValue("@arr", textBox3.Text);
                command.Parameters.AddWithValue("@arr_t", dateTimePicker2.Value);
                command.Parameters.AddWithValue("@id", id_employee);
                command.ExecuteNonQuery();
                conn.Close();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
