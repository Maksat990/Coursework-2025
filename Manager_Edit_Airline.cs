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
    public partial class Manager_Edit_Airline : Form
    {
        private int id_manager = 0;
        private int id_airline = 0;
        private string path = @"D:\МТО\airline.png";
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        public Manager_Edit_Airline()
        {
            InitializeComponent();
        }
        public void Get_ID(int id_man, int id_airline)
        {
            id_manager = id_man;
            this.id_airline = id_airline;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                path = openFile.FileName;
                pictureBox1.Image = Image.FromFile(path);
            }

        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand("Update Airlines set name_of_company = @name,logotype =@logo where id_airline=@id",conn);
            command.Parameters.AddWithValue("@name", textBox2.Text);
            command.Parameters.AddWithValue("@logo", path);
            command.Parameters.AddWithValue("@id", id_airline);
            command.ExecuteNonQuery();
            conn.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void Manager_Edit_Airline_Load(object sender, EventArgs e)
        {
            string querymanager = "SELECT name_of_company,logotype from Airlines_manager join Manager on Airlines_manager.id_manager=Manager.id_manager join Airlines on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id and Airlines_manager.id_airline=@id_2";            
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@id", id_manager);
            command.Parameters.AddWithValue("@id_2", id_airline);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["name_of_company"].ToString();
                pictureBox1.Image = Image.FromFile(reader["logotype"].ToString());
            }
            conn.Close();

        }
    }
}
