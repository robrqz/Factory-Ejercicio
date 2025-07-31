using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Ventas.SalesEntity;
using Ejercicio_Factory.Report.InterfaceReportGenerator;
using Ejercicio_Factory.Report.InterfaceReportService;
using Ejercicio_Factory.Report.InterfaceReportFormatter;

namespace Ejercicio_Factory.Report.ReportGeneratorTypes.CSV
{
    public class CSVReportGenerator : IReportGenerator
    {
        private readonly IReportFormatter formatter;

        public CSVReportGenerator(IReportFormatter formatter)
        {
            this.formatter = formatter;
        }

        public void ReportGenerator(SalesEntity report)
        {
            formatter.FormatReport(FormatName, report);
        }

        public string FormatName => "CSV";
    }
}
