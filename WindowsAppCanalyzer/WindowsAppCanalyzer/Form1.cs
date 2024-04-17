using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace WindowsAppCanalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateSerialPortComboBox();
            PopulateBaudRateComboBox();
        }
        private void PopulateSerialPortComboBox()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxCOMPorts.Items.AddRange(ports);
        }


        private void PopulateBaudRateComboBox()
        {
            int[] baudRates = new int[] { 9600, 19200, 38400, 57600, 115200 };
            foreach (int rate in baudRates)
            {
                comboBoxBaudRates.Items.Add(rate);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to send this message?", "Warning! Sending incorrect messages can be fatal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                // Send the message (you can add your logic here)
                MessageBox.Show("Message sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("I guess you didn't want to send it afterall", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
