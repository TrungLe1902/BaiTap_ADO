using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSP_ADO_Net.Validate
{
    public static class KiemTraValidate
    {
        public static int GetIntegerInput(string message)
        {
            int result;
            bool isValid = false;
            do
            {
                Console.Write(message);
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out result);
                if (!isValid)
                {
                    Console.WriteLine("Nhập không hợp lệ. Vui lòng nhập lại.");
                }
            } while (!isValid);

            return result;
        }

        public static string GetStringInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static bool GetYesNoInput(string message)
        {
            while (true)
            {
                Console.Write(message + " (y/n): ");
                string response = Console.ReadLine().ToLower();
                if (response == "y")
                    return true;
                else if (response == "n")
                    return false;
                else
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn 'y' hoặc 'n'.");
            }
        }

    }

}
