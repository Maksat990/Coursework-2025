using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Manager_Edit_Employee : Form
    {
        private int id_manager = 0;
        private int id_employee = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";


        public Manager_Edit_Employee()
        {
            InitializeComponent();
        }
        public void Get_ID(int id)
        {
            id_manager = id;
        }
        public void Get_id(int id)
        {
            id_employee = id;
        }
        private void button_ok_Click(object sender, EventArgs e)
        {
            string querymanager = "Update Employees set name=@name,surname=@surname,patronymic=@patronymic,login=@login, password=@password where id_employee=@id";
            MySqlConnection conn=new MySqlConnection(connection);
            conn.Open();
            MySqlCommand commandUpdate = new MySqlCommand(querymanager);
            commandUpdate.Parameters.AddWithValue("@name", textBox1.Text);
            commandUpdate.Parameters.AddWithValue("@surname", textBox2.Text);
            commandUpdate.Parameters.AddWithValue("@patronymic", textBox3.Text);
            commandUpdate.Parameters.AddWithValue("@login", textBox4.Text);
            commandUpdate.Parameters.AddWithValue("@password", textBox5.Text);
            commandUpdate.Parameters.AddWithValue("@id",id_employee);
            commandUpdate.Connection = conn;
            commandUpdate.ExecuteNonQuery();
            conn.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void Manager_Edit_Employee_Load(object sender, EventArgs e)
        {
            string querymanager = "SELECT name,surname,patronymic,login,password FROM Employees where id_manager=@id and  id_employee=@id_emp";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@id", id_manager);
            command.Parameters.AddWithValue("@id_emp", id_employee);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader["name"].ToString();
                textBox2.Text = reader["surname"].ToString();
                textBox3.Text = reader["patronymic"].ToString();
                textBox4.Text = reader["login"].ToString();
                textBox5.Text = reader["password"].ToString();
            }
            conn.Close();
        }
    }
}
