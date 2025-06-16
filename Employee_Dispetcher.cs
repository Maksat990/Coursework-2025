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
    public partial class Employee_Dispetcher : Form
    {
        private int id_employee = 0;
        private int id_airline = 0;
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";
        private string path = "";

        public static bool is_enter = false;
        public static bool is_exit=false;
        public Employee_Dispetcher()
        {
            InitializeComponent();

            panel_tickets.Visible = false;
            panelProfile.Visible = false;
            panelProfile2.Visible = false;
            panel_air_enter.Visible = false;
            panel_air_exit.Visible = false;

            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            pictureBoxprofile.Height = 240;

        }
        public void Get_ID(int id)
        {
            id_employee = id;
        }

        private void Empoloyee_Dispetcher_Load(object sender, EventArgs e)
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


           

            string queryemployer = "SELECT name, surname, patronymic, login, password,  role, data from Employees  where id_employee=@id";

            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@id", id_employee);
          
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
                label_dispetcher.Text = reader["role"].ToString();
                pictureBoxprofile.Image = Image.FromFile(reader["data"].ToString());
                pictureBoxprofile2.Image = Image.FromFile(reader["data"].ToString());
                path = reader["data"].ToString();
            }
            conn.Close();
            string queryemployer2 = "SELECT name_of_company from Airlines";

            conn.Open();
            MySqlCommand command2 = new MySqlCommand(queryemployer2, conn);
           
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox_air.Items.Add(reader2["name_of_company"].ToString());
            }
            conn.Close();
        }

        private void button_profile_Click(object sender, EventArgs e)
        {

            panel_tickets.Visible = false;
            panelProfile.Visible = true;
            panelProfile2.Visible = false;
            panel_air_enter.Visible = false;
            panel_air_exit.Visible = false;




            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel2.Visible = false;
           
            button_profile.BackColor= Color.FromArgb(192, 64, 0);
            button_tickets.BackColor = Color.DarkSlateBlue;
            button_edit.BackColor= Color.DarkSlateBlue;
            button_flight1.BackColor= Color.DarkSlateBlue;
            button_flight2.BackColor= Color.DarkSlateBlue;



            string queryemployer = "SELECT name, surname, patronymic, login, password,  role, data from Employees  where id_employee=@id";

            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@id", id_employee);

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
                label_dispetcher.Text = reader["role"].ToString();
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
            panel_air_enter.Visible = false;
            panel_air_exit.Visible = false;

            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel2.Visible = true;
            
            button_profile.BackColor = Color.DarkSlateBlue;
            button_tickets.BackColor = Color.FromArgb(192, 64, 0);
            button_edit.BackColor = Color.DarkSlateBlue;
            button_flight1.BackColor = Color.DarkSlateBlue;
            button_flight2.BackColor = Color.DarkSlateBlue;




        }

        private void button_flight1_Click(object sender, EventArgs e)
        {

            panel_tickets.Visible = false;
            panelProfile.Visible = false;
            panelProfile2.Visible = false;
           
           

            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel2.Visible = false;
            // Color.FromArgb(192, 64, 0);
            // Color.DarkSlateBlue;
            button_profile.BackColor = Color.DarkSlateBlue;
            button_tickets.BackColor = Color.DarkSlateBlue;
            button_edit.BackColor = Color.DarkSlateBlue;
            button_flight1.BackColor = Color.FromArgb(192, 64, 0);
            button_flight2.BackColor = Color.DarkSlateBlue;



            panel_air_exit.Visible = true;
           
            string queryemployee = "Select flight as 'Рейс', arrival_location as 'Аэропорт', departure_time as 'Время вылета',departure_status as 'Статус',departure_terminal as 'Терминал' from Flights where id_employee=@id and arrival_terminal is null";
            MySqlConnection conn = new MySqlConnection(connection);

            MySqlCommand cm = new MySqlCommand(queryemployee, conn);
            cm.Parameters.AddWithValue("@id", id_employee);
            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button_flight2_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel2.Visible = false;
           
            button_profile.BackColor = Color.DarkSlateBlue;
            button_tickets.BackColor = Color.DarkSlateBlue;
            button_edit.BackColor = Color.DarkSlateBlue;
            button_flight1.BackColor = Color.DarkSlateBlue;
            button_flight2.BackColor = Color.FromArgb(192, 64, 0);

            panel_tickets.Visible = false;
            panelProfile.Visible = false;
            panelProfile2.Visible = false;
         


            panel_air_enter.Visible = true;
            panel_air_exit.Visible = false;
            
            string queryemployee = "Select flight as 'Рейс', departure_location as 'Аэропорт', arrival_time as 'Время прилета',arrival_status as 'Статус',arrival_terminal as 'Терминал' from Flights where id_employee=@id and departure_terminal is null";
            MySqlConnection conn = new MySqlConnection(connection);

            MySqlCommand cm = new MySqlCommand(queryemployee, conn);
            cm.Parameters.AddWithValue("@id", id_employee);
            MySqlDataAdapter data = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView3.DataSource = dt;


        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            panel_tickets.Visible = false;
            panelProfile.Visible = false;
            panelProfile2.Visible = true;
            panel_air_enter.Visible = false;
            panel_air_exit.Visible = false;

            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel2.Visible = false;
           
            button_profile.BackColor = Color.DarkSlateBlue;
            button_tickets.BackColor = Color.DarkSlateBlue;
            button_edit.BackColor = Color.FromArgb(192, 64, 0);
            button_flight1.BackColor = Color.DarkSlateBlue;
            button_flight2.BackColor = Color.DarkSlateBlue;


        }

        private void button_find_Click(object sender, EventArgs e)
        {
            bool is_empty = true;
            bool is_empty_2 = true;

            DateTime time = new DateTime();
            DateTime time2 = new DateTime();

            if (!string.IsNullOrEmpty(textBox_time.Text))
            {
              
                is_empty =false;
                DateTime time3 = new DateTime();
                time3 = DateTime.Parse(textBox_time.Text);
                time = time3.AddDays(-1);
                time2=time3.AddDays(1);
                
                MessageBox.Show(time.ToString());
                MessageBox.Show(time2.ToString());

            }
            if (!string.IsNullOrEmpty(textBox_place.Text))
            {
                is_empty_2=false;  
            }

            string queryemployer = "SELECT id_airline  from Airlines  where name_of_company=@name";

            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployer, conn);
            command.Parameters.AddWithValue("@name", comboBox_air.SelectedItem.ToString());

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_airline = (int)reader["id_airline"];
            }
            conn.Close();

            string queryemployer2 = "Select name_of_company as 'Авиакомпания', flight as 'Рейс', from_ as 'Откуда', to_ as'Куда', gate as 'Выход на посадку', time_departure as 'Время вылета', time_arrival as 'Время прилёта' from Airlines join Tickets on Airlines.id_airline=Tickets.id_airline where from_=@name and Tickets.id_airline=@id";

            if (is_empty==true && is_empty_2==false)
            {
                MySqlCommand cm = new MySqlCommand(queryemployer2, conn);
                cm.Parameters.AddWithValue("@name", textBox_place.Text);
                cm.Parameters.AddWithValue("@id", id_airline);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            string queryemployer3 = "Select name_of_company as 'Авиакомпания', flight as 'Рейс', from_ as 'Откуда', to_ as'Куда', gate as 'Выход на посадку', time_departure as 'Время вылета', time_arrival as 'Время прилёта' from Airlines join Tickets on Airlines.id_airline=Tickets.id_airline where from_=@name and Tickets.id_airline=@id and time_departure>=@time and time_departure <=@time_2";
            if(is_empty==false && is_empty_2==false)
            {
                MySqlCommand cm = new MySqlCommand(queryemployer3, conn);
                cm.Parameters.AddWithValue("@name", textBox_place.Text);
                cm.Parameters.AddWithValue("@id", id_airline);
                cm.Parameters.AddWithValue("@time", time);
                cm.Parameters.AddWithValue("@time_2", time2);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            string queryemployer4 = "Select name_of_company as 'Авиакомпания', flight as 'Рейс', from_ as 'Откуда', to_ as'Куда', gate as 'Выход на посадку', time_departure as 'Время вылета', time_arrival as 'Время прилёта' from Airlines join Tickets on Airlines.id_airline=Tickets.id_airline where Tickets.id_airline=@id and time_departure>=@time and time_departure <=@time_2";
            if (is_empty == false && is_empty_2 == true)
            {
                MySqlCommand cm = new MySqlCommand(queryemployer4, conn);
                cm.Parameters.AddWithValue("@name", textBox_place.Text);
                cm.Parameters.AddWithValue("@id", id_airline);
                cm.Parameters.AddWithValue("@time", time);
                cm.Parameters.AddWithValue("@time_2", time2);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            string queryemployer5 = "Select name_of_company as 'Авиакомпания', flight as 'Рейс', from_ as 'Откуда', to_ as'Куда', gate as 'Выход на посадку', time_departure as 'Время вылета', time_arrival as 'Время прилёта' from Airlines join Tickets on Airlines.id_airline=Tickets.id_airline where Tickets.id_airline=@id";
            if (is_empty == true && is_empty_2 == true)
            {
                MySqlCommand cm = new MySqlCommand(queryemployer5, conn);
                cm.Parameters.AddWithValue("@name", textBox_place.Text);
                cm.Parameters.AddWithValue("@id", id_airline);
                cm.Parameters.AddWithValue("@time", time);
                cm.Parameters.AddWithValue("@time_2", time2);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            is_exit = true;
            Employee_Dispetcher_Flight_Add add_fl = new Employee_Dispetcher_Flight_Add();
            add_fl.Get_ID(id_employee);
            if (add_fl.ShowDialog() == DialogResult.OK)
            {
                string queryemployee = "Select flight as 'Рейс', arrival_location as 'Аэропорт', departure_time as 'Время вылета',departure_status as 'Статус',departure_terminal as 'Терминал' from Flights where id_employee=@id and arrival_terminal is null";
                MySqlConnection conn = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(queryemployee, conn);
                cm.Parameters.AddWithValue("@id", id_employee);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            is_exit = false;

        }

        private void редактитроватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            is_exit = true;
            int id = 0;
            int i = dataGridView2.CurrentRow.Index;
            string queryemployee = "Select id_flight from Flights where id_employee=@id and flight=@fl";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployee, conn);
            command.Parameters.AddWithValue("@id", id_employee);
            command.Parameters.AddWithValue("@fl", dataGridView2.Rows[i].Cells[0].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["id_flight"];
            }
            conn.Close();
            Employee_Dispetcher_Flight_Edit edit_fl = new Employee_Dispetcher_Flight_Edit();
            edit_fl.Get_ID(id_employee,id);
            if (edit_fl.ShowDialog() == DialogResult.OK)
            {
                string queryemployee2 = "Select flight as 'Рейс', arrival_location as 'Аэропорт', departure_time as 'Время вылета',departure_status as 'Статус',departure_terminal as 'Терминал' from Flights where id_employee=@id and arrival_terminal is null";

                MySqlConnection conn2 = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(queryemployee2, conn2);
                cm.Parameters.AddWithValue("@id", id_employee);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            is_exit = false;

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = 0;
            int i = dataGridView2.CurrentRow.Index;
            string queryemployee = "Select id_flight from Flights where id_employee=@id and flight=@fl";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployee, conn);
            command.Parameters.AddWithValue("@id", id_employee);
            command.Parameters.AddWithValue("@fl", dataGridView2.Rows[i].Cells[0].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["id_flight"];
            }
            conn.Close();
            string querydelete = "Delete from Flights where id_employee=@id and id_flight=@id_2";
            conn.Open();
            MySqlCommand commandDelete = new MySqlCommand(querydelete);
            commandDelete.Parameters.AddWithValue("@id", id_employee);
            commandDelete.Parameters.AddWithValue("@id_2", id);
            commandDelete.Connection = conn;
            commandDelete.ExecuteNonQuery();
            conn.Close();

            string queryemployee2 = "Select flight as 'Рейс', arrival_location as 'Аэропорт', departure_time as 'Время вылета',departure_status as 'Статус',departure_terminal as 'Терминал' from Flights where id_employee=@id and arrival_terminal is null";

            MySqlConnection conn2 = new MySqlConnection(connection);
            MySqlCommand cm = new MySqlCommand(queryemployee2, conn2);
            cm.Parameters.AddWithValue("@id", id_employee);
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
                contextMenuStrip1.Show(this, location);
            }
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            is_enter = true;
            Employee_Dispetcher_Flight_Add add_fl = new Employee_Dispetcher_Flight_Add();
            add_fl.Get_ID(id_employee);
            if (add_fl.ShowDialog() == DialogResult.OK)
            {

                string queryemployee = "Select flight as 'Рейс', departure_location as 'Аэропорт', arrival_time as 'Время прилета',arrival_status as 'Статус',arrival_terminal as 'Терминал' from Flights where id_employee=@id and departure_terminal is null";
                MySqlConnection conn = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(queryemployee, conn);
                cm.Parameters.AddWithValue("@id", id_employee);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            is_enter=false;
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            is_enter = true;
            int id = 0;
            int i = dataGridView3.CurrentRow.Index;
            string queryemployee = "Select id_flight from Flights where id_employee=@id and flight=@fl";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployee, conn);
            command.Parameters.AddWithValue("@id", id_employee);
            command.Parameters.AddWithValue("@fl", dataGridView3.Rows[i].Cells[0].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["id_flight"];
            }
            conn.Close();
            Employee_Dispetcher_Flight_Edit edit_fl = new Employee_Dispetcher_Flight_Edit();
            edit_fl.Get_ID(id_employee, id);
            if (edit_fl.ShowDialog() == DialogResult.OK)
            {
                string queryemployee2 = "Select flight as 'Рейс', departure_location as 'Аэропорт', arrival_time as 'Время прилета',arrival_status as 'Статус',arrival_terminal as 'Терминал' from Flights where id_employee=@id and departure_terminal is null";

                MySqlConnection conn2 = new MySqlConnection(connection);

                MySqlCommand cm = new MySqlCommand(queryemployee2, conn2);
                cm.Parameters.AddWithValue("@id", id_employee);
                MySqlDataAdapter data = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            is_enter = false;

        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            int id = 0;
            int i = dataGridView3.CurrentRow.Index;
            string queryemployee = "Select id_flight from Flights where id_employee=@id and flight=@fl";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand(queryemployee, conn);
            command.Parameters.AddWithValue("@id", id_employee);
            command.Parameters.AddWithValue("@fl", dataGridView3.Rows[i].Cells[0].Value.ToString());
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["id_flight"];
            }
            conn.Close();
            string querydelete = "Delete from Flights where id_employee=@id and id_flight=@id_2";
            conn.Open();
            MySqlCommand commandDelete = new MySqlCommand(querydelete);
            commandDelete.Parameters.AddWithValue("@id", id_employee);
            commandDelete.Parameters.AddWithValue("@id_2", id);
            commandDelete.Connection = conn;
            commandDelete.ExecuteNonQuery();
            conn.Close();

            string queryemployee2 = "Select flight as 'Рейс', departure_location as 'Аэропорт', arrival_time as 'Время прилета',arrival_status as 'Статус',arrival_terminal as 'Терминал' from Flights where id_employee=@id and departure_terminal is null";

            MySqlConnection conn2 = new MySqlConnection(connection);
            MySqlCommand cm = new MySqlCommand(queryemployee2, conn2);
            cm.Parameters.AddWithValue("@id", id_employee);
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
