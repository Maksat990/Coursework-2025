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
    public partial class Manager_Add_Emplyeer_Air : Form
    {
        private int id_employer = 0;
        private int id_manager = 0;
        private int id_airline = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        public Manager_Add_Emplyeer_Air()
        {
            InitializeComponent();
        }
        public void Get_ID(int id_man)
        {
            id_manager=id_man;     
        }
        private void button_ok_Click(object sender, EventArgs e)
        {
            int count = 0;
            string name = "";
            string surname = "";
            string patronymic = "";
            string login = "";
            string[] parts = comboBox1.SelectedItem.ToString().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if(parts.Length>3)
            {
                name= parts[0];
                surname = parts[1];
                patronymic = parts[2];
                login=parts[3];
            }
            if(parts.Length==3)
            {
                name=parts[0];
                surname = parts[1];
                login = parts[2];
                patronymic = null;
            }
            string name_air = comboBox2.SelectedItem.ToString();
            string querymanager = "SELECT  id_employee  FROM Employees   where name=@name and surname=@surname and patronymic=@pat and  login=@log";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@surname", surname);
            command.Parameters.AddWithValue("@pat", patronymic);
            command.Parameters.AddWithValue("@log",login);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_employer = (int)reader["id_employee"];                
            }
            conn.Close();
            if(patronymic==null)
            {
                string querymanager6 = "SELECT  id_employee  FROM Employees   where name=@name and surname=@surname and patronymic is NULL and  login=@log";
                
                conn.Open();
                MySqlCommand command6 = new MySqlCommand(querymanager6, conn);
                command6.Parameters.AddWithValue("@name", name);
                command6.Parameters.AddWithValue("@surname", surname);
                command6.Parameters.AddWithValue("@pat", patronymic);
                command6.Parameters.AddWithValue("@log", login);
                MySqlDataReader reader6 = command6.ExecuteReader();
                while (reader6.Read())
                {
                    id_employer = (int)reader6["id_employee"];
                }
                conn.Close();
            }
            string querymanager2 = "SELECT  id_airline  FROM Airlines   where name_of_company=@name";
            conn.Open();
            MySqlCommand command2 = new MySqlCommand(querymanager2, conn);
            command2.Parameters.AddWithValue("@name", name_air);
            
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                id_airline = (int)reader2["id_airline"];
            }
            conn.Close();
            string querymanager3 = "insert into Airlines_employees(id_airline, id_employee) values(@id,@id_2)";
            conn.Open();
            MySqlCommand command3 = new MySqlCommand(querymanager3, conn);
            command3.Parameters.AddWithValue("@id", id_airline);
            command3.Parameters.AddWithValue("@id_2", id_employer);
            command3.ExecuteNonQuery();
            conn.Close();
            string querymanager4 = "select count(id_employee) as employee_count from Airlines_employees group by id_airline having id_airline=@id ";
            conn.Open();
            MySqlCommand command4 = new MySqlCommand(querymanager4, conn);
            command4.Parameters.AddWithValue("@id", id_airline);
            MySqlDataReader reader3 = command4.ExecuteReader();
            while(reader3.Read())
            {
                if(!reader3.IsDBNull(0))
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

        private void Manager_Add_Emplyeer_Air_Load(object sender, EventArgs e)
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
            string querymanager2 = "SELECT  name, surname, patronymic, login  FROM Employees  where id_manager=@id";
            conn.Open();
            MySqlCommand command2 = new MySqlCommand(querymanager2, conn);
            command2.Parameters.AddWithValue("@id", id_manager);
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox1.Items.Add(reader2["name"].ToString()+ " " + reader2["surname"].ToString() + " " + reader2["patronymic"].ToString() + " " + reader2["login"].ToString());
            }
            conn.Close();

        }
    }
}
