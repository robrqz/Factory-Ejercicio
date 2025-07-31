using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Report.InterfaceReportGenerator;
using Ejercicio_Factory.Report.ReportGeneratorTypes.CSV;
using Ejercicio_Factory.Report.ReportGeneratorTypes.EXCEL;
using Ejercicio_Factory.Report.ReportGeneratorTypes.PDF;
using Ejercicio_Factory.Report.EnumReport;
using Ejercicio_Factory.Report.InterfaceReportFormatter;
using Ejercicio_Factory.Report.ReportStrategy;

namespace Ejercicio_Factory.Report.ReportFactory
{
    public class ReportFactory
    {
        private readonly IReportFormatter formatter;

        public ReportFactory(IReportFormatter formatter)
        {
            this.formatter = formatter;
        }

        public IReportGenerator CreateReportGenerator(ReportEnum format)
        {
            return format switch
            {
                ReportEnum.PDF=> new PDFReportGenerator(formatter),
                ReportEnum.CSV=> new CSVReportGenerator(formatter),
                ReportEnum.EXCEL => new EXCELReportGenerator(formatter),
                _ => throw new NotSupportedException($"Formato '{format}' no soportado.")
            };
        }
    }
}
