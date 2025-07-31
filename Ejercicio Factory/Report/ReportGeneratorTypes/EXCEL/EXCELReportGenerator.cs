using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Ventas.SalesEntity;
using Ejercicio_Factory.Report.InterfaceReportGenerator;
using Ejercicio_Factory.Report.InterfaceReportService;
using Ejercicio_Factory.Report.InterfaceReportFormatter;


namespace Ejercicio_Factory.Report.ReportGeneratorTypes.EXCEL
{
    public class EXCELReportGenerator : IReportGenerator
    {
        private readonly IReportFormatter formatter;

        public EXCELReportGenerator(IReportFormatter format)
        {
            this.formatter = format;
        }

        public void ReportGenerator(SalesEntity report)
        {
            formatter.FormatReport(FormatName, report);
        }

        public string FormatName => "EXCEL";
    }
}
