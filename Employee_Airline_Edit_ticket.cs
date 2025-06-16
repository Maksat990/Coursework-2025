using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Notice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Coursework
{
    public partial class Employee_Airline_Edit_ticket : Form
    {
        private int id_airline = 0;
        private int id_ticket = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";

        public Employee_Airline_Edit_ticket()
        {
            InitializeComponent();
        }
        public void Get_ID(int id, int id_tic)
        {
            id_airline = id;
            id_ticket = id_tic;
        }
        private void button_add_Click(object sender, EventArgs e)
        {

            string queryemployer = "Update Tickets set flight=@fl, from_=@fr, to_=@to, gate=@gate,class=@cl,time_departure=@time,time_arrival=@time_2 where id_ticket=@id and id_airline=@id_2";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@fl", textBox1.Text);
            command.Parameters.AddWithValue("@fr", textBox2.Text);
            command.Parameters.AddWithValue("@to", textBox3.Text);
            command.Parameters.AddWithValue("@gate", textBox4.Text);
            command.Parameters.AddWithValue("@cl", comboBox1.SelectedItem.ToString());
            command.Parameters.AddWithValue("@time", dateTimePicker1.Value);
            command.Parameters.AddWithValue("@time_2", dateTimePicker2.Value);
            command.Parameters.AddWithValue("@id", id_ticket);
            command.Parameters.AddWithValue("@id_2", id_airline);
            command.ExecuteNonQuery();
            conn.Close();
            this.DialogResult= DialogResult.OK;
        }

        private void Employee_Airline_Edit_ticketcs_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy HH:mm";

            string queryemployer = "Select flight, from_, to_, gate,class,time_departure,time_arrival from Tickets where id_ticket=@id and id_airline=@id_2";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@id", id_ticket);
            command.Parameters.AddWithValue("@id_2", id_airline);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["flight"].ToString();
                textBox2.Text = reader["from_"].ToString();
                textBox3.Text = reader["to_"].ToString();
                textBox4.Text = reader["gate"].ToString();
                comboBox1.SelectedItem = reader["class"].ToString();
                dateTimePicker1.Value = (DateTime)reader["time_departure"];
                dateTimePicker2.Value = (DateTime)reader["time_arrival"];
            }
            conn.Close();

        }
    }
}
