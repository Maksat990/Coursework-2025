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
    public partial class Manager_Add_Airline : Form
    {
        private int id_manager = 0;
        private int id_airline = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        private string path = @"D:\МТО\airline.png";

        public Manager_Add_Airline()
        {
            InitializeComponent();
        }
        public void Get_Id(int id)
        {
            id_manager = id;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand("insert into Airlines(name_of_company,logotype) values(@name,@logo)", conn);
            command.Parameters.AddWithValue("@name", textBox1.Text);
            command.Parameters.AddWithValue("@logo", path);
            command.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            MySqlCommand command2 = new MySqlCommand("Select id_airline From Airlines where name_of_company=@name", conn);
            command2.Parameters.AddWithValue("@name", textBox1.Text);
            MySqlDataReader reader = command2.ExecuteReader();
            while (reader.Read())
            {
                id_airline = (int)reader["id_airline"];
            }
            conn.Close();
            conn.Open();
            MySqlCommand command3 = new MySqlCommand("insert into Airlines_manager(id_manager,id_airline) values(@id,@id_2)", conn);
            command3.Parameters.AddWithValue("@id", id_manager);
            command3.Parameters.AddWithValue("@id_2", id_airline);
            command3.ExecuteNonQuery();
            conn.Close();

            this.DialogResult = DialogResult.OK;
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
    }
}
