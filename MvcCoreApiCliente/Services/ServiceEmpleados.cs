using MvcCoreApiCliente.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MvcCoreApiCliente.Services
{
    public class ServiceEmpleados
    {
        private string ApiUrl;
        // Necesitamos indicar el tipo de datos que vamos a leer
        private MediaTypeWithQualityHeaderValue header;

        public ServiceEmpleados(IConfiguration configuration)
        {
            this.ApiUrl = configuration.GetValue<string>("ApiUrls:ApiHospitales");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = $"api/empleados";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    List<Empleado> empleados = await response.Content.ReadAsAsync<List<Empleado>>();
                    return empleados;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Empleado> FindEmpleadoAsync(int idHospital)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = $"api/empleados/{idHospital}";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    Empleado empleado = await response.Content.ReadAsAsync<Empleado>();
                    return empleado;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
