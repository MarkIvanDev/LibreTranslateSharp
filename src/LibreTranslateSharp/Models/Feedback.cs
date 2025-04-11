using System.Text.Json.Serialization;

namespace LibreTranslateSharp.Models;

public record class SuggestParameter(
    [property: JsonPropertyName("q")]
    string Text,
    [property: JsonPropertyName("s")]
    string Suggestion,
    string Source,
    string Target);

public record class SuggestResult(bool Success);