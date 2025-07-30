using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Report.EntityReport;
using Ejercicio_Factory.Ventas.SalesEntity;

namespace Ejercicio_Factory.Report.InterfaceReportGenerator
{
    public interface IReportGenerator
    {
        void ReportGenerator(SalesEntity report);
        public string FormatName {  get; }
    }
}
