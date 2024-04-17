﻿using System;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace WindowsAppCanalyzer
{
    public partial class Form1 : Form
    {
        bool comReady = false;
        bool fileLoaded = false;
        private static SerialPort mySerialPort;
        private OpenFileDialog openFileDialog;

        public Form1()
        {
            InitializeComponent();
            PopulateSerialPortComboBox();
            PopulateBaudRateComboBox();
            InitializeOpenFileDialog();

        }
        private void InitializeOpenFileDialog()
        {
            openFileDialog = new OpenFileDialog
            {
                Title = "Select a DBC file",
                Filter = "DBC files (*.dbc)|*.dbc|All files (*.*)|*.*"
            };
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
            if(!comReady)
            {
                MessageBox.Show("You must initilize COM port first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {

                string hexPattern = "^[0-9A-Fa-f]{3}$";
                if (Regex.IsMatch(textBox2.Text, hexPattern)) // checks to make sure its a 3 digit hex 
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
                else // Incorrect CAN ID
                {
                    DialogResult result = MessageBox.Show("Make sure the CAN ID is the right length it should be 3 digits of HEX ex) FFF, 001 ect.", "CAN ID not correct", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
   
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if(comboBoxCOMPorts.SelectedIndex == -1)
            {
                MessageBox.Show("No COM Port selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                if (comboBoxBaudRates.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select the baud rate (you probably want 9600)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {
                    // this part means that the comboBox is chilling
                    comReady = true;
                    mySerialPort = new SerialPort(comboBoxCOMPorts.SelectedItem.ToString())
                    {
                        BaudRate = Convert.ToInt32(comboBoxBaudRates.SelectedItem),
                        Parity = Parity.None,
                        StopBits = StopBits.One,
                        DataBits = 8,
                        Handshake = Handshake.None
                    };

                    try
                    {
                        mySerialPort.Open();
                        MessageBox.Show("Port opened successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to open serial port: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dbcButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                MessageBox.Show($"File selected: {filePath}", "File Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fileLoaded = true;

            }
        }
    }
}
