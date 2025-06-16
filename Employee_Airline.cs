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
    public partial class Employee_Airline : Form
    {

        private int id_employee = 0;
        private int id_airline = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        private string path = "";
        public Employee_Airline()
        {
            InitializeComponent();
            panel_tickets.Location = new Point(234,12);
            panel_tickets.Visible = false;
            panelProfile.Visible = false;
            panelProfile2.Visible = false;
            panel_sales.Visible = false;    

            panel2.Visible = false;
            panel3.Visible=false;
            panel4.Visible = false;
            panel5.Visible = false;

            pictureBoxprofile.Height = 240;
            pictureBoxprofile2.Height = 235;
            
        }
        public void Get_ID(int id)
        {
            id_employee = id;
            string queryemployer = "SELECT id_airline FROM Airlines_employees where id_employee=@id";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@id",id_employee);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_airline=(int)reader["id_airline"];

            }
            conn.Close();

        }
        private void Employee_Airline_Load(object sender, EventArgs e)
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



            string queryemployer = "SELECT name, surname, patronymic, login, password,  role, data, name_of_company from Employees join Airlines_employees on Airlines_employees.id_employee=Employees.id_employee join Airlines on Airlines.id_airline = Airlines_employees.id_airline where Airlines_employees.id_airline=@id and Airlines_employees.id_employee=@id_2";

            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@id", id_airline);
            command.Parameters.AddWithValue("@id_2", id_employee);
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
                textBox4.Text=label_login.Text;
                label_password.Text = reader["password"].ToString();
                textBox5.Text=label_password.Text;
                label_airline.Text = reader["name_of_company"].ToString();
                pictureBoxprofile.Image = Image.FromFile(reader["data"].ToString());
                pictureBoxprofile2.Image = Image.FromFile(reader["data"].ToString());
                path = reader["data"].ToString();
            }
            conn.Close();

        }

        private void button_profile_Click(object sender, EventArgs e)
        {

            panel_tickets.Visible = false;
            panelProfile.Visible = true;
            panelProfile2.Visible = false;
            panel_sales.Visible = false;

            panel3.Visible = true;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;

           
            button_profile.BackColor = Color.FromArgb(192, 64, 0);
            button_edit.BackColor = Color.DarkSlateBlue;
            button_sales.BackColor= Color.DarkSlateBlue;
            button_tickets.BackColor= Color.DarkSlateBlue;



            string queryemployer = "SELECT name, surname, patronymic, login, password,  role, data, name_of_company from Employees join Airlines_employees on Airlines_employees.id_employee=Employees.id_employee join Airlines on Airlines.id_airline = Airlines_employees.id_airline where Airlines_employees.id_airline=@id and Airlines_employees.id_employee=@id_2";

            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@id", id_airline);
            command.Parameters.AddWithValue("@id_2", id_employee);
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
                label_airline.Text = reader["name_of_company"].ToString();
                pictureBoxprofile.Image = Image.FromFile(reader["data"].ToString());
                pictureBoxprofile2.Image = Image.FromFile(reader["data"].ToString());
                path = reader["data"].ToString();
            }
            conn.Close();

        }

        private void button_tickets_Click(object sender, EventArgs e)
        {
            panel_tickets.Visible = true;
            panelProfile.Visible = false;
            panelProfile2.Visible = false;
            panel_sales.Visible = false;

            panel3.Visible = false;
            panel2.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;

            button_profile.BackColor =  Color.DarkSlateBlue;
            button_edit.BackColor = Color.DarkSlateBlue;
            button_sales.BackColor = Color.DarkSlateBlue;
            button_tickets.BackColor = Color.FromArgb(192, 64, 0);




            string queryemployer = "SELECT name_of_company AS 'Авиакомпания', flight AS 'Рейс', from_ AS 'Откуда', to_ AS 'Куда', gate AS 'Выход на посадку', class AS 'Класс', time_departure as 'Время вылета', time_arrival as 'Время прилета'  FROM Tickets join Airlines on Tickets.id_airline=Airlines.id_airline where Tickets.id_airline=@id";
            MySqlConnection conn = new MySqlConnection(connection);

            MySqlCommand cm = new MySqlCommand(queryemployer, conn);
            cm.Parameters.AddWithValue("@id", id_airline);

            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);

            dataGridView1.DataSource = dt;
           


        }

        private void button_sales_Click(object sender, EventArgs e)
        {
            panel_tickets.Visible = false;
            panelProfile.Visible = false;
            panelProfile2.Visible = false;
            panel_sales.Visible = true;

            panel3.Visible = false;
            panel2.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;


            button_profile.BackColor = Color.DarkSlateBlue;
            button_edit.BackColor = Color.DarkSlateBlue;
            button_sales.BackColor = Color.FromArgb(192, 64, 0);
            button_tickets.BackColor = Color.DarkSlateBlue;


            string queryemployer = "SELECT name_of_company AS 'Авиакомпания', flight AS 'Рейс', count as 'Количество', price as 'Цена'  FROM Tickets join Airlines on Tickets.id_airline=Airlines.id_airline join Sales on Tickets.id_ticket=Sales.id_ticket where Tickets.id_airline=@id";
            MySqlConnection conn = new MySqlConnection(connection);

            MySqlCommand cm = new MySqlCommand(queryemployer, conn);
            cm.Parameters.AddWithValue("@id", id_airline);

            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);

            dataGridView2.DataSource = dt;


        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            panel_tickets.Visible = false;
            panelProfile.Visible = false;
            panelProfile2.Visible = true;
            panel_sales.Visible = false;

            panel3.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;

            button_profile.BackColor = Color.DarkSlateBlue;
            button_edit.BackColor = Color.FromArgb(192, 64, 0);
            button_sales.BackColor = Color.DarkSlateBlue;
            button_tickets.BackColor = Color.DarkSlateBlue;


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
            Employee_Airline_Add_ticket add_Ticket = new Employee_Airline_Add_ticket();
            add_Ticket.Get_ID(id_airline);
            if(add_Ticket.ShowDialog()==DialogResult.OK)
            {
                string queryemployer = "SELECT name_of_company AS 'Авиакомпания', flight AS 'Рейс', from_ AS 'Откуда', to_ AS 'Куда', gate AS 'Выход на посадку', class AS 'Класс', time_departure as 'Время вылета', time_arrival as 'Время прилета'  FROM Tickets join Airlines on Tickets.id_airline=Airlines.id_airline where Tickets.id_airline=@id";
                MySqlConnection conn = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(queryemployer, conn);
                cm.Parameters.AddWithValue("@id", id_airline);

                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);

                dataGridView1.DataSource = dt;

            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            int id_ticket = 0;
            string queryemployer = "Select id_ticket from Tickets where flight=@fl";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@fl", dataGridView1.Rows[i].Cells[1].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_ticket = (int)reader["id_ticket"];
            }
            conn.Close();
            Employee_Airline_Edit_ticket edit_Ticket=new Employee_Airline_Edit_ticket();
            edit_Ticket.Get_ID(id_airline, id_ticket);
            if(edit_Ticket.ShowDialog()==DialogResult.OK)
            {
                string queryemployer2 = "SELECT name_of_company AS 'Авиакомпания', flight AS 'Рейс', from_ AS 'Откуда', to_ AS 'Куда', gate AS 'Выход на посадку', class AS 'Класс', time_departure as 'Время вылета', time_arrival as 'Время прилета'  FROM Tickets join Airlines on Tickets.id_airline=Airlines.id_airline where Tickets.id_airline=@id";
              

                MySqlCommand cm = new MySqlCommand(queryemployer2, conn);
                cm.Parameters.AddWithValue("@id", id_airline);

                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            int id_ticket = 0;
            string queryemployer = "Select id_ticket from Tickets where flight=@fl";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@fl", dataGridView1.Rows[i].Cells[1].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_ticket = (int)reader["id_ticket"];
            }
            conn.Close();
            string querydelete = "Delete from Purchased_tickets where id_ticket=@id";
            string querydelete2 = "Delete from Sales where id_ticket=@id";
            string querydelete3 = "Delete from Tickets where id_ticket=@id";

            conn.Open();
            MySqlCommand commandDelete = new MySqlCommand(querydelete);
            commandDelete.Parameters.AddWithValue("@id", id_ticket);
            commandDelete.Connection = conn;
            commandDelete.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            MySqlCommand commandDelete2 = new MySqlCommand(querydelete2);
            commandDelete2.Parameters.AddWithValue("@id", id_ticket);
            commandDelete2.Connection = conn;
            commandDelete2.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            MySqlCommand commandDelete3 = new MySqlCommand(querydelete3);
            commandDelete3.Parameters.AddWithValue("@id", id_ticket);
            commandDelete3.Connection = conn;
            commandDelete3.ExecuteNonQuery();
            conn.Close();

            string queryemployer2 = "SELECT name_of_company AS 'Авиакомпания', flight AS 'Рейс', from_ AS 'Откуда', to_ AS 'Куда', gate AS 'Выход на посадку', class AS 'Класс', time_departure as 'Время вылета', time_arrival as 'Время прилета'  FROM Tickets join Airlines on Tickets.id_airline=Airlines.id_airline where Tickets.id_airline=@id";
            
            MySqlCommand cm = new MySqlCommand(queryemployer2, conn);
            cm.Parameters.AddWithValue("@id", id_airline);

            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Employee_Airline_Add_Price add_Ticket = new Employee_Airline_Add_Price();
            add_Ticket.Get_ID(id_airline);
            if (add_Ticket.ShowDialog() == DialogResult.OK)
            {
                string queryemployer = "SELECT name_of_company AS 'Авиакомпания', flight AS 'Рейс', count as 'Количество', price as 'Цена'  FROM Tickets join Airlines on Tickets.id_airline=Airlines.id_airline join Sales on Tickets.id_ticket=Sales.id_ticket where Tickets.id_airline=@id";
                MySqlConnection conn = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(queryemployer, conn);
                cm.Parameters.AddWithValue("@id", id_airline);

                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);

                dataGridView2.DataSource = dt;

            }

        }

        private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = dataGridView2.CurrentRow.Index;
            int id_ticket = 0;
            string queryemployer = "Select id_ticket from Tickets where flight=@fl";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@fl", dataGridView2.Rows[i].Cells[1].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_ticket = (int)reader["id_ticket"];
            }
            conn.Close();
            Employee_Airline_Edit_Price edit_Ticket = new Employee_Airline_Edit_Price();
            edit_Ticket.Get_ID(id_airline, id_ticket);
            if (edit_Ticket.ShowDialog() == DialogResult.OK)
            {
                string queryemployer2 = "SELECT name_of_company AS 'Авиакомпания', flight AS 'Рейс', count as 'Количество', price as 'Цена'  FROM Tickets join Airlines on Tickets.id_airline=Airlines.id_airline join Sales on Tickets.id_ticket=Sales.id_ticket where Tickets.id_airline=@id";
             
                MySqlCommand cm = new MySqlCommand(queryemployer2, conn);
                cm.Parameters.AddWithValue("@id", id_airline);

                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = dataGridView2.CurrentRow.Index;
            int id_ticket = 0;
            string queryemployer = "Select id_ticket from Tickets where flight=@fl";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@fl", dataGridView2.Rows[i].Cells[1].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_ticket = (int)reader["id_ticket"];
            }
            conn.Close();
           
            string querydelete = "Delete from Sales where id_ticket=@id";
           

            conn.Open();
            MySqlCommand commandDelete = new MySqlCommand(querydelete);
            commandDelete.Parameters.AddWithValue("@id", id_ticket);
            commandDelete.Connection = conn;
            commandDelete.ExecuteNonQuery();
            conn.Close();

            string queryemployer2 = "SELECT name_of_company AS 'Авиакомпания', flight AS 'Рейс', count as 'Количество', price as 'Цена'  FROM Tickets join Airlines on Tickets.id_airline=Airlines.id_airline join Sales on Tickets.id_ticket=Sales.id_ticket where Tickets.id_airline=@id";

            MySqlCommand cm = new MySqlCommand(queryemployer2, conn);
            cm.Parameters.AddWithValue("@id", id_airline);

            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            Point location = this.PointToClient(Cursor.Position);
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(this, location);
            }

        }

        private void button_ok_Click(object sender, EventArgs e)
        {

            string queryemployer = "Update Employees set name=@name,surname=@surname,patronymic=@patronymic, login=@login, password=@pass, data=@data where id_employee=@id";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand commandUpdate = new MySqlCommand(queryemployer);
            commandUpdate.Parameters.AddWithValue("@name", textBox1.Text);
            commandUpdate.Parameters.AddWithValue("@surname", textBox2.Text);
            commandUpdate.Parameters.AddWithValue("@patronymic", textBox3.Text);
            commandUpdate.Parameters.AddWithValue("@login", textBox4.Text);
            commandUpdate.Parameters.AddWithValue("@pass", textBox5.Text);
            commandUpdate.Parameters.AddWithValue("@data", path);
            commandUpdate.Parameters.AddWithValue("@id", id_employee);
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
    }
}
