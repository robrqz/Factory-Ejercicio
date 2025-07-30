using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Report.InterfaceReportGenerator;
using Ejercicio_Factory.Report.ReportGeneratorTypes.CSV;
using Ejercicio_Factory.Report.ReportGeneratorTypes.EXCEL;
using Ejercicio_Factory.Report.ReportGeneratorTypes.PDF;

namespace Ejercicio_Factory.Report.ReportFactory
{
    public class ReportFactory
    {
        public static IReportGenerator CreateReportGenerator(string format)
        {
            return format switch
            {
                "pdf" => new PDFReportGenerator(),
                "csv" => new CSVReportGenerator(),
                "excel" => new EXCELReportGenerator(),
                _ => throw new NotSupportedException($"Formato '{format}' no soportado.")
            };
        }


    }
}
