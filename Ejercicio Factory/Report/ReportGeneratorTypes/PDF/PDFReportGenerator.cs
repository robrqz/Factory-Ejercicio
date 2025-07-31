using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Ventas.SalesEntity;
using Ejercicio_Factory.Report.InterfaceReportGenerator;
using Ejercicio_Factory.Report.InterfaceReportFormatter;
using Ejercicio_Factory.Report.InterfaceReportFormatter;
using System.Runtime.Serialization;

namespace Ejercicio_Factory.Report.ReportGeneratorTypes.PDF
{
    public class PDFReportGenerator : IReportGenerator
    {
        private readonly IReportFormatter formatter;

        public PDFReportGenerator(IReportFormatter format)
        {
            this.formatter = format;
        }

        public void ReportGenerator(SalesEntity report)
        {
            formatter.FormatReport(FormatName, report);
        }

        public string FormatName => "PDF";
    }
}



