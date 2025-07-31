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
        private readonly IServiceProvider _provider;

        public ReportFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public StrategyReport CreateReport(ReportEnum type)
        {
            IReportFormatter formatter = type switch
            {
                ReportEnum.PDF => _provider.GetRequiredService<PDFReportGenerator>(),
                ReportEnum.CSV => _provider.GetRequiredService<CSVReportGenerator>(),
                ReportEnum.Excel => _provider.GetRequiredService<EXCELReportGenerator>(),
                _ => throw new ArgumentException($"Tipo de reporte desconocido: {type}")
            };

            return new StrategyReport(formatter);
        }
    }


}
