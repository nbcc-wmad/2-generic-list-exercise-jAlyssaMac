using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericListMotorEx
{
    public struct Motor
    {
        public string motorId;
        public string description;
        public int rpm;
        public int voltage;
        public string status;
    }

    public partial class Form1 : Form
    {
        private Motor motor;
        private List<Motor> allMotors = new List<Motor>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                motor.motorId = txtMotorId.Text.Trim();
                motor.description = txtDesc.Text.Trim();
                motor.rpm = Convert.ToInt32(txtRPM.Text.Trim());
                motor.voltage = Convert.ToInt32(txtVoltage.Text.Trim());

                foreach (RadioButton radio in this.grpStatus.Controls)
                {
                    if (radio.Checked)
                    {
                        motor.status = radio.Text;
                    }
                }

                allMotors.Add(motor);

                foreach (TextBox tb in this.Controls)
                {
                    tb.Text = string.Empty;
                }

                txtMotorId.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintMotorList(Convert.ToInt32(txtMotorToPrint.Text.Trim()) - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private bool isValid()
        {


            return true;
        }

        private void PrintMotorList(int? ordinal = null)
        {
            string message = string.Empty;

            if (ordinal == null)
            {
                //print all motors in foreach
                foreach (Motor motor in allMotors)
                {
                    message += $"{motor.motorId} {motor.description} {motor.rpm} {motor.voltage} {motor.status}";
                }
            }
            else
            {
                if (ordinal > allMotors.Count - 1)
                {
                    MessageBox.Show("Ordinal provided is beyond the size of the list.");
                    return;
                }
                else
                {
                    Motor motor = allMotors[ordinal.GetValueOrDefault()];
                    message += $"{motor.motorId} {motor.description} {motor.rpm} {motor.voltage} {motor.status}";
                }
            }

            MessageBox.Show(message);
        }

    }
}
