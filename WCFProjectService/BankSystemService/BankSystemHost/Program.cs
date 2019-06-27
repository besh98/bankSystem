using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace BankSystemService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(BankSystemService)))
            {
                host.Open();
                Console.WriteLine("Host started @" + DateTime.Now.ToShortDateString());
                Console.ReadLine();
            }
        }
    }
}
