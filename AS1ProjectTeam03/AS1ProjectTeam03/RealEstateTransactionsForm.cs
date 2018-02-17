using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
    }
}
