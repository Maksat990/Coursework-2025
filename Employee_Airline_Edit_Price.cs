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
    public partial class Employee_Airline_Edit_Price : Form
    {
        private int id_airline = 0;
        private int id_ticket = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";

        public Employee_Airline_Edit_Price()
        {
            InitializeComponent();
        }
        public void Get_ID(int id_air, int id_tick)
        {
            id_airline=id_air;
            id_ticket = id_tick;
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            string queryemployer = "Update Sales set price=@pr,count=@count where id_ticket=@id";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@pr", decimal.Parse(textBox3.Text));
            command.Parameters.AddWithValue("@count", int.Parse(textBox2.Text));
            command.Parameters.AddWithValue("@id", id_ticket);
            command.ExecuteNonQuery();
            conn.Close();
            this.DialogResult = DialogResult.OK;

        }

        private void Employee_Airline_Edit_Price_Load(object sender, EventArgs e)
        {
            string queryemployer = "Select flight from Tickets where id_airline=@id and  id_ticket=@id_2";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@id", id_airline);
            command.Parameters.AddWithValue("@id_2", id_ticket);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["flight"].ToString());
            }
            conn.Close();
            string queryemployer2 = "Select flight, price, count from Tickets join Sales on Tickets.id_ticket=Sales.id_ticket where Tickets.id_ticket=@id ";
          
            conn.Open();
            MySqlCommand command2 = new MySqlCommand(queryemployer2, conn);
            command2.Parameters.AddWithValue("@id", id_ticket);
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox1.SelectedItem = reader2["flight"].ToString();
                textBox2.Text = reader2["count"].ToString();
                textBox3.Text = reader2["price"].ToString();
            }
            conn.Close();



        }
    }
}
