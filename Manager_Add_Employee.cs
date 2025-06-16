
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

using MySql.Data.MySqlClient;

namespace Coursework
{
    public partial class Manager_Add_Employee : Form
    {
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        private int id_manager = 0;

        public Manager_Add_Employee()
        {
            InitializeComponent();
        }
        public void Get_ID(int id)
        {
            id_manager = id;
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command=new MySqlCommand("insert into Employees(name,surname,patronymic,login,password,role,id_manager) values(@name,@surname,@patronymic,@login,@password,@role,@id)",conn);
            command.Parameters.AddWithValue("@name", textBox1.Text);
            command.Parameters.AddWithValue("@surname", textBox2.Text);
            command.Parameters.AddWithValue("@patronymic", textBox3.Text);
            command.Parameters.AddWithValue("@login", textBox4.Text);
            command.Parameters.AddWithValue("@password", textBox5.Text);
            command.Parameters.AddWithValue("@role", textBox6.Text);
            command.Parameters.AddWithValue("@id", id_manager);
            command.ExecuteNonQuery();
            conn.Close();
            this.DialogResult= DialogResult.OK;
        }
    }
}
