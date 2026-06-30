using System;
using System.Text.Json.Serialization;

namespace ConsultorioUI.Models;

public class EventoDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("titulo")]
    public string Titulo { get; set; } = string.Empty;

    [JsonPropertyName("inicio")]
    public DateTimeOffset Inicio { get; set; }

    [JsonPropertyName("fim")]
    public DateTimeOffset Fim { get; set; }

    [JsonPropertyName("cor")]
    public string? Cor { get; set; }
}