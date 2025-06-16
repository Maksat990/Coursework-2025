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

        
    }
}





