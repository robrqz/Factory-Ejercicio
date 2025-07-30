using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Ventas.SalesEntity;
using Ejercicio_Factory.Report.InterfaceReportGenerator;

namespace Ejercicio_Factory.Report.ReportGeneratorTypes.PDF
{
    public class PDFReportGenerator: IReportGenerator
    {
        public void ReportGenerator(SalesEntity report)
        {
            Console.WriteLine("--REPORTE GENERADO - PDF--");
            Console.WriteLine($"Cantidad de ventas: {report.amount}");
            Console.WriteLine($"Balance total: ${report.balance}");
        }
        public string FormatName => "PDF";
    }
}
