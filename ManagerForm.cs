using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Coursework
{
    public partial class ManagerForm : Form
    {
        private int id_manager = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        private string path = "";
        private int id_employer = 0;
        private int id_airline = 0;
        private int id_airplane = 0;

     

        public ManagerForm()
        {
            InitializeComponent();

            panelProfile.Visible = false;
            panelProfile2.Visible = false;
            panelEmployees.Visible = false;
            panel_airlines.Visible = false;
            panel_plane.Visible = false;
            panel_air_emp.Visible = false;
            panel_air_plane.Visible = false;

            button_airlines.Visible = true;
            panel2.Visible = false;

            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;

          

        }

        public void Get_ID(int id)
        {
            id_manager= id;
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 64, 0);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 64, 0);
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView2.EnableHeadersVisualStyles = false;

            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;



            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 64, 0);
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView3.EnableHeadersVisualStyles = false;

            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView4.DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 64, 0);
            dataGridView4.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView4.EnableHeadersVisualStyles = false;

            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            
            dataGridView5.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView5.DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 64, 0);
            dataGridView5.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView5.EnableHeadersVisualStyles = false;

            dataGridView5.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            dataGridView5.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.Dock = DockStyle.Fill;
            dataGridView3.Dock = DockStyle.Fill;
            dataGridView4.Dock = DockStyle.Fill;
            dataGridView2.Dock = DockStyle.Fill;


            string querymanager = "SELECT name, surname, patronymic, login, password, data FROM Manager where id_manager=@id";
            
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@id", id_manager);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                label_name.Text = reader["name"].ToString();
                textBox1.Text = label_name.Text;
                label_surname.Text = reader["surname"].ToString();
                textBox2.Text = label_surname.Text;
                label_patronymic.Text = reader["patronymic"].ToString();
                textBox3.Text= label_patronymic.Text;
                label_login.Text = reader["login"].ToString();
                textBox4.Text = label_login.Text;
                label_password.Text = reader["password"].ToString();
                textBox5.Text = label_password.Text;
                pictureBoxprofile.Image = Image.FromFile(reader["data"].ToString());
                pictureBoxprofile2.Image= Image.FromFile(reader["data"].ToString());
                path = reader["data"].ToString();
            }
            conn.Close(); 
            
        }

        private void button_profile_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;

            button_employees.BackColor = Color.DarkSlateBlue;
            button_airlines.BackColor = Color.DarkSlateBlue;
            button_profile.BackColor = Color.FromArgb(192, 64, 0);
            button_edit.BackColor = Color.DarkSlateBlue;
            button_aipl_air.BackColor= Color.DarkSlateBlue;
            button_airplanes.BackColor = Color.DarkSlateBlue;
            button_emp_air.BackColor = Color.DarkSlateBlue;

            panelProfile.Visible = true;
            panelProfile2.Visible = false;
            panelEmployees.Visible = false;
            panel_airlines.Visible = false;
            panel_plane.Visible = false;
            panel_air_emp.Visible = false;
            panel_air_plane.Visible = false;


            string querymanager = "SELECT name, surname, patronymic, login, password, data FROM Manager where id_manager=@id";

            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@id", id_manager);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                label_name.Text = reader["name"].ToString();
                textBox1.Text = label_name.Text;
                label_surname.Text = reader["surname"].ToString();
                textBox2.Text = label_surname.Text;
                label_patronymic.Text = reader["patronymic"].ToString();
                textBox3.Text = label_patronymic.Text;
                label_login.Text = reader["login"].ToString();
                textBox4.Text = label_login.Text;
                label_password.Text = reader["password"].ToString();
                textBox5.Text = label_password.Text;
                pictureBoxprofile.Image = Image.FromFile(reader["data"].ToString());
                pictureBoxprofile2.Image = Image.FromFile(reader["data"].ToString());
                path = reader["data"].ToString();
            }
            conn.Close();
        }

        private void button_employees_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;

            button_employees.BackColor = Color.FromArgb(192, 64, 0);
            button_airlines.BackColor = Color.DarkSlateBlue;
            button_profile.BackColor = Color.DarkSlateBlue;
            button_edit.BackColor = Color.DarkSlateBlue;
            button_aipl_air.BackColor = Color.DarkSlateBlue;
            button_airplanes.BackColor = Color.DarkSlateBlue;
            button_emp_air.BackColor = Color.DarkSlateBlue;

            panelProfile.Visible = false;
            panelProfile2.Visible = false;
            panelEmployees.Visible = true;
            panel_airlines.Visible = false;
            panel_plane.Visible = false;
            panel_air_emp.Visible = false;
            panel_air_plane.Visible = false;

            string querymanager = "SELECT name AS 'Имя', surname AS 'Фамилия', patronymic AS 'Отчество', login AS 'Логин', password AS 'Пароль', role AS 'Должность'  FROM Employees where id_manager=@id";
            MySqlConnection conn = new MySqlConnection(connection);
           
            MySqlCommand cm = new MySqlCommand(querymanager, conn);
            cm.Parameters.AddWithValue("@id", id_manager);

            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;

            button_employees.BackColor =Color.DarkSlateBlue;
            button_airlines.BackColor = Color.DarkSlateBlue;
            button_profile.BackColor = Color.DarkSlateBlue;
            button_edit.BackColor = Color.FromArgb(192, 64, 0);
            button_aipl_air.BackColor = Color.DarkSlateBlue;
            button_airplanes.BackColor = Color.DarkSlateBlue;
            button_emp_air.BackColor = Color.DarkSlateBlue;


            panelProfile.Visible = false;
            panelProfile2.Visible = true;
            panelEmployees.Visible = false;
            panel_airlines.Visible = false;
            panel_plane.Visible = false;
            panel_air_emp.Visible = false;
            panel_air_plane.Visible = false;

        }

        private void button_airlines_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;


            button_employees.BackColor = Color.DarkSlateBlue;
            button_airlines.BackColor = Color.FromArgb(192, 64, 0);
            button_profile.BackColor = Color.DarkSlateBlue;
            button_edit.BackColor = Color.DarkSlateBlue;
            button_aipl_air.BackColor = Color.DarkSlateBlue;
            button_airplanes.BackColor = Color.DarkSlateBlue;
            button_emp_air.BackColor = Color.DarkSlateBlue;




            panelProfile.Visible = false;
            panelProfile2.Visible = false;
            panelEmployees.Visible = false;
            panel_airlines.Visible = true;
            panel_plane.Visible=false;  
            panel_air_emp.Visible=false;
            panel_air_plane.Visible = false;

            string querymanager = "SELECT  name_of_company AS 'Название авиакомпании',space as 'Количество сотрудников' from Airlines_manager join Manager on Airlines_manager.id_manager=Manager.id_manager join Airlines on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id";
            MySqlConnection conn = new MySqlConnection(connection);

            MySqlCommand cm = new MySqlCommand(querymanager, conn);
            cm.Parameters.AddWithValue("@id", id_manager);

            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void button_ok_Click(object sender, EventArgs e)
        {

            string querymanager = "Update Manager set name=@name,surname=@surname,patronymic=@patronymic,login=@login, password=@password, data=@data where id_manager=@id";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand commandUpdate = new MySqlCommand(querymanager);
            commandUpdate.Parameters.AddWithValue("@name", textBox1.Text);
            commandUpdate.Parameters.AddWithValue("@surname", textBox2.Text);
            commandUpdate.Parameters.AddWithValue("@patronymic", textBox3.Text);
            commandUpdate.Parameters.AddWithValue("@login", textBox4.Text);
            commandUpdate.Parameters.AddWithValue("@password", textBox5.Text);
            commandUpdate.Parameters.AddWithValue("@data", path);
            commandUpdate.Parameters.AddWithValue("@id", id_manager);
            commandUpdate.Connection = conn;
            commandUpdate.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Успешно отредактировано");
        }


        private void button_change_profile_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                path = openFile.FileName;
                pictureBoxprofile2.Image = Image.FromFile(path);
            }
        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            Point location = this.PointToClient(Cursor.Position);
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(this, location);
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            Point location = this.PointToClient(Cursor.Position);
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, location);
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manager_Add_Employee edit_Employee = new Manager_Add_Employee();
            edit_Employee.Get_ID(id_manager);
            if (edit_Employee.ShowDialog() == DialogResult.OK)
            {
                string querymanager = "SELECT name AS 'Имя', surname AS 'Фамилия', patronymic AS 'Отчество', login AS 'Логин', password AS 'Пароль', role AS 'Должность'  FROM Employees where id_manager=@id";
                MySqlConnection conn = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(querymanager, conn);
                cm.Parameters.AddWithValue("@id", id_manager);

                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            int id_employer = 0;
            string querymanager = "SELECT id_employee FROM Employees where id_manager=@id and login=@login and password=@password";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@id", id_manager);
            command.Parameters.AddWithValue("@login", dataGridView1.Rows[i].Cells[3].Value.ToString());
            command.Parameters.AddWithValue("@password", dataGridView1.Rows[i].Cells[4].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_employer = (int)reader["id_employee"];   
            }
            conn.Close();

            Manager_Edit_Employee edit_Employee = new Manager_Edit_Employee();
            edit_Employee.Get_ID(id_manager);
            edit_Employee.Get_id(id_employer);
            if(edit_Employee.ShowDialog()==DialogResult.OK)
            {
                string querymanager2 = "SELECT name AS 'Имя', surname AS 'Фамилия', patronymic AS 'Отчество', login AS 'Логин', password AS 'Пароль', role AS 'Должность'  FROM Employees where id_manager=@id";
                MySqlConnection conn2 = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(querymanager2, conn2);
                cm.Parameters.AddWithValue("@id", id_manager);

                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            string querymanager = "SELECT id_employee FROM Employees where id_manager=@id and login=@login and password=@password";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@id", id_manager);
            command.Parameters.AddWithValue("@login", dataGridView1.Rows[i].Cells[3].Value.ToString());
            command.Parameters.AddWithValue("@password", dataGridView1.Rows[i].Cells[4].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_employer = (int)reader["id_employee"];
            }
            conn.Close();
            string querydelete1 = "Delete  from Employees where id_employee=@id";
            string querydelete3="Delete from Flights where id_employee=@id";
            string querydelete2 = "Delete from Airlines_employees where id_employee=@id";
            conn.Open();
            MySqlCommand commandDelete2 = new MySqlCommand(querydelete2);
            commandDelete2.Parameters.AddWithValue("@id", id_employer);
            commandDelete2.Connection = conn;
            commandDelete2.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            MySqlCommand commandDelete3 = new MySqlCommand(querydelete3);
            commandDelete3.Parameters.AddWithValue("@id", id_employer);
            commandDelete3.Connection = conn;
            commandDelete3.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            MySqlCommand commandDelete1 = new MySqlCommand(querydelete1);
            commandDelete1.Parameters.AddWithValue("@id", id_employer);
            commandDelete1.Connection = conn;
            commandDelete1.ExecuteNonQuery();
            conn.Close();
            string querymanager2 = "SELECT name AS 'Имя', surname AS 'Фамилия', patronymic AS 'Отчество', login AS 'Логин', password AS 'Пароль', role AS 'Должность'  FROM Employees where id_manager=@id";
            
            MySqlCommand cm = new MySqlCommand(querymanager2, conn);
            cm.Parameters.AddWithValue("@id", id_manager);

            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manager_Add_Airline airline = new Manager_Add_Airline();
            airline.Get_Id(id_manager);
            if(airline.ShowDialog()==DialogResult.OK)
            {
                string querymanager = "SELECT  name_of_company AS 'Название авиакомпании',space as 'Количество сотрудников' from Airlines_manager join Manager on Airlines_manager.id_manager=Manager.id_manager join Airlines on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id";
                MySqlConnection conn = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(querymanager, conn);
                cm.Parameters.AddWithValue("@id", id_manager);

                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView2.DataSource = dt;
            }

        }

        private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            int i = dataGridView2.CurrentRow.Index;
            string querymanager = "SELECT Airlines_manager.id_airline FROM Airlines_manager join Airlines on Airlines_manager.id_airline=Airlines.id_airline where id_manager=@id and name_of_company=@name";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@id", id_manager);
            command.Parameters.AddWithValue("@name", dataGridView2.Rows[i].Cells[0].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_airline = (int)reader["id_airline"];
            }
            conn.Close();
            Manager_Edit_Airline edit_airline = new Manager_Edit_Airline();
            edit_airline.Get_ID(id_manager, id_airline);
            if (edit_airline.ShowDialog() == DialogResult.OK)
            {
                string querymanager2 = "SELECT  name_of_company AS 'Название авиакомпании',space as 'Количество сотрудников' from Airlines_manager join Manager on Airlines_manager.id_manager=Manager.id_manager join Airlines on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id";
                MySqlConnection conn2 = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(querymanager2, conn2);
                cm.Parameters.AddWithValue("@id", id_manager);

                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = dataGridView2.CurrentRow.Index;
            string querymanager = "SELECT Airlines_manager.id_airline FROM Airlines_manager join Airlines on Airlines_manager.id_airline=Airlines.id_airline where id_manager=@id and name_of_company=@name";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@id", id_manager);
            command.Parameters.AddWithValue("@name", dataGridView2.Rows[i].Cells[0].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_airline = (int)reader["id_airline"];
            }
            conn.Close();
            string querydelete1 = "Delete  from Airlines_manager where id_manager=@id and id_airline=@id_2";
            string querydelete2 = "Delete from Airlines_employees where id_airline=@id";
            string querydelete3 = "Delete from Airlines where id_airline=@id";
            string querydelete4 = "Delete from Sales where id_airline=@id";
            string querydelete5 = "Delete from Tickets where id_airline=@id";
            string querydelete6 = "Delete from Airlines_airplanes where id_airline=@id";
            conn.Open();
            MySqlCommand commandDelete1 = new MySqlCommand(querydelete1,conn);
            commandDelete1.Parameters.AddWithValue("@id", id_manager);
            commandDelete1.Parameters.AddWithValue("@id_2", id_airline);
            commandDelete1.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            MySqlCommand commandDelete2 = new MySqlCommand(querydelete2,conn);
            commandDelete2.Parameters.AddWithValue("@id", id_airline);
          
            commandDelete2.ExecuteNonQuery();
            conn.Close();

           
            conn.Open();
            MySqlCommand commandDelete4 = new MySqlCommand(querydelete4, conn);
            commandDelete4.Parameters.AddWithValue("@id", id_airline);

            commandDelete4.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            MySqlCommand commandDelete5 = new MySqlCommand(querydelete5, conn);
            commandDelete5.Parameters.AddWithValue("@id", id_airline);

            commandDelete5.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            MySqlCommand commandDelete6 = new MySqlCommand(querydelete6, conn);
            commandDelete6.Parameters.AddWithValue("@id", id_airline);

            commandDelete6.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            MySqlCommand commandDelete3 = new MySqlCommand(querydelete3, conn);
            commandDelete3.Parameters.AddWithValue("@id", id_airline);

            commandDelete3.ExecuteNonQuery();
            conn.Close();

            string querymanager2 = "SELECT  name_of_company AS 'Название авиакомпании',space as 'Количество сотрудников' from Airlines_manager join Manager on Airlines_manager.id_manager=Manager.id_manager join Airlines on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id";
            MySqlConnection conn2 = new MySqlConnection(connection);

            MySqlCommand cm = new MySqlCommand(querymanager2, conn2);
            cm.Parameters.AddWithValue("@id", id_manager);

            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button_airplanes_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;



            button_employees.BackColor = Color.DarkSlateBlue;
            button_airlines.BackColor =Color.DarkSlateBlue;
            button_profile.BackColor = Color.DarkSlateBlue;
            button_edit.BackColor = Color.DarkSlateBlue;
            button_aipl_air.BackColor = Color.DarkSlateBlue;
            button_airplanes.BackColor = Color.FromArgb(192, 64, 0);
            button_emp_air.BackColor = Color.DarkSlateBlue;



            panelProfile.Visible = false;
            panelProfile2.Visible = false;
            panelEmployees.Visible = false;
            panel_airlines.Visible = false;
            panel_plane.Visible = true;
            panel_air_emp.Visible = false;
            panel_air_plane.Visible = false;


            string querymanager = "SELECT  model_of_airplane AS 'Название самолета',type_airplane as 'Тип самолета', capacity as 'Вместимость' from Airplane";
            MySqlConnection conn = new MySqlConnection(connection);

            MySqlCommand cm = new MySqlCommand(querymanager, conn);
            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView3.DataSource = dt;



        }

        private void button_emp_air_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = true;
            panel8.Visible = false;




            button_employees.BackColor = Color.DarkSlateBlue;
            button_airlines.BackColor = Color.DarkSlateBlue;
            button_profile.BackColor = Color.DarkSlateBlue;
            button_edit.BackColor = Color.DarkSlateBlue;
            button_aipl_air.BackColor = Color.DarkSlateBlue;
            button_airplanes.BackColor = Color.DarkSlateBlue;
            button_emp_air.BackColor = Color.FromArgb(192, 64, 0);




            panelProfile.Visible = false;
            panelProfile2.Visible = false;
            panelEmployees.Visible = false;
            panel_airlines.Visible = false;
            panel_plane.Visible = false;
            panel_air_emp.Visible = true;
            panel_air_plane.Visible = false;



            string querymanager = "SELECT name_of_company as 'Авиакомпания', name as 'Имя сотрудника', surname as 'Фамилия сотрудника', patronymic as 'Отчество сотрудника', login as 'Логин' from Employees join Airlines_employees on Airlines_employees.id_employee=Employees.id_employee join Airlines on Airlines_employees.id_airline=Airlines.id_airline join Airlines_manager on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id and Employees.id_manager=@id";
            MySqlConnection conn = new MySqlConnection(connection);

            MySqlCommand cm = new MySqlCommand(querymanager, conn);
            cm.Parameters.AddWithValue("@id", id_manager);
            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView4.DataSource = dt;

        }

        private void button_aipl_air_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = true;





            button_employees.BackColor = Color.DarkSlateBlue;
            button_airlines.BackColor = Color.DarkSlateBlue;
            button_profile.BackColor = Color.DarkSlateBlue;
            button_edit.BackColor = Color.DarkSlateBlue;
            button_aipl_air.BackColor = Color.FromArgb(192, 64, 0);
            button_airplanes.BackColor = Color.DarkSlateBlue;
            button_emp_air.BackColor =Color.DarkSlateBlue;



            panelProfile.Visible = false;
            panelProfile2.Visible = false;
            panelEmployees.Visible = false;
            panel_airlines.Visible = false;
            panel_plane.Visible = false;
            panel_air_emp.Visible = false;
            panel_air_plane.Visible = true;

            string querymanager = "SELECT name_of_company as 'Авиакомпания', model_of_airplane as 'Модель самолёта', type_airplane as 'Тип самолёта' from Airplane join Airlines_airplanes on Airlines_airplanes.id_airplane=Airplane.id_airplane join Airlines on Airlines_airplanes.id_airline=Airlines.id_airline join Airlines_manager on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id and is_available=false";
            MySqlConnection conn = new MySqlConnection(connection);

            MySqlCommand cm = new MySqlCommand(querymanager, conn);
            cm.Parameters.AddWithValue("@id", id_manager);
            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView5.DataSource = dt;

        }

        private void добавитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Manager_Add_Airplane airplane = new Manager_Add_Airplane();
           
            if (airplane.ShowDialog() == DialogResult.OK)
            {
                string querymanager = "SELECT  model_of_airplane AS 'Название самолета',type_airplane as 'Тип самолета', capacity as 'Вместимость' from Airplane";
                MySqlConnection conn = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(querymanager, conn);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView3.DataSource = dt;
            }

        }

        private void редактироватьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int i = dataGridView3.CurrentRow.Index;
            string querymanager = "SELECT id_airplane FROM Airplane where model_of_airplane=@name";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@name", dataGridView3.Rows[i].Cells[0].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_airplane = (int)reader["id_airplane"];
            }
            conn.Close();
            Manager_Edit_Airplane edit_Airplane = new Manager_Edit_Airplane();
            edit_Airplane.Get_ID(id_airplane);
            if(edit_Airplane.ShowDialog()==DialogResult.OK)
            {
                string querymanager2 = "SELECT  model_of_airplane AS 'Название самолета',type_airplane as 'Тип самолета', capacity as 'Вместимость' from Airplane";
                MySqlConnection conn2 = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(querymanager2, conn2);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView3.DataSource = dt;

            }

        }

        private void удалитьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int i = dataGridView3.CurrentRow.Index;
            string querymanager = "SELECT id_airplane FROM Airplane where model_of_airplane=@name";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@name", dataGridView3.Rows[i].Cells[0].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_airplane = (int)reader["id_airplane"];
            }
            conn.Close();

            string querydelete1 = "Delete from Airlines_airplanes where id_airplane=@id";
            string querydelete2 = "Delete from Airplane where id_airplane=@id";
            conn.Open();
            MySqlCommand commandDelete1 = new MySqlCommand(querydelete1);
            commandDelete1.Parameters.AddWithValue("@id", id_airplane);
            commandDelete1.Connection = conn;
            commandDelete1.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            MySqlCommand commandDelete2 = new MySqlCommand(querydelete2);
            commandDelete2.Parameters.AddWithValue("@id", id_airplane);
            commandDelete2.Connection = conn;
            commandDelete2.ExecuteNonQuery();
            conn.Close();

            string querymanager2 = "SELECT  model_of_airplane AS 'Название самолета',type_airplane as 'Тип самолета', capacity as 'Вместимость' from Airplane";
            MySqlConnection conn2 = new MySqlConnection(connection);

            MySqlCommand cm = new MySqlCommand(querymanager2, conn2);
            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void dataGridView3_MouseDown(object sender, MouseEventArgs e)
        {
            Point location = this.PointToClient(Cursor.Position);
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip3.Show(this, location);
            }
        }

        private void добавитьToolStripMenuItem3_Click(object sender, EventArgs e)
        {
              
            Manager_Add_Emplyeer_Air air_emp = new Manager_Add_Emplyeer_Air();
            air_emp.Get_ID(id_manager);

            if (air_emp.ShowDialog() == DialogResult.OK)
            {
                string querymanager = "SELECT name_of_company as 'Авиакомпания', name as 'Имя сотрудника', surname as 'Фамилия сотрудника', patronymic as 'Отчество сотрудника', login as 'Логин' from Employees join Airlines_employees on Airlines_employees.id_employee=Employees.id_employee join Airlines on Airlines_employees.id_airline=Airlines.id_airline join Airlines_manager on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id and Employees.id_manager=@id";
                MySqlConnection conn = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(querymanager, conn);
                cm.Parameters.AddWithValue("@id", id_manager);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView4.DataSource = dt;
            }

        }

        private void редактироватьToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int i = dataGridView4.CurrentRow.Index;
            string querymanager = "SELECT id_airline FROM Airlines where name_of_company=@name";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@name", dataGridView4.Rows[i].Cells[0].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_airline = (int)reader["id_airline"];
            }
            conn.Close();
            string querymanager2 = "SELECT id_employee FROM Employees where login=@login";
            conn.Open();
            MySqlCommand command2 = new MySqlCommand(querymanager2, conn);
            command2.Parameters.AddWithValue("@login", dataGridView4.Rows[i].Cells[4].Value.ToString());
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                id_employer = (int)reader2["id_employee"];
            }
            conn.Close();

            Manager_Edit_Employeer_Air edit_emp = new Manager_Edit_Employeer_Air();
            edit_emp.Get_ID(id_manager, id_employer, id_airline);
            if(edit_emp.ShowDialog()==DialogResult.OK)
            {
                string querymanager3 = "SELECT name_of_company as 'Авиакомпания', name as 'Имя сотрудника', surname as 'Фамилия сотрудника', patronymic as 'Отчество сотрудника', login as 'Логин' from Employees join Airlines_employees on Airlines_employees.id_employee=Employees.id_employee join Airlines on Airlines_employees.id_airline=Airlines.id_airline join Airlines_manager on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id and Employees.id_manager=@id";
               
                MySqlCommand cm = new MySqlCommand(querymanager3, conn);
                cm.Parameters.AddWithValue("@id", id_manager);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView4.DataSource = dt;
            }
        }

        private void удалитьToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int i = dataGridView4.CurrentRow.Index;
            int count = 0;
            MySqlConnection conn = new MySqlConnection(connection);
           
            string querymanager2 = "SELECT id_employee FROM Employees where login=@login";
            conn.Open();
            MySqlCommand command2 = new MySqlCommand(querymanager2, conn);
            command2.Parameters.AddWithValue("@login", dataGridView4.Rows[i].Cells[4].Value.ToString());
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                id_employer = (int)reader2["id_employee"];
            }
            conn.Close();

            string querymanager3 = "Select id_airline from Airlines_employees where id_employee=@id";
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager3, conn);
            command.Parameters.AddWithValue("id", id_employer);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                id_airline = (int)reader["id_airline"];
            }
            conn.Close();
            
            string querydelete = "Delete from Airlines_employees where id_employee=@id";
            conn.Open();
            MySqlCommand commandDelete = new MySqlCommand(querydelete);
            commandDelete.Parameters.AddWithValue("@id",id_employer);
            commandDelete.Connection = conn;
            commandDelete.ExecuteNonQuery();
            conn.Close();

            string querymanager4 = "select count(id_employee) as employee_count from Airlines_employees group by id_airline having id_airline=@id ";
            conn.Open();
            MySqlCommand command3 = new MySqlCommand(querymanager4, conn);
            command3.Parameters.AddWithValue("@id", id_airline);
            MySqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                if (!reader3.IsDBNull(0))
                    count = reader3.GetInt32(0);
            }
            conn.Close();
            string querymanager5 = "Update  Airlines set space=@count where id_airline=@id";
            conn.Open();
            MySqlCommand command4 = new MySqlCommand(querymanager5, conn);
            command4.Parameters.AddWithValue("@count", count);
            command4.Parameters.AddWithValue("@id", id_airline);
            command4.ExecuteNonQuery();
            conn.Close();
            string querymanager = "SELECT name_of_company as 'Авиакомпания', name as 'Имя сотрудника', surname as 'Фамилия сотрудника', patronymic as 'Отчество сотрудника', login as 'Логин' from Employees join Airlines_employees on Airlines_employees.id_employee=Employees.id_employee join Airlines on Airlines_employees.id_airline=Airlines.id_airline join Airlines_manager on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id and Employees.id_manager=@id";
           
            MySqlCommand cm = new MySqlCommand(querymanager, conn);
            cm.Parameters.AddWithValue("@id", id_manager);
            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView4.DataSource = dt;

        }

        private void dataGridView4_MouseDown(object sender, MouseEventArgs e)
        {
            Point location = this.PointToClient(Cursor.Position);
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip4.Show(this, location);
            }
        }

        private void добавитьToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Manager_Add_Airplane_Air add_Airplane_Air = new Manager_Add_Airplane_Air();
            add_Airplane_Air.Get_ID(id_manager);
            if(add_Airplane_Air.ShowDialog()== DialogResult.OK)
            {
                string querymanager = "SELECT name_of_company as 'Авиакомпания', model_of_airplane as 'Модель самолёта', type_airplane as 'Тип самолёта' from Airplane join Airlines_airplanes on Airlines_airplanes.id_airplane=Airplane.id_airplane join Airlines on Airlines_airplanes.id_airline=Airlines.id_airline join Airlines_manager on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id and is_available=false";
                MySqlConnection conn = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(querymanager, conn);
                cm.Parameters.AddWithValue("@id", id_manager);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView5.DataSource = dt;

            }

        }

        private void редактироватьToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            int i = dataGridView5.CurrentRow.Index;
            string querymanager = "SELECT id_airline FROM Airlines where name_of_company=@name";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager, conn);
            command.Parameters.AddWithValue("@name", dataGridView5.Rows[i].Cells[0].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_airline = (int)reader["id_airline"];
            }
            conn.Close();
            string querymanager2 = "SELECT id_airplane FROM Airplane where model_of_airplane=@name";
            conn.Open();
            MySqlCommand command2 = new MySqlCommand(querymanager2, conn);
            command2.Parameters.AddWithValue("@name", dataGridView5.Rows[i].Cells[1].Value.ToString());
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                id_airplane= (int)reader2["id_airplane"];
            }
            conn.Close();

            Manager_Edit_Airplane_Air edit_emp = new Manager_Edit_Airplane_Air();
            edit_emp.Get_ID(id_manager, id_airline, id_airplane);
            if (edit_emp.ShowDialog() == DialogResult.OK)
            {
                string querymanager3 = "SELECT name_of_company as 'Авиакомпания', model_of_airplane as 'Модель самолёта', type_airplane as 'Тип самолёта' from Airplane join Airlines_airplanes on Airlines_airplanes.id_airplane=Airplane.id_airplane join Airlines on Airlines_airplanes.id_airline=Airlines.id_airline join Airlines_manager on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id and is_available=false";

                MySqlCommand cm = new MySqlCommand(querymanager3, conn);
                cm.Parameters.AddWithValue("@id", id_manager);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView5.DataSource = dt;

            }
        }

        private void удалитьToolStripMenuItem4_Click(object sender, EventArgs e)
        {

            int i = dataGridView5.CurrentRow.Index;
            bool is_av = true;
            MySqlConnection conn = new MySqlConnection(connection);

            string querymanager2 = "SELECT id_airplane FROM Airplane where model_of_airplane=@name";
            conn.Open();
            MySqlCommand command2 = new MySqlCommand(querymanager2, conn);
            command2.Parameters.AddWithValue("@name", dataGridView5.Rows[i].Cells[1].Value.ToString());
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                id_airplane = (int)reader2["id_airplane"];
            }
            conn.Close();

            string querymanager3 = "Select id_airline from Airlines_airplanes where id_airplane=@id";
            conn.Open();
            MySqlCommand command = new MySqlCommand(querymanager3, conn);
            command.Parameters.AddWithValue("id", id_airplane);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_airline = (int)reader["id_airline"];
            }
            conn.Close();

            string querydelete = "Delete from Airlines_airplanes where id_airplane=@id";
            conn.Open();
            MySqlCommand commandDelete = new MySqlCommand(querydelete);
            commandDelete.Parameters.AddWithValue("@id", id_airplane);
            commandDelete.Connection = conn;
            commandDelete.ExecuteNonQuery();
            conn.Close();

           
            string querymanager5 = "Update  Airplane set is_available=@av where id_airplane=@id";
            conn.Open();
            MySqlCommand command4 = new MySqlCommand(querymanager5, conn);
            command4.Parameters.AddWithValue("@av", is_av);
            command4.Parameters.AddWithValue("@id", id_airplane);
            command4.ExecuteNonQuery();
            conn.Close();

            string querymanager4 = "SELECT name_of_company as 'Авиакомпания', model_of_airplane as 'Модель самолёта', type_airplane as 'Тип самолёта' from Airplane join Airlines_airplanes on Airlines_airplanes.id_airplane=Airplane.id_airplane join Airlines on Airlines_airplanes.id_airline=Airlines.id_airline join Airlines_manager on Airlines.id_airline=Airlines_manager.id_airline where Airlines_manager.id_manager=@id and is_available=false";

            MySqlCommand cm = new MySqlCommand(querymanager4, conn);
            cm.Parameters.AddWithValue("@id", id_manager);
            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView5.DataSource = dt;

        }

        private void dataGridView5_MouseDown(object sender, MouseEventArgs e)
        {
            Point location = this.PointToClient(Cursor.Position);
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip5.Show(this, location);
            }

        }
    }
}
