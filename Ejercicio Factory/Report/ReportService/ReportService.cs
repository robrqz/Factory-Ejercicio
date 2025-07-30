using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_Factory.Report.InterfaceReportGenerator;
using Ejercicio_Factory.Report.EntityReport;
using Ejercicio_Factory.Ventas.SalesEntity;
using Ejercicio_Factory.Report.InterfaceReportService;

namespace Ejercicio_Factory.Report.ReportService
{
    public class ReportService : IReportService
    {
        private readonly List<ReportEntity> _reportList = new List<ReportEntity>();
        public ReportEntity ReportCreator(SalesEntity sales, IReportGenerator Format)
        {
            int newId = _reportList.Any()
                ? _reportList.Max(n => n.id) + 1
                : 1;

            var report = new ReportEntity(
                
                sales.category,
                sales.amount,
                sales.balance,
                Format.FormatName
                );

            report.SetId(newId);

            _reportList.Add(report);
            

            return report;
        }
        public List<ReportEntity> GetReportList() => _reportList;

        public void ShowReportList(ReportEntity report) 
        {

            if (report == null )
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"No hay reportes registrados");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("=== Resumen del reporte registrado ===");
            Console.WriteLine($"Categoria: {report.category}");
            Console.WriteLine($"Cantidad ventas: {report.amount}");
            Console.WriteLine($"Balance: ${report.balance}");
            Console.WriteLine($"Formato: {report.format}");
            Console.WriteLine("----------------------------------------");
        }

    
    }
}
