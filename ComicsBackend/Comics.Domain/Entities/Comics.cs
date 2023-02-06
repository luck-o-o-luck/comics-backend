using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ComicsBackend.Comics.Domain.Entities;

public class ComicBook
{
    [Key]
    [JsonPropertyName("num")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("transcript")]
    public string Transcript { get; set; }
    
    [JsonPropertyName("img")]
    public string ImgPath { get; set; }
    
    [JsonPropertyName("month")]
    public string Month { get; set; }
    
    [JsonPropertyName("link")]
    public string Link { get; set; }
    
    [JsonPropertyName("year")]
    public string Year { get; set; }
    
    [JsonPropertyName("news")]
    public string News { get; set; }
    
    [JsonPropertyName("alt")]
    public string Alt { get; set; }
    
    [JsonPropertyName("day")]
    public string Day { get; set; }
    
    [JsonPropertyName("safe_title")]
    public string SafeTitle { get; set; }
}