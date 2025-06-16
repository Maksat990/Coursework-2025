using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Employee_Airline_Add_ticket : Form
    {
        private int id_airline = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";

        public Employee_Airline_Add_ticket()
        {
            InitializeComponent();
        }
        public void Get_ID(int id_air)
        {
            id_airline = id_air;

        }

        private void button_add_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand("insert into Tickets(flight,from_,to_,gate,class,time_departure,time_arrival,id_airline) values(@name,@fr,@to,@gate,@class,@time,@time_2,@id)", conn);
            command.Parameters.AddWithValue("@name", textBox1.Text);
            command.Parameters.AddWithValue("@fr", textBox2.Text);
            command.Parameters.AddWithValue("@to", textBox3.Text);
            command.Parameters.AddWithValue("@gate", textBox4.Text);
            command.Parameters.AddWithValue("@class", comboBox1.SelectedItem.ToString());
            command.Parameters.AddWithValue("@time", dateTimePicker1.Value);
            command.Parameters.AddWithValue("@time_2", dateTimePicker2.Value);
            command.Parameters.AddWithValue("@id", id_airline);
            command.ExecuteNonQuery();
            conn.Close();
            this.DialogResult = DialogResult.OK;

        }

        private void Employee_Airline_Add_ticket_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker2.CustomFormat= "dd/MM/yyyy HH:mm";

        }
    }
}
