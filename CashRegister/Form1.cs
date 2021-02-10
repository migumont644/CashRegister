using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace CashRegister
{
    public partial class securitySystemsShop : Form
    {
        double securityCamerasPrice = 22.99;
        double alarmsPrice = 82.48;
        double motionScannerPrice = 15.00;
        int numberOfSecurityCameras;
        int numberOfAlarms;
        int numberOfMotionScanners;
        double totalCost;
        double tax = 0.13;
        double taxAmount;
        double totalTaxCost;
        double tenderedAmount;
        double change;

        public securitySystemsShop()
        {
            InitializeComponent();
        }

        private void CalculateTotalsButton_Click(object sender, EventArgs e)
        {
            numberOfSecurityCameras = Convert.ToInt32(securityCamerasInput.Text);
            numberOfAlarms = Convert.ToInt32(alarmsInput.Text);
            numberOfMotionScanners = Convert.ToInt32(motionScannerInput.Text);

            totalCost = securityCamerasPrice * numberOfSecurityCameras + alarmsPrice * numberOfAlarms + motionScannerPrice * numberOfMotionScanners;
            taxAmount = totalCost * tax;
            totalTaxCost = totalCost + taxAmount;

            subTotalOutput.Text = $"{totalCost.ToString("$.00")}";
            taxOutput.Text = $"{taxAmount.ToString("$.00")}";
            totalOutput.Text = $"{totalTaxCost.ToString("$.00")}";


        }

        private void CalculateChangeButton_Click(object sender, EventArgs e)
        {
            tenderedAmount = Convert.ToInt32(tenderedInput.Text);
            change = tenderedAmount - totalTaxCost;
            changedOutput.Text = $"{change.ToString("$.00")}";
        }

        private void NewOrderButton_Click(object sender, EventArgs e)
        {
            securityCamerasInput.Text = "0";
            alarmsInput.Text = "0";
            motionScannerInput.Text = "0";

            subTotalOutput.Text = "$0.00";
            taxOutput.Text = "$0.00";
            totalOutput.Text = "$0.00";

            tenderedInput.Text = "0";
            changedOutput.Text = "$0.00";
        }

        private void PrintReceiptButten_Click(object sender, EventArgs e)
        {
            receiptOutput.Text = $"\n\n                     Security Systems Shop";
            Thread.Sleep(2000);
           // receiptOutput.Text = $"\n "
        }
    }
}
