using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_NET_HW2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.productPhotoTableAdapter1.Fill(dataSet11.ProductPhoto);
            bindingSource1.DataSource = dataSet11.ProductPhoto;


            this.dataGridView1.DataSource = this.bindingSource1;
            this.pictureBox1.DataBindings.Add("Image", this.bindingSource1, "LargePhoto", true);

            List<string> yearCollection = new List<string>();
            for (int i = 0; i < dataSet11.ProductPhoto.Rows.Count; i++) 
            {
                DateTime d = (DateTime) dataSet11.ProductPhoto.Rows[i]["ModifiedDate"];
                yearCollection.Add(d.ToString("yyyy"));
                
            }
            comboBox1.DataSource = yearCollection.Distinct().OrderBy(x => x).ToList();


        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position -= 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position += 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.bindingSource1.Position = dataSet11.ProductPhoto.Count - 1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            label1.Text = $"{bindingSource1.Position+1}/{dataSet11.ProductPhoto.Count}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.productPhotoTableAdapter1.FillByModifiedDate(dataSet11.ProductPhoto,dateTimePicker1.Value,dateTimePicker2.Value);
            this.bindingSource1.DataSource = dataSet11.ProductPhoto;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string start =$"{comboBox1.Text}/01/01";
            string end = $"{comboBox1.Text}/12/31";

            this.productPhotoTableAdapter1.FillByModifiedDate(dataSet11.ProductPhoto, DateTime.Parse(start), DateTime.Parse(end));
            this.bindingSource1.DataSource = dataSet11.ProductPhoto;
        }
    }
}
