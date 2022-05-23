using System;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ef = new EfDepositDal();
            var a= await ef.GetDepositsByUserId(1013);
            Console.WriteLine(a);
        }
    }
}