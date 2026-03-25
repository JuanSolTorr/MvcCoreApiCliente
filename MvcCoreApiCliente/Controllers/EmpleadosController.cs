using Microsoft.AspNetCore.Mvc;
using MvcCoreApiCliente.Models;
using MvcCoreApiCliente.Services;

namespace MvcCoreApiCliente.Controllers
{
    public class EmpleadosController : Controller
    {

        private ServiceEmpleados service;

        public EmpleadosController(ServiceEmpleados service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EmpleadosServidor()
        {
            var hospitales = await this.service.GetEmpleadosAsync();
            return View(hospitales);
        }
        public async Task<IActionResult> DetailsServidor(int id)
        {
            Empleado empleado = await this.service.FindEmpleadoAsync(id);
            return View(empleado);
        }
    }
}
