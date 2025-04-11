using System.Threading.Tasks;
using LibreTranslateSharp.Models;

namespace LibreTranslateSharp;

public partial class LibreTranslateClient
{
    public async Task<LibreTranslateResult<FrontendSettingsResult>> GetFrontendSettings()
    {
        return await client.Get<FrontendSettingsResult>("/frontend/settings");
    }

}
