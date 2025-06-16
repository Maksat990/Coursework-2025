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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coursework
{
    public partial class Manager_Edit_Employeer_Air : Form
    {
        private int id_employer = 0;
        private int id_manager = 0;
        private int id_airline = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";

        public Manager_Edit_Employeer_Air()
        {
            InitializeComponent();
        }
        public void Get_ID(int id_man, int id_emp, int id_air)
        {
            id_manager = id_man;
            id_employer = id_emp;
            id_airline = id_air;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            int id_air = 0;
            int count = 0;
            string queryselect = "Select id_airline from Airlines where name_of_company=@name";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand commandSelect = new MySqlCommand(queryselect,conn);
            commandSelect.Parameters.AddWithValue("@name", comboBox2.SelectedItem.ToString());
            MySqlDataReader reader = commandSelect.ExecuteReader();
            while(reader.Read())
            {
                id_air=(int)reader["id_airline"];
            }
            conn.Close();

            string querymanager = "Update Airlines_employees set id_airline=@id  where id_airline=@id_2 and id_employee=@id_emp";
           
            conn.Open();
            MySqlCommand commandUpdate = new MySqlCommand(querymanager,conn);
            commandUpdate.Parameters.AddWithValue("@id", id_air);
            commandUpdate.Parameters.AddWithValue("@id_2", id_airline);
            commandUpdate.Parameters.AddWithValue("@id_emp", id_employer);
            commandUpdate.Connection = conn;
            commandUpdate.ExecuteNonQuery();
            conn.Close();

            string querymanager2 = "select count(id_employee) as employee_count from Airlines_employees group by id_airline having id_airline=@id ";
            conn.Open();
            MySqlCommand command2 = new MySqlCommand(querymanager2, conn);
            command2.Parameters.AddWithValue("@id", id_air);
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                if (!reader2.IsDBNull(0))
                    count = reader2.GetInt32(0);
            }
            conn.Close();
            string querymanager3 = "Update  Airlines set space=@count where id_airline=@id";
            conn.Open();
            MySqlCommand command3 = new MySqlCommand(querymanager3, conn);
            command3.Parameters.AddWithValue("@count", count);
            command3.Parameters.AddWithValue("@id", id_air);
            command3.ExecuteNonQuery();
            conn.Close();
            string querymanager4 = "select count(id_employee) as employee_count from Airlines_employees group by id_airline having id_airline=@id ";
            count = 0;
            conn.Open();
            MySqlCommand command4 = new MySqlCommand(querymanager4, conn);
            command4.Parameters.AddWithValue("@id", id_airline);
            MySqlDataReader reader3 = command4.ExecuteReader();
            while (reader3.Read())
            {
                if (!reader3.IsDBNull(0))
                    count = reader3.GetInt32(0);
            }
            conn.Close();
            string querymanager5 = "Update  Airlines set space=@count where id_airline=@id";
            conn.Open();
            MySqlCommand command5 = new MySqlCommand(querymanager5, conn);
            command5.Parameters.AddWithValue("@count", count);
            command5.Parameters.AddWithValue("@id", id_airline);
            command5.ExecuteNonQuery();
            conn.Close();
            this.DialogResult = DialogResult.OK;

        }

        private void Manager_Edit_Employeer_Air_Load(object sender, EventArgs e)
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
           
            string querymanager2 = "SELECT  name, surname, patronymic, login  FROM Employees  where id_manager=@id and id_employee=@id_emp";
            conn.Open();
            MySqlCommand command2 = new MySqlCommand(querymanager2, conn);
            command2.Parameters.AddWithValue("@id", id_manager);
            command2.Parameters.AddWithValue("@id_emp", id_employer);
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox1.Items.Add(reader2["name"].ToString() + " " + reader2["surname"].ToString() + " " + reader2["patronymic"].ToString() + " " + reader2["login"].ToString());
                comboBox1.SelectedItem = reader2["name"].ToString() + " " + reader2["surname"].ToString() + " " + reader2["patronymic"].ToString() + " " + reader2["login"].ToString();
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
