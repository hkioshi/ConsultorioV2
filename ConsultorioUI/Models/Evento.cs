using System;
using System.Text.Json.Serialization;

namespace ConsultorioUI.Models;

public class Evento
{

    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("titulo")]
    public string Nome { get; set; } = string.Empty;  // JsonPropertyName diferente da prop

    [JsonPropertyName("cor")]
    public string? Cor { get; set; }

    [JsonPropertyName("inicio")]
    public DateTimeOffset HoraInicio { get; }

    [JsonPropertyName("fim")]
    public DateTimeOffset HoraFim { get; }

    // Calculadas, não vêm do JSON
    [JsonIgnore]
    public DateTime Data => HoraInicio.LocalDateTime.Date;
    [JsonIgnore]
    public DateTime Inicio  => HoraInicio.LocalDateTime;
    [JsonIgnore]
    public DateTime? Fim => HoraFim.LocalDateTime;
}