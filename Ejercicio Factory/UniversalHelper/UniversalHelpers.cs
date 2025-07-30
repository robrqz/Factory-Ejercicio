using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Factory.UniversalHelper
{
    public class UniversalHelpers
    {
        public static (bool esValido, string mensajeError) MenuHelper(out int nombreCampo)
        {
            Console.WriteLine("=== Sistema de Reportes===");
            Console.WriteLine(" 1.Ingresar Ventas");
            Console.WriteLine(" 2.Crear Reporte");
            Console.WriteLine(" 3.Mostrar Reporte");
            Console.WriteLine(" 4.Salir");

            string MenuEntrada = Console.ReadLine();

            if (!int.TryParse(MenuEntrada, out nombreCampo) || nombreCampo < 1 || nombreCampo > 3)
            {
                return (false, "Debes ingresar un número entre 1 y 4.");
            }

            return (true, string.Empty);
        }
        public static (bool isValid, string MessageError) ValidateTextWithoutNumbers(string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(nombreCampo))
                return (false, $"No puede estar vacío.");

            if (nombreCampo.Any(char.IsDigit))
                return (false, $"No debe contener números.");

            return (true, string.Empty);
        }
    }
}
