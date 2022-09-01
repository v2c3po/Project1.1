using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1._1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
    }

        private void Login_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();  //The menu options are hidden before login
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")//Login with password
            {
                groupBox1.Show();
            }
            else
            {
                txtUsername.Clear();
                txtPassword.Clear();
                MessageBox.Show("Please try again!");
            }
        }

        private void button2_Click(object sender, EventArgs e) //Navigate to sales window
        {
            Form3 form3= new Form3();
            form3.Show(); 
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) //Navigate to inventory management window
        {
            Form2 form2= new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
