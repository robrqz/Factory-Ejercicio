using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Report.InterfaceReportGenerator;
using Ejercicio_Factory.Ventas.SalesEntity;

namespace Ejercicio_Factory.Sales.InterfaceSalesService
{
    public interface ISalesService
    {
        public void CreateSales(SalesEntity sales);
        public List<SalesEntity> GetSalesList();
    }
}
