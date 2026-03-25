using Newtonsoft.Json;

namespace MvcCoreApiCliente.Models
{
    public class Hospital
    {
        [JsonProperty("idHospital")]
        public int IdHospital { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("direccion")]
        public string Direccion { get; set; }
        [JsonProperty("telefono")]
        public string Telefono { get; set; }
        [JsonProperty("numCama")]
        public int Camas { get; set; }
    }
}
