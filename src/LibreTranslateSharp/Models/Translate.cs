using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibreTranslateSharp.Models;

public record class DetectParameter(
    [property: JsonPropertyName("q")]
    string Text,
    [property: JsonPropertyName("api_key")]
    string? ApiKey);

public record class DetectResult(double Confidence, string Language);

public record class LanguageResult(string Code, string Name, IList<string> Targets);

public record class TranslateParameter(
    [property: JsonPropertyName("q")]
    string Text,
    string Source,
    string Target,
    TranslationFormat? Format,
    int Alternatives,
    [property: JsonPropertyName("api_key")]
    string? ApiKey);

public enum TranslationFormat
{
    Text,
    Html,
}

public record class TranslateResult(
    string TranslatedText,
    IList<string>? Alternatives);

public record class TranslateFileResult(string TranslatedFileUrl);