using StoreBl.Bl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProjectEx
{
    public class Program
    {
        static void Main(string[] args)
        {
            string sOption = string.Empty;
            while (sOption !="0") 
            {
                UiHelper.MainOptions();
                sOption = Console.ReadLine();

                Console.Clear();
                switch (sOption) 
                {
                    case "0":
                        sOption = "0";
                        break;
                    case "1":
                        UiHelper.StoreOptions();
                        break;
                    case "2":
                        UiHelper.ItemOptions();
                        break;
                    case "3":
                        UiHelper.OrderOptions();
                        break;
                    case "4":
                        break; 
                }
            }
        }
    }
}
