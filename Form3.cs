using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project1._1
{
    public partial class Form3 : Form
    {
        public static InvRepository invRepository;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)//FORM LOAD
        {
            invRepository = new InvRepository();
            dataGridView1.DataSource = invRepository.GetAllRecords();
            button1.Enabled = false;
        }
        //Use Form3.invRepository on other forms as well
        private void button1_Click(object sender, EventArgs e)//SELL BUTTON
        {
            int numofitems = Convert.ToInt32(comboBox2.Text);
            var serial = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var invtoupdate=invRepository.FindItem(serial);
            invtoupdate.Serial = serial;
            invtoupdate.Unit_Price = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
            invtoupdate.Item_Quantity = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value) - numofitems;
            invtoupdate.Quantity_Sold = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value)+numofitems;
            invtoupdate.Item_Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            invRepository.UpdateRecord(serial, invtoupdate);
            
            MessageBox.Show("Sales Successful!");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //NOT IMPLEMENTED
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //NOT IMPLEMENTED
        }

        private void button4_Click(object sender, EventArgs e)//BACK TO MAIN MENU BUTTON
        {
            Login form1 = new Login();
            form1.Show();
            this.Hide();
        }

        private void btnSelect_Click(object sender, EventArgs e) //SELECT BUTTON
        {
            var id = dataGridView1.CurrentRow.Cells[0].Value;
            var invtoupdate = invRepository.FindItem((int)id);
            int max_quant = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
            if (max_quant > 0)
            {
                for (int i = 1; i < max_quant + 1; i++)
                { comboBox2.Items.Add(i.ToString()); }
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Form3.invRepository.GetAllRecords();
        }

       

       
    }
}
