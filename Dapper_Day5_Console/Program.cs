using System;
using System.Text;
using Dapper_Day5_Console.Utilities;
using Dapper_Day5_Console.Data;
using Dapper_Day5_Console.BusinessLogic;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Dapper_Day5_Console.Data.InterFace;

namespace Dapper_Day5_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //format encoding 
            Console.OutputEncoding = Encoding.UTF8;
            //Process     
            //sử dụng thư viện Castle Windsor
            try
            {
                WindsorContainer container = new WindsorContainer();
                container.Register(Component.For<ISinhVienDAL>().ImplementedBy<DataAccessList>(),
                    Component.For<SVBusinessLogic>());
                Execute.RunMain(container);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
