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
using System.Xml.Serialization;

namespace AS1ProjectTeam03
{
    public partial class RealEstateTransactionsForm : Form
    {
        public RealEstateTransactionsForm()
        {
            InitializeComponent();
            this.Text = "Assignment 1 Real Estate Transactions";

        }

        private void RealEstateTransactionsForm_Load(object sender, EventArgs e)
        {
            this.Width = 743;
            this.Height = 762;
            InitializeDataGridViewAllTransactions();

            GetRentalHousingFromXML();
            

        }
        private void GetRentalHousingFromXML()
        {
            // TASK: code to open a file using OpenFileDialog and returning a 
            // StreamReader object
            OpenFileDialog openFileDialog1 = new OpenFileDialog { };
            Stream inputFile;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((inputFile = openFileDialog1.OpenFile()) != null)
                    {
                        using (inputFile)

                           {
                            List<House> myTransactions;

                            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<House>));


                            myTransactions = xmlFormat.Deserialize(inputFile) as List<House>;
                            inputFile.Close();
                            MessageBox.Show($"=> Reading list of cars from {inputFile}");

                            foreach (House c in myTransactions)
                                this.dataGridViewAllTransactions.Rows.Add(c.City, c.Address, c.Bedrooms, c.Bathrooms, c.SurfaceArea, c.HouseType, c.Price);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }


            // TASK: two lines of code.
            // first, set up the XmlSerializer with a type of List<NewWestminsterRentalHousing>
            // second, deserialize and return a list set to rentalHousingList.
            // hint: cast or use as List<NewWestminsterRentalHousing>
            // make sure you close the file before the method exits.

        }

        public void InitializeDataGridViewAllTransactions()
        {

            dataGridViewAllTransactions.ReadOnly = true;
            dataGridViewAllTransactions.AllowUserToAddRows = false;
            dataGridViewAllTransactions.RowHeadersVisible = false;
            dataGridViewAllTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewAllTransactions.Columns.Clear();

            DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[] {
                new DataGridViewTextBoxColumn() { Name = "City" },
                new DataGridViewTextBoxColumn() { Name = "Address" },
                new DataGridViewTextBoxColumn() { Name = "Bedrooms" },
                new DataGridViewTextBoxColumn() { Name = "Bathrooms" },
                new DataGridViewTextBoxColumn() { Name = "Surface Area" },
                new DataGridViewTextBoxColumn() { Name = "House Type" },
                new DataGridViewTextBoxColumn() { Name = "Price" },
                };

            dataGridViewAllTransactions.Columns.AddRange(columns);

        }
        [Serializable]
        public class House
        {
            public string Address { get; set; }
            public string City { get; set; }
            public string HouseType { get; set; }
            public int SurfaceArea { get; set; }
            public int Bedrooms { get; set; }
            public int Bathrooms { get; set; }
            public int Price { get; set; }

            public override string ToString()
            {
                return $"{City},{Address},{Bedrooms},{Bathrooms},{SurfaceArea},{HouseType},{Price}";
            }
        }

    }
}
