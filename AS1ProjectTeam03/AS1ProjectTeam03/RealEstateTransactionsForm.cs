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

            //Registering helper functions with TextBox event handlers.
            textBoxMinPrice.TextChanged += TextBoxMinPrice_TextChanged;
            textBoxMaxPrice.TextChanged += TextBoxMaxPrice_TextChanged;
            textBoxMinArea.TextChanged += TextBoxMinArea_TextChanged;
            textBoxMaxArea.TextChanged += TextBoxMaxArea_TextChanged;

            //Registering helper functions with CheckBox event handlers.
            checkBoxSearchOnPrice.CheckedChanged += CheckBoxSearchOnPrice_CheckedChanged;
            checkBoxSearchOnArea.CheckedChanged += CheckBoxSearchOnArea_CheckedChanged;

        }

        private void CheckBoxSearchOnArea_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSearchOnArea.Checked)
                UpdateDataGridViewFilteredTransactions();
        }

        private void CheckBoxSearchOnPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSearchOnPrice.Checked)
                UpdateDataGridViewFilteredTransactions();
        }

        private void TextBoxMaxArea_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxSearchOnArea.Checked)
                UpdateDataGridViewFilteredTransactions();
        }

        private void TextBoxMinArea_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxSearchOnArea.Checked)
                UpdateDataGridViewFilteredTransactions();
        }

        private void TextBoxMaxPrice_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxSearchOnPrice.Checked)
                UpdateDataGridViewFilteredTransactions();
        }

        private void TextBoxMinPrice_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxSearchOnPrice.Checked)
                UpdateDataGridViewFilteredTransactions();
        }

        private void ListBoxHouseTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewFilteredTransactions();
        }

        private void ListBoxNumberOfBathrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewFilteredTransactions();
        }

        private void ListBoxNumberOfBedrooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewFilteredTransactions();
        }

        private void ListBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridViewFilteredTransactions();
        }

        private void RealEstateTransactionsForm_Load(object sender, EventArgs e)
        {
            this.Width = 720;
            this.Height = 770;

            InitializeBothDataGridViews();
            GetRentalHousingFromXML();
            FeedTheData();

            //by default all the options in ListBoxes need to be selected
            for (int i = 0; i < listBoxCities.Items.Count; i++)
                listBoxCities.SetSelected(i, true);
            for (int i = 0; i < listBoxNumberOfBedrooms.Items.Count; i++)
                listBoxNumberOfBedrooms.SetSelected(i, true);
            for (int i = 0; i < listBoxNumberOfBathrooms.Items.Count; i++)
                listBoxNumberOfBathrooms.SetSelected(i, true);
            for (int i = 0; i < listBoxHouseTypes.Items.Count; i++)
                listBoxHouseTypes.SetSelected(i, true);


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
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }

        }

        //Sort data from list using LINQ and feed it to DataGridViews and ListBoxes.
        private void FeedTheData()
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
                
            }

            //Feeding data to ListBoxes using linq
            var queryCities = initialListOfTransactions.Select(p => p.City).Distinct();
            foreach(var temp in queryCities)
                listBoxCities.Items.Add(temp.ToString());

            var queryBedrooms = initialListOfTransactions.Select(p => p.Bedrooms).Distinct();
            foreach (var temp in queryBedrooms)
                listBoxNumberOfBedrooms.Items.Add(temp.ToString());

            var queryBathrooms = initialListOfTransactions.Select(p => p.Bathrooms).Distinct();
            foreach (var temp in queryBathrooms)
                listBoxNumberOfBathrooms.Items.Add(temp.ToString());

            var queryHouse = initialListOfTransactions.Select(p => p.HouseType).Distinct();
            foreach (var temp in queryHouse)
                listBoxHouseTypes.Items.Add(temp.ToString());

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
            if (orderedListOfTransactions.Count() > 0)
            {
                UpdateCountAndPriceLabels(orderedListOfTransactions.Count(), orderedListOfTransactions.Average(temp => temp.Price));
                UpdateCountAndPriceLabelsFiltered(orderedListOfTransactions.Count(), orderedListOfTransactions.Average(temp => temp.Price));
            }
            else
            {
                UpdateCountAndPriceLabels(0,0);
                UpdateCountAndPriceLabelsFiltered(0,0);
            }
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

        private void UpdateCountAndPriceLabels(int count, double averagePrice)
        {
            labelAllTransactionsCount.Text = count.ToString();
            labelAllTransactionsAveragePrice.Text = averagePrice.ToString("c2");
        }
        private void UpdateCountAndPriceLabelsFiltered(int count, double averagePrice)
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

        private void UpdateDataGridViewFilteredTransactions()
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

            //checking price constraint
            try
            {
                if (checkBoxSearchOnPrice.Checked)
                {
                    //using double just to be safe!
                    double minPrice = double.Parse(textBoxMinPrice.Text);
                    double maxPrice = double.Parse(textBoxMaxPrice.Text);
                    finalQuery = finalQuery.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Price is missing or is not an integer");
                checkBoxSearchOnPrice.Checked = false;
            }

            //checkig surface area constraint
            try
            {
                if (checkBoxSearchOnArea.Checked)
                {
                    //using double just to be safe!
                    double minArea = double.Parse(textBoxMinArea.Text);
                    double maxArea = double.Parse(textBoxMaxArea.Text);
                    finalQuery = finalQuery.Where(p => p.SurfaceArea >= minArea && p.SurfaceArea <= maxArea);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Surface Area is missing or is not an integer");
                checkBoxSearchOnArea.Checked = false;
            }

            //Clearing all DataGridView rows
            dataGridViewFilteredTransactions.Rows.Clear();

            //updating the DataGridView with filtered houses
            foreach (House tempTransaction in finalQuery)
            {
                dataGridViewFilteredTransactions.Rows.Add(tempTransaction.City, tempTransaction.Address, tempTransaction.Bedrooms, tempTransaction.Bathrooms, tempTransaction.SurfaceArea, tempTransaction.HouseType, tempTransaction.Price);
            }
            if(finalQuery.Count()>0)
                UpdateCountAndPriceLabelsFiltered(finalQuery.Count(), finalQuery.Average(temp => temp.Price));
            else
                UpdateCountAndPriceLabelsFiltered(0,0);
        }

        //method to bring the form to the initial state
        private void buttonResetFilters_Click(object sender, EventArgs e)
        {
            checkBoxSearchOnArea.Checked = false;
            checkBoxSearchOnPrice.Checked = false;
            textBoxMinPrice.Text = "";
            textBoxMaxPrice.Text = "";
            textBoxMinArea.Text = "";
            textBoxMaxArea.Text = "";

            listBoxCities.Items.Clear();
            listBoxNumberOfBedrooms.Items.Clear();
            listBoxNumberOfBathrooms.Items.Clear();
            listBoxHouseTypes.Items.Clear();

            InitializeBothDataGridViews();
            FeedTheData();

            //by default all the options in ListBoxes need to be selected
            for (int i = 0; i < listBoxCities.Items.Count; i++)
                listBoxCities.SetSelected(i, true);
            for (int i = 0; i < listBoxNumberOfBedrooms.Items.Count; i++)
                listBoxNumberOfBedrooms.SetSelected(i, true);
            for (int i = 0; i < listBoxNumberOfBathrooms.Items.Count; i++)
                listBoxNumberOfBathrooms.SetSelected(i, true);
            for (int i = 0; i < listBoxHouseTypes.Items.Count; i++)
                listBoxHouseTypes.SetSelected(i, true);
        }
    }
}
