using MvcCoreApiCliente.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MvcCoreApiCliente.Services
{
    public class ServiceHospitales
    {
        private string ApiUrl;
        // Necesitamos indicar el tipo de datos que vamos a leer
        private MediaTypeWithQualityHeaderValue header;

        public ServiceHospitales()
        {
            this.ApiUrl = "https://apicorehospitalesjst.azurewebsites.net/";
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Hospital>> GetHospitalsAsync()
        {
            // Se utiliza la clase HttpClient para las peticiones
            using(HttpClient client = new HttpClient())
            { 
                string request = "api/hospitales";
                // Indicamos el host
                client.BaseAddress = new Uri(this.ApiUrl);
                // Indicamos los datos que vamos a consumir
                // Limpiamos las cabeceras por norma
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                // Realizamos la petición y capturamos una respuesta
                HttpResponseMessage response = await client.GetAsync(request);
                // En la respuesta tenemos la clave si deseamos
                // personalizar errores
                if(response.IsSuccessStatusCode == true)
                {
                    // Recuperamos el contenido en json
                    string json = await response.Content.ReadAsStringAsync();
                    // Mediante newton deserializamos json a list
                    List<Hospital> hospitales = JsonConvert.DeserializeObject<List<Hospital>>(json);
                    return hospitales;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
