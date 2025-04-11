using System.Threading.Tasks;
using LibreTranslateSharp.Models;

namespace LibreTranslateSharp;

public partial class LibreTranslateClient
{
    public async Task<LibreTranslateResult<SuggestResult>> Suggest(string text, string suggestion, string source, string target)
    {
        return await client.Post<SuggestParameter, SuggestResult>("/suggest", new SuggestParameter(text, suggestion, source, target));
    }
}
