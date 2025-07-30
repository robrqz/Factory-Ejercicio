using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Ventas.SalesEntity;
using Ejercicio_Factory.Report.InterfaceReportGenerator;
using Ejercicio_Factory.Report.InterfaceReportService;

namespace Ejercicio_Factory.Report.ReportGeneratorTypes.CSV
{
    public class CSVReportGenerator : IReportGenerator
    {
        public void ReportGenerator(SalesEntity report)
        {
            Console.WriteLine("--REPORTE GENERADO - CSV--");
            Console.WriteLine($"Cantidad de ventas: {report.amount}");
            Console.WriteLine($"Balance total: ${report.balance}");
        }
        public string FormatName => "CSV";
    }
}
