using System;
using System.IO.Ports;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Windows.Forms;
//using DbcParserLib;


namespace WindowsAppCanalyzer
{
    public partial class Form1 : Form
    {
        bool comReady = false;
        bool fileLoaded = false;
        private static SerialPort mySerialPort;
        private OpenFileDialog openFileDialog;
        private int load = 0;


        public Form1()
        {
            InitializeComponent();
            PopulateSerialPortComboBox();
            PopulateBaudRateComboBox();
            InitializeOpenFileDialog();
            UpdateAll();
        }
        private void UpdateAll()
        {
            UpdateProgressBar(load);
            if(comReady & !fileLoaded)
            {
                //raw output

            } else
            {
                if(comReady)
                {
                    //Parse DBC output
                }
            }
        }
        private void DisplayData(string text)
        {
            if (textBoxSerialData.InvokeRequired) // used to not get that threading error
            {
                textBoxSerialData.Invoke(new MethodInvoker(delegate
                {
                    textBoxSerialData.AppendText(text + Environment.NewLine);
                    textBoxSerialData.ScrollToCaret();
                }));
            }
            else
            {
                textBoxSerialData.AppendText(text + Environment.NewLine);
                textBoxSerialData.ScrollToCaret();
            }

        }
        private void InitializeOpenFileDialog()
        {
            openFileDialog = new OpenFileDialog
            {
                Title = "Select a DBC file",
                Filter = "DBC files (*.dbc)|*.dbc|All files (*.*)|*.*"
            };
            UpdateProgressBar(load);
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
                    MessageBox.Show("Make sure the CAN ID is the right length it should be 3 digits of HEX ex) FFF, 001 ect.", "CAN ID not correct", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
   
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void runPressed()
        {
            if (comboBoxCOMPorts.SelectedIndex == -1)
            {
                MessageBox.Show("No COM Port selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (comboBoxBaudRates.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select the baud rate (you probably want 9600)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ConfigureSerialPort();
                    // this part means that the comboBox is chilling
                    try
                    {
                        mySerialPort.Open();
                        MessageBox.Show("Port opened successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        mySerialPort.Close();
                        MessageBox.Show($"Failed to open serial port: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            runPressed();
        }

        private void dbcButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                MessageBox.Show($"File selected: {filePath}", "File Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try {
                    
                    //Dbc dbc = Parser.ParseFromPath(filePath);
                   // fileLoaded = true;
                   fileLoaded = true;
                } catch (Exception ex)
                {
                    MessageBox.Show("Error in DBC file Parsing");
                }
                
                

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void UpdateProgressBar(int loadValue)
        {   if (loadValue > 100)
            {
                loadValue = 100;
            }
            progressBar1.Value = loadValue;
            label3.Text = $"Load: {loadValue}%"; // Updates the label with the load value
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void ConfigureSerialPort()
        {
            if (mySerialPort != null)
            {
                if (mySerialPort.IsOpen)
                {
                    mySerialPort.DataReceived -= mySerialPort_DataReceived;
                    mySerialPort.Close();
                }
                mySerialPort.Dispose(); // Optional based on your application needs
            }
            comReady = true;
            mySerialPort = new SerialPort(comboBoxCOMPorts.SelectedItem.ToString())
            {
                BaudRate = Convert.ToInt32(comboBoxBaudRates.SelectedItem),
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.None
            };

            mySerialPort.DataReceived += mySerialPort_DataReceived;
        }
        private bool checkLoadMessage(string data)
        {
            var match = Regex.Match(data, @"The can load is: (\d+)%");
            if (match.Success)
            {
                // Parse the number from the first capturing group
                if (int.TryParse(match.Groups[1].Value, out int newLoad))
                {
                    load = newLoad; // Update the global load variable
                    UpdateProgressBar(load); // Update the progress bar accordingly
                }
            }
            return !(match.Success);
        }
        
        private void mySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string inData = mySerialPort.ReadLine();
                if(checkLoadMessage(inData))
                {
                    Invoke((MethodInvoker)delegate
                    {
                        DisplayData(inData); // Safely update the UI from the UI thread
                    });
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show($"Error during data reception: {ex.Message}", "Serial Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!mySerialPort.IsOpen)
                {
                    ConfigureSerialPort();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            runPressed();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (comReady)
            {
                comReady = false;
                if (mySerialPort != null)
                {
                    if (mySerialPort.IsOpen)
                    {
                        mySerialPort.DataReceived -= mySerialPort_DataReceived;
                        mySerialPort.Close();
                    }
                    mySerialPort.Dispose(); // Optional based on your application needs
                }

            }
        }
    }
}
