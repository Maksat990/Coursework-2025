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
    public partial class RegistrationForm : Form
    {
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        private int id_manager = 0;
        private int id_employer = 0;
      
        public static bool is_manager = false;
        public static bool is_employer = false;
        public static bool is_passanger = false;

        private bool status_employer_airline=false;
        private bool status_employer_registration = false;
        private bool status_employer_migration = false;
        private bool status_employer_dispatcher = false;
       

        private bool is_checked_log_pass=false;
       
        public RegistrationForm()
        {
            InitializeComponent();
        }
        private void button_enter_Click(object sender, EventArgs e)
        {
            string login = textBox_log.Text;
            string password = textBox_pass.Text;

            if (CheckManagerCredentials(login, password))
            {
                OpenManagerForm();
            }
            else if (CheckEmployeeCredentials(login, password, out string role))
            {
                OpenEmployeeForm(role);
            }
            else
            {
                ShowLoginError();
            }

            ResetLoginState();
        }

        private bool CheckManagerCredentials(string login, string password)
        {
            string query = "SELECT id_manager FROM Manager WHERE login = @login AND password = @password";

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    id_manager = Convert.ToInt32(result);
                    return true;
                }
            }
            return false;
        }

        private bool CheckEmployeeCredentials(string login, string password, out string role)
        {
            string query = "SELECT id_employee, role FROM Employees WHERE login = @login AND password = @password";
            role = null;

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id_employer = reader.GetInt32("id_employee");
                        role = reader.GetString("role");
                        return true;
                    }
                }
            }
            return false;
        }

        private void OpenManagerForm()
        {
            ManagerForm manager = new ManagerForm();
            manager.Get_ID(id_manager);
            manager.Show();
        }

        private void OpenEmployeeForm(string role)
        {
            switch (role)
            {
                case "авиакомпания":
                    Employee_Airline employer = new Employee_Airline();
                    employer.Get_ID(id_employer);
                    employer.Show();
                    break;

                case "диспетчер":
                    Employee_Dispetcher employer2 = new Employee_Dispetcher();
                    employer2.Get_ID(id_employer);
                    employer2.Show();
                    break;
            }
        }

        private void ShowLoginError()
        {
            MessageBox.Show("Неверный логин или пароль");
        }

        private void ResetLoginState()
        {
            id_manager = 0;
            id_employer = 0;
        }














        /*
        private void button_enter_Click(object sender, EventArgs e)
        {
            string check_log = this.textBox_log.Text;
            string check_pass = this.textBox_pass.Text;
            string querymanager = "SELECT id_manager, login, password FROM Manager";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string dbLogin = reader["login"].ToString();
                string dbPass = reader["password"].ToString();
               
               
                if (dbLogin == check_log && dbPass == check_pass)
                {
                    this.id_manager = (int)reader["id_manager"];
                    is_manager = true;
                    is_passanger = false;
                    is_employer = false;
                    is_checked_log_pass = true;
                }
                
            }
            conn.Close();
            string queryemployee = "SELECT id_employee, role,  login, password FROM Employees";
            conn.Open();
            MySqlCommand command2 = new MySqlCommand(queryemployee, conn);
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                string dbLogin = reader2["login"].ToString();
                string dbPass = reader2["password"].ToString();
                string role = reader2["role"].ToString();
               
                if(role=="авиакомпания")
                {
                    if (dbLogin == check_log && dbPass == check_pass)
                    {
                        this.id_employer = (int)reader2["id_employee"];
                        is_manager = false;
                        is_passanger = false;
                        is_employer = true;
                        status_employer_airline = true;
                        status_employer_dispatcher = false;
                        status_employer_migration = false;
                        status_employer_registration = false;
                        is_checked_log_pass = true;
                    }
                }
                if(role=="диспетчер")
                {
                    if (dbLogin == check_log && dbPass == check_pass)
                    {
                        this.id_employer = (int)reader2["id_employee"];
                        is_manager = false;
                        is_passanger = false;
                        is_employer = true;
                        status_employer_airline = false;
                        status_employer_dispatcher = true;
                        status_employer_migration = false;
                        status_employer_registration = false;
                        is_checked_log_pass = true;
                    }
                }

            }
            conn.Close();


            if (is_manager)
            {
                ManagerForm manager = new ManagerForm();
                manager.Get_ID(id_manager);
                manager.Show();
            }
            if(is_employer && status_employer_airline)
            {
                Employee_Airline employer = new Employee_Airline();
                employer.Get_ID(id_employer);
                employer.Show();
            }
            if (is_employer && status_employer_dispatcher)
            { 
                Employee_Dispetcher employer = new Employee_Dispetcher();
                employer.Get_ID(id_employer);
                employer.Show();
            }

            if (!is_checked_log_pass)
            {
                MessageBox.Show("Не существует такого пароля и логина");
            }

            is_checked_log_pass = false;
            is_manager = false;
            is_employer = false;
            is_passanger = false;
            status_employer_airline = false;
            status_employer_dispatcher = false;
            status_employer_migration = false;
            status_employer_registration = false;
         
        }

        */

        private void button_reg_Click(object sender, EventArgs e)
        {



        }

        
    }
}





