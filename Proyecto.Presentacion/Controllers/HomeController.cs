using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Proyecto.Presentacion.Models;
using System.Data;
using System.Diagnostics;

namespace Proyecto.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string? _cadena;

        // Constructor único con todas las dependencias necesarias
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _cadena = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetConnectionString("cn");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult exportarExcel()
        {
            DataTable tabla_ingresos = new DataTable();

            using (var cn = new SqlConnection(_cadena))
            {
                cn.Open();
                using (var adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand("SP_LISTAR_INGRESO", cn);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(tabla_ingresos);
                }
            }

            using (var libro = new XLWorkbook())
            {
                tabla_ingresos.TableName = "Ingresos";
                var hoja = libro.Worksheets.Add(tabla_ingresos);
                hoja.ColumnsUsed().AdjustToContents();

                using (var memoria = new MemoryStream())
                {
                    libro.SaveAs(memoria);
                    memoria.Position = 0;

                    var nombreExcel = string.Concat("Reporte_Ingresos", ".xlsx");
                        return File(memoria.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreExcel);
                }
            }
        }
    }
}
