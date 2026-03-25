using Microsoft.AspNetCore.Mvc;
using MvcCoreApiCliente.Services;

namespace MvcCoreApiCliente.Controllers
{
    public class HospitalesController : Controller
    {
        private ServiceHospitales service;

        public HospitalesController(ServiceHospitales service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Servidor()
        {
            var hospitales = await this.service.GetHospitalsAsync();
            return View(hospitales);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cliente()
        {
                return View();
        }
    }
}
