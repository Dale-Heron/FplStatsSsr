using System.Text.Json.Serialization;

public class Player
{
    [JsonPropertyName("first_name")]
    public required string FirstName { get; set; }

    [JsonPropertyName("second_name")]
    public required string SecondName { get; set; }

    [JsonPropertyName("total_points")]
    public required int TotalPoints { get; set; }

    [JsonPropertyName("now_cost")]
    public required int Price { get; set; }

    [JsonPropertyName("element_type")]
    public required int Position { get; set; }

    [JsonPropertyName("minutes")]
    public required int Minutes { get; set; }

    [JsonPropertyName("selected_by_percent")]
    public required string SelectedByPercent { get; set; }

    public float PriceF => Price/10.0f;

    public float SelectedByPercentF => float.Parse(SelectedByPercent);
}