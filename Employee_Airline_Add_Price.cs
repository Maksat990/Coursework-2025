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
    public partial class Employee_Airline_Add_Price : Form
    {
        private int id_airline = 0;
        private int id_ticket = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";

        public Employee_Airline_Add_Price()
        {
            InitializeComponent();
        }
        public void Get_ID(int id)
        {
            id_airline = id;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string queryemployer = "Select id_ticket from Tickets where flight=@fl";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@fl", comboBox1.SelectedItem.ToString());

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_ticket = (int)reader["id_ticket"];

            }
            conn.Close();
            conn.Open();
            MySqlCommand command2 = new MySqlCommand("insert into Sales(price, count, id_ticket, id_airline) values(@pr,@count,@id,@id_2)", conn);
            
            command2.Parameters.AddWithValue("@pr", decimal.Parse(textBox3.Text));
            command2.Parameters.AddWithValue("@count", int.Parse(textBox2.Text));
            command2.Parameters.AddWithValue("@id", id_ticket);
            command2.Parameters.AddWithValue("@id_2", id_airline);
            command2.ExecuteNonQuery();
            conn.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void Employee_Airline_Add_Price_Load(object sender, EventArgs e)
        {
            string queryemployer = "Select flight from Tickets where id_airline=@id";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@id", id_airline);
           
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["flight"].ToString());
                
            }
            conn.Close();


        }
    }
}
