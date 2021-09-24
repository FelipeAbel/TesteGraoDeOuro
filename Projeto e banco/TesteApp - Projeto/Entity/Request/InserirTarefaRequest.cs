using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Entity.Request
{
    public class InserirTarefaRequest
    {
        [Required]
        [JsonProperty("nome_tarefa")]
        [JsonPropertyName("nome_tarefa")]
        public string Nome { get; set; }
    }
}