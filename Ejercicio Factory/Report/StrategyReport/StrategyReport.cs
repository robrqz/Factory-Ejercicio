using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Report.EntityReport;
using Ejercicio_Factory.Ventas.SalesEntity;
using Ejercicio_Factory.Report.InterfaceReportFormatter;

namespace Ejercicio_Factory.Report.ReportStrategy
{
    public class StrategyReport : IReportFormatter
    {
        public void FormatReport(string formatName, SalesEntity report)
        {
            Console.WriteLine($"--REPORTE GENERADO - {formatName.ToUpper()}--");
            Console.WriteLine($"Cantidad de ventas: {report.amount}");
            Console.WriteLine($"Balance total: ${report.balance}");
        }
    }
}


    


