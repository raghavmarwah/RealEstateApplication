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
        //Globally defined list to store the linq modifications as per user selections.
        List<House> sortedListOfTransactions;

        public RealEstateTransactionsForm()
        {
            InitializeComponent();
            this.Text = "Assignment 1 Real Estate Transactions";

            //Registering helper functions with ListBox event handlers.
            listBoxCities.SelectedIndexChanged += ListBoxCities_SelectedIndexChanged;
            listBoxNumberOfBedrooms.SelectedIndexChanged += ListBoxNumberOfBedrooms_SelectedIndexChanged;
            listBoxNumberOfBathrooms.SelectedIndexChanged += ListBoxNumberOfBathrooms_SelectedIndexChanged;
            listBoxHouseTypes.SelectedIndexChanged += ListBoxHouseTypes_SelectedIndexChanged;

        }

        private void ListBoxHouseTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataGridViewFilteredTransactions();
        }

        private void ListBoxNumberOfBathrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataGridViewFilteredTransactions();
        }

        private void ListBoxNumberOfBedrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataGridViewFilteredTransactions();
        }

        private void ListBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataGridViewFilteredTransactions();
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

        //Sort data from list using LINQ and feed it to DataGridViews and ListBoxes.
        private void FeedTheDataGridViews()
        {
            //Sorting the data by City, House Type and Price in order.
            var orderedListOfTransactions = initialListOfTransactions
                .OrderBy(data => data.City)
                .ThenBy(data => data.HouseType)
                .ThenBy(data => data.Price)
                .Select(data => data);

            //Converting the query to sorted list for later use.
            sortedListOfTransactions = orderedListOfTransactions.ToList<House>();

            foreach (House tempTransaction in orderedListOfTransactions)
            {
                //Feeding data to DataGridViews
                dataGridViewAllTransactions.Rows.Add(tempTransaction.City, tempTransaction.Address, tempTransaction.Bedrooms, tempTransaction.Bathrooms, tempTransaction.SurfaceArea, tempTransaction.HouseType, tempTransaction.Price);
                dataGridViewFilteredTransactions.Rows.Add(tempTransaction.City, tempTransaction.Address, tempTransaction.Bedrooms, tempTransaction.Bathrooms, tempTransaction.SurfaceArea, tempTransaction.HouseType, tempTransaction.Price);

                //Feeding data to ListBoxes
                if(!listBoxCities.Items.Contains(tempTransaction.City))
                    listBoxCities.Items.Add(tempTransaction.City);
                if (!listBoxHouseTypes.Items.Contains(tempTransaction.HouseType))
                    listBoxHouseTypes.Items.Add(tempTransaction.HouseType);
                if (!listBoxNumberOfBedrooms.Items.Contains(tempTransaction.Bedrooms))
                    listBoxNumberOfBedrooms.Items.Add(tempTransaction.Bedrooms);
                if (!listBoxNumberOfBathrooms.Items.Contains(tempTransaction.Bathrooms))
                    listBoxNumberOfBathrooms.Items.Add(tempTransaction.Bathrooms);

            }

            //Setting ListBoxes to sorted
            listBoxCities.Sorted = true;
            listBoxHouseTypes.Sorted = true;
            listBoxNumberOfBedrooms.Sorted = true;
            listBoxNumberOfBathrooms.Sorted = true;

            //Enabling multi-select for all ListBoxes
            listBoxCities.SelectionMode = SelectionMode.MultiExtended;
            listBoxHouseTypes.SelectionMode = SelectionMode.MultiExtended;
            listBoxNumberOfBedrooms.SelectionMode = SelectionMode.MultiExtended;
            listBoxNumberOfBathrooms.SelectionMode = SelectionMode.MultiExtended;

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

        private void updateDataGridViewFilteredTransactions()
        {
            //Creating a list of selected items in the ListBoxes
            List<string> selectedCities = new List<string>();
            List<string> selectedNumberOfBedrooms = new List<string>();
            List<string> selectedNumberOfBathrooms = new List<string>();
            List<string> selectedHouseTypes = new List<string>();

            //Adding data to above lists
            for (int i = 0; i < listBoxCities.Items.Count; i++)
            {
                if (listBoxCities.GetSelected(i))
                    selectedCities.Add(listBoxCities.Items[i].ToString());
            }
            for (int i = 0; i < listBoxNumberOfBedrooms.Items.Count; i++)
            {
                if (listBoxNumberOfBedrooms.GetSelected(i))
                    selectedNumberOfBedrooms.Add(listBoxNumberOfBedrooms.Items[i].ToString());
            }
            for (int i = 0; i < listBoxNumberOfBathrooms.Items.Count; i++)
            {
                if (listBoxNumberOfBathrooms.GetSelected(i))
                    selectedNumberOfBathrooms.Add(listBoxNumberOfBathrooms.Items[i].ToString());
            }
            for (int i = 0; i < listBoxHouseTypes.Items.Count; i++)
            {
                if (listBoxHouseTypes.GetSelected(i))
                    selectedHouseTypes.Add(listBoxHouseTypes.Items[i].ToString());
            }

            //query to slect all houses from the list
            var finalQuery = sortedListOfTransactions.Select(p => p);

            //multiple independent if conditions for the ListBoxes to work independently and yet function together
            //each condition checks if there are any selected items in the ListBoxes
            //using linq to check if the selected items in the respective ListBoxes also exist in the query to filter results.
            if (selectedCities.Count > 0)
                finalQuery = finalQuery.Where(p => selectedCities.Contains(p.City));
            if (selectedNumberOfBedrooms.Count > 0)
                finalQuery = finalQuery.Where(p => selectedNumberOfBedrooms.Contains(p.Bedrooms.ToString()));
            if (selectedNumberOfBathrooms.Count > 0)
                finalQuery = finalQuery.Where(p => selectedNumberOfBathrooms.Contains(p.Bathrooms.ToString()));
            if (selectedHouseTypes.Count > 0)
                finalQuery = finalQuery.Where(p => selectedHouseTypes.Contains(p.HouseType));

            //Clearing all DataGridView rows
            dataGridViewFilteredTransactions.Rows.Clear();

            //updating the DataGridView with filtered houses
            foreach (House tempTransaction in finalQuery)
            {
                dataGridViewFilteredTransactions.Rows.Add(tempTransaction.City, tempTransaction.Address, tempTransaction.Bedrooms, tempTransaction.Bathrooms, tempTransaction.SurfaceArea, tempTransaction.HouseType, tempTransaction.Price);
            }
            updateCountAndPriceLabelsFiltered(finalQuery.Count(), finalQuery.Average(temp => temp.Price));
        }
    }
}
