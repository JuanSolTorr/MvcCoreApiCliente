using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreApiCliente.Models
{
    public class Empleado
    {
        [JsonProperty("IdEmpleado")]
        public int IdEmpleado { get; set; }
        [JsonProperty("Apellido")]
        public string Apellido { get; set; }
        [JsonProperty("Oficio")]
        public string Oficio { get; set; }
        [JsonProperty("Salario")]
        public int Salario { get; set; }
        [JsonProperty("IdDepartamento")]
        public int IdDepartamento { get; set; }
    }
}
