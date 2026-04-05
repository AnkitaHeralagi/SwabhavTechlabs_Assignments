using System.Text;
using AccountApp_Serialization_Deserialization;

namespace AccountApp_Serialization_Deserialization
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; 

            BankUI app = new BankUI();
            app.Start();
        }
    }
}