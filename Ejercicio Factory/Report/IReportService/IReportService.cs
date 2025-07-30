using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Report.EntityReport;
using Ejercicio_Factory.Report.InterfaceReportGenerator;
using Ejercicio_Factory.Ventas.SalesEntity;

namespace Ejercicio_Factory.Report.InterfaceReportService
{
    public interface IReportService
    {
        ReportEntity ReportCreator(SalesEntity sales, IReportGenerator Format);
        void ShowReportList(ReportEntity report);
        List<ReportEntity> GetReportList();
    }
}
