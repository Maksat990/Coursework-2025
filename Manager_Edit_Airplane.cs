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
    public partial class Manager_Edit_Airplane : Form
    {
        private int id_airplane = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        public Manager_Edit_Airplane()
        {
            InitializeComponent();
        }
        public void Get_ID(int id)
        {
            id_airplane = id;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand("Update Airplane set model_of_airplane = @name, type_airplane = @type,capacity =@cap where id_airplane=@id", conn);
            command.Parameters.AddWithValue("@name", textBox1.Text);
            command.Parameters.AddWithValue("@type", textBox2.Text);
            command.Parameters.AddWithValue("@cap", textBox3.Text);
            command.Parameters.AddWithValue("@id", id_airplane);
            command.ExecuteNonQuery();
            conn.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void Manager_Edit_Airplane_Load(object sender, EventArgs e)
        {
            string querymanager = "SELECT model_of_airplane,type_airplane, capacity from Airplane where id_airplane=@id";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@id", id_airplane);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["model_of_airplane"].ToString();
                textBox2.Text = reader["type_airplane"].ToString();
                textBox3.Text = reader["capacity"].ToString();    
            }
            conn.Close();
        }
    }
}
