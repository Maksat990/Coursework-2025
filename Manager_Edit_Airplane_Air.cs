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
    public partial class Manager_Edit_Airplane_Air : Form
    {
        private int id_airline = 0;
        private int id_airplane = 0;
        private int id_manager=0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        public Manager_Edit_Airplane_Air()
        {
            InitializeComponent();
        }
        public void Get_ID(int manager,int airline, int airplane)
        {
            id_manager = manager;
            id_airline=airline;
            id_airplane=airplane;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            int id_air = 0;
            string queryselect = "Select id_airline from Airlines where name_of_company=@name";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand commandSelect = new MySqlCommand(queryselect, conn);
            commandSelect.Parameters.AddWithValue("@name", comboBox2.SelectedItem.ToString());
            MySqlDataReader reader = commandSelect.ExecuteReader();
            while (reader.Read())
            {
                id_air = (int)reader["id_airline"];
            }
            conn.Close();

            string querymanager = "Update Airlines_airplanes set id_airline=@id  where id_airline=@id_2 and id_airplane=@id_3";

            conn.Open();
            MySqlCommand commandUpdate = new MySqlCommand(querymanager, conn);
            commandUpdate.Parameters.AddWithValue("@id", id_air);
            commandUpdate.Parameters.AddWithValue("@id_2", id_airline);
            commandUpdate.Parameters.AddWithValue("@id_3", id_airplane);
            commandUpdate.Connection = conn;
            commandUpdate.ExecuteNonQuery();
            conn.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void Manager_Edit_Airplane_Air_Load(object sender, EventArgs e)
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

            string querymanager2 = "SELECT  model_of_airplane  FROM Airlines_airplanes  join Airplane on Airlines_airplanes.id_airplane=Airplane.id_airplane where Airlines_airplanes.id_airline=@id and Airlines_airplanes.id_airplane=@id_2 ";
            conn.Open();
            MySqlCommand command2 = new MySqlCommand(querymanager2, conn);
            command2.Parameters.AddWithValue("@id", id_airline);
            command2.Parameters.AddWithValue("@id_2", id_airplane);
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox1.Items.Add(reader2["model_of_airplane"].ToString());
                comboBox1.SelectedItem = reader2["model_of_airplane"].ToString();
            }
            conn.Close();
            string querymanager3 = "SELECT  name_of_company  FROM Airlines_manager join  Airlines  on Airlines.id_airline=Airlines_manager.id_airline  where id_manager=@id and Airlines_manager.id_airline=@id_air";
            conn.Open();
            MySqlCommand command3 = new MySqlCommand(querymanager3, conn);
            command3.Parameters.AddWithValue("@id", id_manager);
            command3.Parameters.AddWithValue("@id_air", id_airline);
            MySqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {

                comboBox2.SelectedItem = reader3["name_of_company"].ToString();

            }
            conn.Close();

        }
    }
}
