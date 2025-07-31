using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Report.EntityReport;
using Ejercicio_Factory.Ventas.SalesEntity;


namespace Ejercicio_Factory.Report.InterfaceReportFormatter
{
    public interface IReportFormatter
    {
        void FormatReport(string formatName, SalesEntity report);
    }
}

