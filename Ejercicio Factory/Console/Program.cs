using Ejercicio_Factory.Report.EntityReport;
using Ejercicio_Factory.Report.InterfaceReportGenerator;
using Ejercicio_Factory.Report.InterfaceReportService;
using Ejercicio_Factory.Report.ReportFactory;
using Ejercicio_Factory.Report.ReportGeneratorTypes.CSV;
using Ejercicio_Factory.Report.ReportGeneratorTypes.EXCEL;
using Ejercicio_Factory.Report.ReportGeneratorTypes.PDF;
using Ejercicio_Factory.Report.ReportService;
using Ejercicio_Factory.Sales.InterfaceSalesService;
using Ejercicio_Factory.Sales.SalesService;
using Ejercicio_Factory.UniversalHelper;
using Ejercicio_Factory.Ventas.SalesEntity;
using Microsoft.Extensions.DependencyInjection;
using Ejercicio_Factory.Report.EnumReport;
using Ejercicio_Factory.Report.InterfaceReportFormatter;
using Ejercicio_Factory.Report.ReportStrategy;
using Ejercicio_Factory.Report.InterfaceReportFormatter;


public class Program
{
    static void Main()
    {
        var serverProvider = new ServiceCollection();

        serverProvider.AddSingleton<IReportService, ReportService>();
        serverProvider.AddScoped<ISalesService, SalesService>();
        serverProvider.AddSingleton<ReportFactory>();
        serverProvider.AddSingleton<IReportFormatter, StrategyReport>();

        var Provider = serverProvider.BuildServiceProvider();

        var SalesService = Provider.GetRequiredService<ISalesService>();
        var ReportService = Provider.GetRequiredService<IReportService>();
        var reportFactory = Provider.GetRequiredService<ReportFactory>();

        int MenuOption;
        do
        {
            var MenuSwitch = UniversalHelpers.MenuHelper(out MenuOption);

            if (!MenuSwitch.esValido)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(MenuSwitch.mensajeError);
                Console.ResetColor();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
                continue;
            }

            switch (MenuOption)
            {
                case 1:

                    int Amount;
                    bool validAmount = false;
                    //Amount
                    do
                    {
                        Console.WriteLine("-------------------------------------------------------");
                        Console.WriteLine("--Ingresar la cantidad de ventas que recibio este mes--");

                        string UserInputAmount = Console.ReadLine();

                        if (int.TryParse(UserInputAmount, out Amount))
                        {
                            validAmount = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Error: Inválido.");
                            Console.ResetColor();
                            Console.WriteLine("Por favor, ingrese solo números válidos");
                        }

                    } while (!validAmount);

                    string Category;
                    (bool isValidUsername, string ShowErrorMesaje) UserResult;
                    //Category
                    do
                    {
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("--Ingrese la categoria de las ventas--");
                        Console.WriteLine("EJ: Indumentaria, electronicos (etc)");
                        Category = Console.ReadLine();

                        UserResult = UniversalHelpers.ValidateTextWithoutNumbers(Category);


                    } while (!UserResult.isValidUsername);

                    decimal Balance;
                    bool validBalance = false;
                    //Balance
                    do
                    {
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("--Ingrese lo que recaudo de este mes de ventas--");
                        string UserInputBalance = Console.ReadLine();

                        if (decimal.TryParse(UserInputBalance, out Balance))
                        {
                            validBalance = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Error: Monto inválido.");
                            Console.ResetColor();
                            Console.WriteLine("Por favor, ingrese solo números válidos");
                        }

                    } while (!validBalance);

                    SalesEntity sale = new SalesEntity(
                        Category, Amount, Balance
                        );

                    SalesService.CreateSales(sale);
 
                    break;
                case 2:

                    IReportGenerator generator = null;

                    var allSales = SalesService.GetSalesList();
                    if (!allSales.Any())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No hay ventas mensuales registrados.");
                        Console.ResetColor();
                        break;
                    }

                    //format
                    IReportFormatter formatter = new StrategyReport();
                    ReportEnum selectedFormat;
                    string Format;
                    bool ValidFormat = false;

                    do
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Seleccione el formato de reporte:");
                        Console.WriteLine("1. PDF");
                        Console.WriteLine("2. CSV");
                        Console.WriteLine("3. EXCEL");

                        Format = Console.ReadLine();

                        switch (Format)
                        {
                            case "1":
                                selectedFormat = ReportEnum.PDF;
                                generator = new PDFReportGenerator(formatter);
                                ValidFormat = true;
                                break;
                            case "2":
                                selectedFormat = ReportEnum.CSV;
                                generator = new CSVReportGenerator(formatter);
                                ValidFormat = true;
                                break;
                            case "3":
                                selectedFormat = ReportEnum.EXCEL;
                                generator = new EXCELReportGenerator(formatter);
                                ValidFormat = true;
                                break;



                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Formato no válido. Seleccione 1, 2 o 3.");
                                Console.ResetColor();
                                Console.WriteLine("Presione una tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }

                    } while (!ValidFormat);



                    var lastSale = allSales.Last();

                    var reporteGenerado = ReportService.ReportCreator(lastSale, generator);

                    break;
                case 3:

                    var Reports = ReportService.GetReportList();
                    if (!Reports.Any())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No hay reportes creados.");
                        Console.ResetColor();
                        break;
                    }

                    foreach (var reportItems in Reports)
                    {
                        ReportService.ShowReportList(reportItems);
                    }

                    Console.WriteLine("Ingrese cualquier tecla para volver al menu");
                    Console.ReadKey();
                    Console.Clear();

                    break;
                  
            }
        } while (MenuOption != 4);
    }
}