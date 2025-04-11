using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LibreTranslateSharp.Models;

namespace LibreTranslateSharp;

public partial class LibreTranslateClient
{

    public async Task<LibreTranslateResult<IList<DetectResult>>> DetectLanguage(string text)
    {
        return await client.Post<DetectParameter, IList<DetectResult>>("/detect", new DetectParameter(text, options.ApiKey));
    }

    public async Task<LibreTranslateResult<IList<LanguageResult>>> GetLanguages()
    {
        return await client.Get<IList<LanguageResult>>("/languages");
    }

    public async Task<LibreTranslateResult<TranslateResult>> Translate(string text, string source, string target, TranslationFormat? format, int alternatives)
    {
        return await client.Post<TranslateParameter, TranslateResult>("/translate", new TranslateParameter(text, source, target, format, alternatives, options.ApiKey));
    }

    public async Task<LibreTranslateResult<TranslateFileResult>> TranslateFile(string fileName, byte[] file, string source, string target)
    {
        using var form = new MultipartFormDataContent();

        var fileContent = new ByteArrayContent(file);
        form.Add(fileContent, nameof(file), fileName);
        form.Add(new StringContent(source), nameof(source));
        form.Add(new StringContent(target), nameof(target));
        if (options.ApiKey is not null)
        {
            form.Add(new StringContent(options.ApiKey), "api_key");
        }

        return await client.PostUpload<TranslateFileResult>("/translate_file", form);
    }

}

