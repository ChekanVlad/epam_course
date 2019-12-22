using System;
using System.Net.Sockets;
using System.Text;
using System.IO;
using static Classes.TextWork;

namespace Client
{
    class Program
    {
        const int port = 8888;
        const string address = "127.0.0.1";
        delegate string Message(string text);
        static void Main(string[] args)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(address, port);
                NetworkStream stream = client.GetStream();

                while (true)
                {
                    Console.Write("client: ");
                    string message = Console.ReadLine();
                    Message operation = null;
                    int num = 1;
                    while(num > 0 && num < 6)
                    {
                        Console.WriteLine("Operations:\n1) Translit\n2) Reverse Register\n3/4) Delete letters/digits\n5) Anon(add \"|hello\" to message end)\n6) End");
                        Console.Write("Op: ");
                        num = int.Parse(Console.ReadLine());
                        switch (num)
                        {
                            case 1:
                                operation = Transliteration.Front;
                                message = operation.Invoke(message);
                                break;
                            case 2:
                                operation = ReverseRegister;
                                message = operation.Invoke(message);
                                break;
                            case 3:
                                operation = DeleteLetters;
                                message = operation.Invoke(message);
                                break;
                            case 4:
                                operation = DeleteDigits;
                                message = operation.Invoke(message);
                                break;
                            case 5:
                                Message anon = delegate (string mes)
                                {
                                    return mes + "|hello";
                                };
                                message = anon.Invoke(message);
                                break;
                            default:
                                break;
                        }
                    }
                    message = String.Format("client: {0}", message);
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                    data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    message = builder.ToString();
                    Console.WriteLine("server: {0}", message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}