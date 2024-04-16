using System;
using System.IO.Ports;
using DbcParserLib;
using DbcParserLib.Model;
using Microsoft.VisualBasic.ApplicationServices;

class Program
{
    static void Main(string[] args)
    {
        //string dbcFilePath = "C:\\Users\\egalluzzi3\\Downloads\\tesla_can.dbc";
        try
        {

            Dbc dbc = Parser.ParseFromPath("C:\\Users\\Eric\\OneDrive - Georgia Institute of Technology\\DBCParserTest\\DBCparserTest\\hytech.dbc");
            int messageCount = dbc.Messages.Count();
            Console.WriteLine($"DBC file parsed successfully: {messageCount} messages found.");
            foreach (var message in dbc.Messages)
            {
                Console.WriteLine($"Message ID: {message.ID}");
                foreach (var signal in message.Signals)
                {
                    Console.WriteLine($" Signal Name: {signal.Name}, Start Bit: {signal.StartBit}, Length: {signal.Length}, Factor: {signal.Factor}, Offset: {signal.Offset}, Unit: {signal.Unit}");
                }
            }
            Signal sig = new Signal();
            sig.Length = 14;
            sig.StartBit = 3;
            sig.ByteOrder = 1;
            sig.Factor = 0.01;
            sig.Offset = 20;
            ulong TxMsg = Packer.TxSignalPack(-34.3, sig);
            double val = Packer.RxSignalUnpack(TxMsg, sig);
            Console.WriteLine($"{val}");
            SerialPort mySerialPort = new SerialPort("COM8");
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            //mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            mySerialPort.Open();
            
            while (true)
            {
                try
                {
                    if (!mySerialPort.IsOpen)
                    {
                        continue;
                    }
                    if (mySerialPort.BytesToRead > 0)
                    {
                        string data = mySerialPort.ReadLine();
                        //Console.WriteLine(data);
                        string[] dataParts = data.Split('!');
                        if(dataParts.Length >= 2)
                        {
                            foreach(var message in dbc.Messages)
                            {
                             
                                uint id = uint.Parse(dataParts[0], System.Globalization.NumberStyles.HexNumber);
                                if (id == message.ID)
                                {
                                    Console.WriteLine($"Message Name: {message.Name}, Message ID: {dataParts[0]}");
                                    ulong txMsg = ulong.Parse(dataParts[1], System.Globalization.NumberStyles.HexNumber);
                                    foreach (var signal in message.Signals)
                                    {
                                        double rxMsg = Packer.RxSignalUnpack(txMsg, signal);
                                        Console.WriteLine($"{signal.Name} : {rxMsg}");
                                    }
                                    Console.WriteLine();
                                    break;
                                }
                            }
                        } 
                        

                        Thread.Sleep(10);
                    }
                }catch (Exception ex)
                {
                   Console.WriteLine($"Error parsing DBC fle: {ex.Message}");
                }
                
            }
            mySerialPort.Close();




        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing DBC fle: {ex.Message}");
        }
    }
    private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string indata = sp.ReadExisting();
        Console.WriteLine(indata);
    }
}