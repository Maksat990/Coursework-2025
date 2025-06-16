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

namespace Coursework
{
    public partial class Manager_Add_Airplane : Form
    {
        private string connection = "SERVER=LOCALHOST ; DATABASE=airport ; UID=root; PASSWORD=481207";

        public Manager_Add_Airplane()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            MySqlCommand command = new MySqlCommand("insert into Airplane(model_of_airplane,type_airplane,capacity) values(@name,@type,@cap)", conn);
            command.Parameters.AddWithValue("@name", textBox1.Text);
            command.Parameters.AddWithValue("@type", textBox2.Text);
            command.Parameters.AddWithValue("@cap",textBox3.Text);
            command.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            this.DialogResult = DialogResult.OK;
        }
    }
}
