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
    public partial class Form2 : Form
    {
        public static InvRepository invRepository;
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form2_Load(object sender, EventArgs e)//FORM LOAD CONDITIONS
        {
            invRepository = new InvRepository();
            gridData.DataSource = invRepository.GetAllRecords();
            
            btnSubmit.Enabled = false;
            btnUpdate.Enabled = false;
            grpBox.Enabled = false;
        }

        private void brnAdd_Click(object sender, EventArgs e)//ADDING INVENTORY BUTTON CONDITIONS
        {
            grpBox.Enabled = true;
            txtSerial.Clear();
            txtName.Clear();
            txtQuantity.Clear();
            txtQsold.Clear();
            txtUnitprice.Clear();
            btnSubmit.Enabled = true;
            
           
        }

        private void btnSubmit_Click(object sender, EventArgs e)//SUBMIT BUTTON LOGIC
        {
            var newInv = new Inventory();
            newInv.Serial = Int32.Parse(txtSerial.Text);
            newInv.Item_Name = txtName.Text;
            newInv.Item_Quantity = Int32.Parse(txtQuantity.Text);
            newInv.Quantity_Sold = Int32.Parse(txtQsold.Text);
            newInv.Unit_Price = Int32.Parse(txtUnitprice.Text);
            invRepository.AddRecord(newInv);
            MessageBox.Show("New Item added!");
            Clear();
            
        }
        private void Clear()// CLEAR METHOD TO CLEAR THE TEXT FIELDS
        {
            txtSerial.Clear();
            txtName.Clear();
            txtQuantity.Clear();
            txtQsold.Clear();
            txtUnitprice.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)//DELETE BUTTON LOGIC
        {
            var serial = gridData.CurrentRow.Cells[0].Value;
            var invtodel = invRepository.FindItem((int)serial);
            MessageBox.Show("Delete this record?");
            invRepository.DeleteRecord(invtodel);
            MessageBox.Show("Record deleted!");
        }

        private void btnSelect_Click(object sender, EventArgs e) //SELECT BUTTON LOGIC
        {
            var serial = gridData.CurrentRow.Cells[0].Value;
            var invtoupdate = invRepository.FindItem((int)serial);
            txtSerial.Text = invtoupdate.Serial.ToString();
            txtName.Text = invtoupdate.Item_Name;
            txtQuantity.Text = invtoupdate.Item_Quantity.ToString();
            txtQsold.Text = invtoupdate.Quantity_Sold.ToString();
            txtUnitprice.Text = invtoupdate.Unit_Price.ToString();
            btnUpdate.Enabled = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e) //UPDATE BUTTON LOGIC
        {
            //validation
            var serial = Convert.ToInt32(txtSerial.Text);
            var invtoupdate = invRepository.FindItem((int)serial);
            invtoupdate.Serial = Int32.Parse(txtSerial.Text);
            invtoupdate.Item_Name = txtName.Text;
            invtoupdate.Item_Quantity = Int32.Parse(txtName.Text);
            invtoupdate.Quantity_Sold = Int32.Parse(txtQsold.Text);
            invtoupdate.Unit_Price = Int32.Parse(txtUnitprice.Text);
            invRepository.UpdateRecord(serial, invtoupdate);
            MessageBox.Show("Record Updated");
            Clear();
        }

        private void btnBack_Click(object sender, EventArgs e) //BACK BUTTON LOGIC
        {
            Login form1 = new Login();
            form1.Show();
            this.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e) //REFRESH BUTTON LOGIC
        {
            gridData.DataSource = null;
            gridData.DataSource = invRepository.GetAllRecords();
        }
    }   
}
