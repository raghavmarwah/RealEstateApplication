namespace AS1ProjectTeam03
{
    partial class RealEstateTransactionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewAllTransactions = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAllTransactionsCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAllTransactionsAveragePrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonResetFilters = new System.Windows.Forms.Button();
            this.listBoxCities = new System.Windows.Forms.ListBox();
            this.listBoxNumberOfBedrooms = new System.Windows.Forms.ListBox();
            this.listBoxNumberOfbathrooms = new System.Windows.Forms.ListBox();
            this.listBoxHouseTypes = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxMinPrice = new System.Windows.Forms.TextBox();
            this.textBoxMaxPrice = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxMaxArea = new System.Windows.Forms.TextBox();
            this.textBoxMinArea = new System.Windows.Forms.TextBox();
            this.checkBoxSearchOnPrice = new System.Windows.Forms.CheckBox();
            this.checkBoxSearchOnArea = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dataGridViewFilteredTransactions = new System.Windows.Forms.DataGridView();
            this.labelFilteredTransactionsAveragePrice = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.labelFilteredTransactionsCount = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilteredTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Transactions";
            // 
            // dataGridViewAllTransactions
            // 
            this.dataGridViewAllTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllTransactions.Location = new System.Drawing.Point(13, 46);
            this.dataGridViewAllTransactions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewAllTransactions.Name = "dataGridViewAllTransactions";
            this.dataGridViewAllTransactions.RowTemplate.Height = 37;
            this.dataGridViewAllTransactions.Size = new System.Drawing.Size(1292, 309);
            this.dataGridViewAllTransactions.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Count = ";
            // 
            // labelAllTransactionsCount
            // 
            this.labelAllTransactionsCount.AutoSize = true;
            this.labelAllTransactionsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAllTransactionsCount.Location = new System.Drawing.Point(280, 385);
            this.labelAllTransactionsCount.Name = "labelAllTransactionsCount";
            this.labelAllTransactionsCount.Size = new System.Drawing.Size(2, 27);
            this.labelAllTransactionsCount.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(615, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Average Price = ";
            // 
            // labelAllTransactionsAveragePrice
            // 
            this.labelAllTransactionsAveragePrice.AutoSize = true;
            this.labelAllTransactionsAveragePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAllTransactionsAveragePrice.Location = new System.Drawing.Point(783, 385);
            this.labelAllTransactionsAveragePrice.Name = "labelAllTransactionsAveragePrice";
            this.labelAllTransactionsAveragePrice.Size = new System.Drawing.Size(2, 27);
            this.labelAllTransactionsAveragePrice.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 446);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 28);
            this.label6.TabIndex = 6;
            this.label6.Text = "Filters";
            // 
            // buttonResetFilters
            // 
            this.buttonResetFilters.Location = new System.Drawing.Point(359, 446);
            this.buttonResetFilters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonResetFilters.Name = "buttonResetFilters";
            this.buttonResetFilters.Size = new System.Drawing.Size(195, 38);
            this.buttonResetFilters.TabIndex = 7;
            this.buttonResetFilters.Text = "Reset Filters";
            this.buttonResetFilters.UseVisualStyleBackColor = true;
            // 
            // listBoxCities
            // 
            this.listBoxCities.FormattingEnabled = true;
            this.listBoxCities.ItemHeight = 25;
            this.listBoxCities.Location = new System.Drawing.Point(13, 546);
            this.listBoxCities.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxCities.Name = "listBoxCities";
            this.listBoxCities.Size = new System.Drawing.Size(407, 229);
            this.listBoxCities.TabIndex = 8;
            // 
            // listBoxNumberOfBedrooms
            // 
            this.listBoxNumberOfBedrooms.FormattingEnabled = true;
            this.listBoxNumberOfBedrooms.ItemHeight = 25;
            this.listBoxNumberOfBedrooms.Location = new System.Drawing.Point(515, 546);
            this.listBoxNumberOfBedrooms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxNumberOfBedrooms.Name = "listBoxNumberOfBedrooms";
            this.listBoxNumberOfBedrooms.Size = new System.Drawing.Size(132, 229);
            this.listBoxNumberOfBedrooms.TabIndex = 9;
            // 
            // listBoxNumberOfbathrooms
            // 
            this.listBoxNumberOfbathrooms.FormattingEnabled = true;
            this.listBoxNumberOfbathrooms.ItemHeight = 25;
            this.listBoxNumberOfbathrooms.Location = new System.Drawing.Point(740, 546);
            this.listBoxNumberOfbathrooms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxNumberOfbathrooms.Name = "listBoxNumberOfbathrooms";
            this.listBoxNumberOfbathrooms.Size = new System.Drawing.Size(127, 229);
            this.listBoxNumberOfbathrooms.TabIndex = 10;
            // 
            // listBoxHouseTypes
            // 
            this.listBoxHouseTypes.FormattingEnabled = true;
            this.listBoxHouseTypes.ItemHeight = 25;
            this.listBoxHouseTypes.Location = new System.Drawing.Point(961, 546);
            this.listBoxHouseTypes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxHouseTypes.Name = "listBoxHouseTypes";
            this.listBoxHouseTypes.Size = new System.Drawing.Size(221, 229);
            this.listBoxHouseTypes.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 508);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Cities";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(509, 508);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "Bedrooms";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(736, 508);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 25);
            this.label9.TabIndex = 14;
            this.label9.Text = "Bathrooms";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(957, 510);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 25);
            this.label10.TabIndex = 15;
            this.label10.Text = "House Types";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(11, 808);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 27);
            this.label11.TabIndex = 16;
            this.label11.Text = "Price";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(124, 808);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 25);
            this.label12.TabIndex = 17;
            this.label12.Text = "Min";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(124, 874);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 25);
            this.label13.TabIndex = 18;
            this.label13.Text = "Max";
            // 
            // textBoxMinPrice
            // 
            this.textBoxMinPrice.Location = new System.Drawing.Point(200, 808);
            this.textBoxMinPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMinPrice.Name = "textBoxMinPrice";
            this.textBoxMinPrice.Size = new System.Drawing.Size(205, 31);
            this.textBoxMinPrice.TabIndex = 19;
            // 
            // textBoxMaxPrice
            // 
            this.textBoxMaxPrice.Location = new System.Drawing.Point(200, 871);
            this.textBoxMaxPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMaxPrice.Name = "textBoxMaxPrice";
            this.textBoxMaxPrice.Size = new System.Drawing.Size(203, 31);
            this.textBoxMaxPrice.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(572, 810);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(139, 27);
            this.label14.TabIndex = 21;
            this.label14.Text = "Surface Area";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(753, 874);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 25);
            this.label15.TabIndex = 23;
            this.label15.Text = "Max";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(753, 808);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 25);
            this.label16.TabIndex = 22;
            this.label16.Text = "Min";
            // 
            // textBoxMaxArea
            // 
            this.textBoxMaxArea.Location = new System.Drawing.Point(833, 871);
            this.textBoxMaxArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMaxArea.Name = "textBoxMaxArea";
            this.textBoxMaxArea.Size = new System.Drawing.Size(203, 31);
            this.textBoxMaxArea.TabIndex = 25;
            // 
            // textBoxMinArea
            // 
            this.textBoxMinArea.Location = new System.Drawing.Point(833, 808);
            this.textBoxMinArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMinArea.Name = "textBoxMinArea";
            this.textBoxMinArea.Size = new System.Drawing.Size(205, 31);
            this.textBoxMinArea.TabIndex = 24;
            // 
            // checkBoxSearchOnPrice
            // 
            this.checkBoxSearchOnPrice.AutoSize = true;
            this.checkBoxSearchOnPrice.Location = new System.Drawing.Point(204, 934);
            this.checkBoxSearchOnPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxSearchOnPrice.Name = "checkBoxSearchOnPrice";
            this.checkBoxSearchOnPrice.Size = new System.Drawing.Size(197, 29);
            this.checkBoxSearchOnPrice.TabIndex = 26;
            this.checkBoxSearchOnPrice.Text = "Search on Price";
            this.checkBoxSearchOnPrice.UseVisualStyleBackColor = true;
            // 
            // checkBoxSearchOnArea
            // 
            this.checkBoxSearchOnArea.AutoSize = true;
            this.checkBoxSearchOnArea.Location = new System.Drawing.Point(840, 934);
            this.checkBoxSearchOnArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxSearchOnArea.Name = "checkBoxSearchOnArea";
            this.checkBoxSearchOnArea.Size = new System.Drawing.Size(273, 29);
            this.checkBoxSearchOnArea.TabIndex = 27;
            this.checkBoxSearchOnArea.Text = "Search on Surface Area";
            this.checkBoxSearchOnArea.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(15, 1010);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(249, 28);
            this.label17.TabIndex = 28;
            this.label17.Text = "Selected Transactions";
            // 
            // dataGridViewFilteredTransactions
            // 
            this.dataGridViewFilteredTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilteredTransactions.Location = new System.Drawing.Point(16, 1060);
            this.dataGridViewFilteredTransactions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewFilteredTransactions.Name = "dataGridViewFilteredTransactions";
            this.dataGridViewFilteredTransactions.RowTemplate.Height = 37;
            this.dataGridViewFilteredTransactions.Size = new System.Drawing.Size(1289, 261);
            this.dataGridViewFilteredTransactions.TabIndex = 29;
            // 
            // labelFilteredTransactionsAveragePrice
            // 
            this.labelFilteredTransactionsAveragePrice.AutoSize = true;
            this.labelFilteredTransactionsAveragePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFilteredTransactionsAveragePrice.Location = new System.Drawing.Point(783, 1345);
            this.labelFilteredTransactionsAveragePrice.Name = "labelFilteredTransactionsAveragePrice";
            this.labelFilteredTransactionsAveragePrice.Size = new System.Drawing.Size(2, 27);
            this.labelFilteredTransactionsAveragePrice.TabIndex = 33;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(615, 1345);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(171, 25);
            this.label19.TabIndex = 32;
            this.label19.Text = "Average Price = ";
            // 
            // labelFilteredTransactionsCount
            // 
            this.labelFilteredTransactionsCount.AutoSize = true;
            this.labelFilteredTransactionsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFilteredTransactionsCount.Location = new System.Drawing.Point(280, 1345);
            this.labelFilteredTransactionsCount.Name = "labelFilteredTransactionsCount";
            this.labelFilteredTransactionsCount.Size = new System.Drawing.Size(2, 27);
            this.labelFilteredTransactionsCount.TabIndex = 31;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(187, 1345);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(93, 25);
            this.label21.TabIndex = 30;
            this.label21.Text = "Count = ";
            // 
            // RealEstateTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1353, 1305);
            this.Controls.Add(this.labelFilteredTransactionsAveragePrice);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.labelFilteredTransactionsCount);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dataGridViewFilteredTransactions);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.checkBoxSearchOnArea);
            this.Controls.Add(this.checkBoxSearchOnPrice);
            this.Controls.Add(this.textBoxMaxArea);
            this.Controls.Add(this.textBoxMinArea);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxMaxPrice);
            this.Controls.Add(this.textBoxMinPrice);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBoxHouseTypes);
            this.Controls.Add(this.listBoxNumberOfbathrooms);
            this.Controls.Add(this.listBoxNumberOfBedrooms);
            this.Controls.Add(this.listBoxCities);
            this.Controls.Add(this.buttonResetFilters);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelAllTransactionsAveragePrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelAllTransactionsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewAllTransactions);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RealEstateTransactionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.RealEstateTransactionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilteredTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewAllTransactions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAllTransactionsCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAllTransactionsAveragePrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonResetFilters;
        private System.Windows.Forms.ListBox listBoxCities;
        private System.Windows.Forms.ListBox listBoxNumberOfBedrooms;
        private System.Windows.Forms.ListBox listBoxNumberOfbathrooms;
        private System.Windows.Forms.ListBox listBoxHouseTypes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxMinPrice;
        private System.Windows.Forms.TextBox textBoxMaxPrice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxMaxArea;
        private System.Windows.Forms.TextBox textBoxMinArea;
        private System.Windows.Forms.CheckBox checkBoxSearchOnPrice;
        private System.Windows.Forms.CheckBox checkBoxSearchOnArea;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dataGridViewFilteredTransactions;
        private System.Windows.Forms.Label labelFilteredTransactionsAveragePrice;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label labelFilteredTransactionsCount;
        private System.Windows.Forms.Label label21;
    }
}

