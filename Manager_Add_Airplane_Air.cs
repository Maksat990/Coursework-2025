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

namespace Coursework
{
    public partial class Manager_Add_Airplane_Air : Form
    {
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        private int id_manager = 0;
        public Manager_Add_Airplane_Air()
        {
            InitializeComponent();
        }

        public void Get_ID(int id)
        {
            id_manager = id;
        }
        private void button_ok_Click(object sender, EventArgs e)
        {
            int id_airplane = 0;
            int id_airline = 0;
            bool is_av = false;
            string querymanager = "SELECT  id_airline  FROM Airlines where name_of_company=@name";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@name", comboBox2.SelectedItem.ToString());
            

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_airline = (int)reader["id_airline"];    
            }
            conn.Close();
            string querymanager2 = "SELECT  id_airplane  FROM Airplane where model_of_airplane=@name";
         
            conn.Open();
            MySqlCommand command2 = new MySqlCommand(querymanager2, conn);
            command2.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());


            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                id_airplane = (int)reader2["id_airplane"];
            }
            conn.Close();
            string querymanager3 = "insert into Airlines_airplanes(id_airline, id_airplane) values(@id,@id_2)";
            conn.Open();
            MySqlCommand command3 = new MySqlCommand(querymanager3, conn);
            command3.Parameters.AddWithValue("@id", id_airline);
            command3.Parameters.AddWithValue("@id_2", id_airplane);
            command3.ExecuteNonQuery();
            conn.Close();
            string querymanager4 = "update airplane set is_available=@av where id_airplane=@id";
            conn.Open();
            MySqlCommand command4 = new MySqlCommand(querymanager4, conn);
            command4.Parameters.AddWithValue("@av", is_av);
            command4.Parameters.AddWithValue("@id", id_airplane);
            command4.ExecuteNonQuery();
            conn.Close();
            this.DialogResult = DialogResult.OK;

        }

        private void Manager_Add_Airplane_Air_Load(object sender, EventArgs e)
        {
           
            string querymanager = "SELECT  name_of_company  FROM Airlines_manager join  Airlines  on Airlines.id_airline=Airlines_manager.id_airline  where id_manager=@id";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@id", id_manager);

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["name_of_company"].ToString());
            }
            conn.Close();
            string querymanager2 = "SELECT  model_of_airplane  FROM Airplane where is_available=true";

            conn.Open();
            MySqlCommand command2 = new MySqlCommand(querymanager2, conn);
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox1.Items.Add(reader2["model_of_airplane"]); 
            }
            conn.Close();

        }
    }
}
