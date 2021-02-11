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

//February 11,2021 Miguel.M CashRegister (Security Systems Shop)
namespace CashRegister
{
    public partial class securitySystemsShop : Form
    {
        // All global variables
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
            SoundPlayer button_Press = new SoundPlayer(Properties.Resources.button_Press);
            button_Press.Play();

            try
            {
               
                //Getting the input number fromt he three text boxes
                numberOfSecurityCameras = Convert.ToInt32(securityCamerasInput.Text);
                numberOfAlarms = Convert.ToInt32(alarmsInput.Text);
                numberOfMotionScanners = Convert.ToInt32(motionScannerInput.Text);

                //Calculations 
                totalCost = securityCamerasPrice * numberOfSecurityCameras + alarmsPrice * numberOfAlarms + motionScannerPrice * numberOfMotionScanners;
                taxAmount = totalCost * tax;
                totalTaxCost = totalCost + taxAmount;

                //Displaying the results from calculating 
                subTotalOutput.Text = $"{totalCost.ToString("$.00")}";
                taxOutput.Text = $"{taxAmount.ToString("$.00")}";
                totalOutput.Text = $"{totalTaxCost.ToString("$.00")}";

                calculateTotalsButton.Enabled = false;
                calculateChangeButton.Enabled = true;

                securityCamerasInput.Enabled = false;
                alarmsInput.Enabled = false;
                motionScannerInput.Enabled = false;

            }
            catch
            {
                //Any non-number will result in a error with a beep sound + makes the user have to press new order button in order to start over
                SoundPlayer Beep_Ping = new SoundPlayer(Properties.Resources.Beep_Ping);
                Beep_Ping.Play();
                securityCamerasInput.Text = "Error";
                alarmsInput.Text = "Error";
                motionScannerInput.Text = "Error";
                calculateTotalsButton.Enabled = false;
                newOrderButton.Enabled = true;
                newOrderButton.Focus();

            }




        }

        private void CalculateChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer button_Press = new SoundPlayer(Properties.Resources.button_Press);
                button_Press.Play();

                //Calculation for tendered and change
                tenderedAmount = Convert.ToInt32(tenderedInput.Text);
                change = tenderedAmount - totalTaxCost;
                changedOutput.Text = $"{change.ToString("$.00")}";

                printReceiptButten.Enabled = true;
                calculateTotalsButton.Enabled = false;
                calculateChangeButton.Enabled = false;
                tenderedInput.Enabled = false;
            }
            catch
            {
                //Any non-number will result in a error with a beep sound + the tenderedInput box will be highlighted
                SoundPlayer Beep_Ping = new SoundPlayer(Properties.Resources.Beep_Ping);
                Beep_Ping.Play();
                tenderedInput.Text = "Error";
                tenderedInput.Focus();
            }
        }

      

        private void PrintReceiptButten_Click(object sender, EventArgs e)
        {
            calculateTotalsButton.Enabled = false;
            calculateChangeButton.Enabled = false;
            printReceiptButten.Enabled = false;

            SoundPlayer Dot_Matrix_Printer = new SoundPlayer(Properties.Resources.Dot_Matrix_Printer);
            Dot_Matrix_Printer.Play();

            //Display title, order number, and date in one group + sounds 
            receiptOutput.Text = $"\n\n                     Security Systems Shop";
            receiptOutput.Refresh();
            Thread.Sleep(1000);
            receiptOutput.Text += $"\n\n Order Number 106";
            receiptOutput.Refresh();
            Thread.Sleep(1000);
            receiptOutput.Text += $"\n Fedruary 11, 2021";
            Dot_Matrix_Printer.Play();
            receiptOutput.Refresh();
            Thread.Sleep(1000);

            //Display the number and price for security cameras, alarms, and motion scanners in one group + sound
            receiptOutput.Text += $"\n\n Security Cameras x{numberOfSecurityCameras} @ {securityCamerasPrice.ToString("$.00")}";
            receiptOutput.Refresh();
            Thread.Sleep(1000);
            receiptOutput.Text += $"\n                    Alarms x{numberOfAlarms} @ {alarmsPrice.ToString("$.00")}";
            Dot_Matrix_Printer.Play();
            receiptOutput.Refresh();
            Thread.Sleep(1000);
            receiptOutput.Text += $"\n Motion Scanners  x{numberOfMotionScanners} @ {motionScannerPrice.ToString("$.00")}";

            //Display the sub total, tax, and total + sound      
            receiptOutput.Refresh();
            Thread.Sleep(1000);
            receiptOutput.Text += $"\n\n Sub Total                          {totalCost.ToString("$.00")}";
            Dot_Matrix_Printer.Play();
            receiptOutput.Refresh();
            Thread.Sleep(1000);
            receiptOutput.Text += $"\n Tax                                     {taxAmount.ToString("$.00")}";
            receiptOutput.Refresh();
            Thread.Sleep(1000);
            receiptOutput.Text += $"\n Total                                  {totalTaxCost.ToString("$.00")}";
            Dot_Matrix_Printer.Play();
            receiptOutput.Refresh();
            Thread.Sleep(1000);

            //Display the tendered, the change, and a farewell message 
            receiptOutput.Text += $"\n\n Tendered                         {tenderedAmount.ToString("$.00")}";
            receiptOutput.Refresh();
            Thread.Sleep(1000);
            receiptOutput.Text += $"\n Change                            {change.ToString("$.00")}";
            Dot_Matrix_Printer.Play();
            receiptOutput.Refresh();
            Thread.Sleep(1000);
            receiptOutput.Text += $"\n\n Hope you have a secure time!";
            cameraImage.Visible = true;

            newOrderButton.Enabled = true;
        }
        private void NewOrderButton_Click(object sender, EventArgs e)
        {
            SoundPlayer glass_ping = new SoundPlayer(Properties.Resources.glass_ping);
            glass_ping.Play();

            //Resets all variables to none (to not let the user use the past variables, buttons are locked until another inputs have been entered)
            securityCamerasInput.Text = "";
            alarmsInput.Text = "";
            motionScannerInput.Text = "";

            subTotalOutput.Text = "";
            taxOutput.Text = "";
            totalOutput.Text = "";

            tenderedInput.Text = "";
            changedOutput.Text = "";

            receiptOutput.Text = "";

            cameraImage.Visible = false;

            calculateChangeButton.Enabled = false;
            printReceiptButten.Enabled = false;
            newOrderButton.Enabled = false;
            calculateTotalsButton.Enabled = true;

            tenderedInput.Enabled = true;
            securityCamerasInput.Enabled = true;
            alarmsInput.Enabled = true;
            motionScannerInput.Enabled = true;

        }

    }
}
