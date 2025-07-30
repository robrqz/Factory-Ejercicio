using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Report.InterfaceReportGenerator;
using Ejercicio_Factory.Ventas.SalesEntity;
using Ejercicio_Factory.Sales.InterfaceSalesService;

namespace Ejercicio_Factory.Sales.SalesService
{
    public class SalesService : ISalesService
    {
        private readonly List<SalesEntity> _SalesList = new();
        public void CreateSales(SalesEntity sales)
        {
            int newId = _SalesList.Any()
                ? _SalesList.Max(n => n.id) + 1
                : 1;

            var SalesInfo = new SalesEntity( 
                sales.category,
                sales.amount,
                sales.balance
            );

            SalesInfo.SetId(newId);

            _SalesList.Add(SalesInfo);

            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine($"");
            Console.WriteLine($"");
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }
        public List<SalesEntity> GetSalesList()
        {
            return _SalesList;
        }

        public SalesEntity GetLastSale()
        {
            return _SalesList.Any() ? _SalesList.Last() : null;
        }


    }
}
