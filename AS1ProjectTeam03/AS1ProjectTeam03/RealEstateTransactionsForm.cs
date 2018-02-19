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
        //Globally defined list to store the data from the XML document.
        List<House> initialListOfTransactions;

        public RealEstateTransactionsForm()
        {
            InitializeComponent();
            this.Text = "Assignment 1 Real Estate Transactions";

        }

        private void RealEstateTransactionsForm_Load(object sender, EventArgs e)
        {
            this.Width = 680;
            this.Height = 770;

            InitializeBothDataGridViews();
            GetRentalHousingFromXML();
            FeedTheDataGridViews();
            

        }

        //Opening and de-serializing the XML file.
        private void GetRentalHousingFromXML()
        {
            //OpenFileDialog to allow user to select the input file.
            OpenFileDialog openDataFileDialog = new OpenFileDialog();
            Stream inputFile;

            if (openDataFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((inputFile = openDataFileDialog.OpenFile()) != null)
                    {
                        using (inputFile)
                        {
                            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<House>));

                            //De-serialization
                            initialListOfTransactions = xmlFormat.Deserialize(inputFile) as List<House>;
                            inputFile.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }

        //Sort data from list using LINQ and Lambdas and feed it to DataGridViews.
        private void FeedTheDataGridViews()
        {
            //Sorting the data by City, House Type and Price in order.
            var orderedListOfTransactions = initialListOfTransactions
                .OrderBy(data => data.City)
                .ThenBy(data => data.HouseType)
                .ThenBy(data => data.Price)
                .Select(data => data);

            foreach (House tempTransaction in orderedListOfTransactions)
            {
                //Feeding data to DataGridViews
                dataGridViewAllTransactions.Rows.Add(tempTransaction.City, tempTransaction.Address, tempTransaction.Bedrooms, tempTransaction.Bathrooms, tempTransaction.SurfaceArea, tempTransaction.HouseType, tempTransaction.Price);
                dataGridViewFilteredTransactions.Rows.Add(tempTransaction.City, tempTransaction.Address, tempTransaction.Bedrooms, tempTransaction.Bathrooms, tempTransaction.SurfaceArea, tempTransaction.HouseType, tempTransaction.Price);
            }

            //Setting initial values to the Count and Average Price labels.
            updateCountAndPriceLabels(orderedListOfTransactions.Count(), orderedListOfTransactions.Average(temp => temp.Price));
            updateCountAndPriceLabelsFiltered(orderedListOfTransactions.Count(), orderedListOfTransactions.Average(temp => temp.Price));
        }

        //Method to set up the properties for both the DataGridViews on the form.
        private void InitializeBothDataGridViews()
        {
            // 1. dataGridViewAllTransactions
            //Setting attributes
            dataGridViewAllTransactions.ReadOnly = true;
            dataGridViewAllTransactions.AllowUserToAddRows = false;
            dataGridViewAllTransactions.AllowUserToDeleteRows = false;
            dataGridViewAllTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewAllTransactions.RowHeadersWidth = 30;
            dataGridViewAllTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewAllTransactions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Defining columns to add to the DataGridView
            DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[] {
                new DataGridViewTextBoxColumn() { Name = "City" },
                new DataGridViewTextBoxColumn() { Name = "Address" },
                new DataGridViewTextBoxColumn() { Name = "Bedrooms" },
                new DataGridViewTextBoxColumn() { Name = "Bathrooms" },
                new DataGridViewTextBoxColumn() { Name = "Surface Area" },
                new DataGridViewTextBoxColumn() { Name = "House Type" },
                new DataGridViewTextBoxColumn() { Name = "Price" },
                };

            dataGridViewAllTransactions.Columns.Clear();
            dataGridViewAllTransactions.Columns.AddRange(columns);

            // 2. dataGridViewFilteredTransactions
            //Setting attributes
            dataGridViewFilteredTransactions.ReadOnly = true;
            dataGridViewFilteredTransactions.AllowUserToAddRows = false;
            dataGridViewFilteredTransactions.AllowUserToDeleteRows = false;
            dataGridViewFilteredTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewFilteredTransactions.RowHeadersWidth = 30;
            dataGridViewFilteredTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewFilteredTransactions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Defining columns to add to the DataGridView
            DataGridViewTextBoxColumn[] columns2 = new DataGridViewTextBoxColumn[] {
                new DataGridViewTextBoxColumn() { Name = "City" },
                new DataGridViewTextBoxColumn() { Name = "Address" },
                new DataGridViewTextBoxColumn() { Name = "Bedrooms" },
                new DataGridViewTextBoxColumn() { Name = "Bathrooms" },
                new DataGridViewTextBoxColumn() { Name = "Surface Area" },
                new DataGridViewTextBoxColumn() { Name = "House Type" },
                new DataGridViewTextBoxColumn() { Name = "Price" },
                };

            dataGridViewFilteredTransactions.Columns.Clear();
            dataGridViewFilteredTransactions.Columns.AddRange(columns2);


        }

        private void updateCountAndPriceLabels(int count, double averagePrice)
        {
            labelAllTransactionsCount.Text = count.ToString();
            labelAllTransactionsAveragePrice.Text = averagePrice.ToString("c2");
        }
        private void updateCountAndPriceLabelsFiltered(int count, double averagePrice)
        {
            labelFilteredTransactionsCount.Text = count.ToString();
            labelFilteredTransactionsAveragePrice.Text = averagePrice.ToString("c2");
        }

        //Serializable class serves as a template for importing the XML document.
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
