namespace LibreTranslateSharp.Tests;

public class FrontendTests
{
    [Fact]
    public async Task FrontendSettings()
    {
        var result = await Client.ApiClient.GetFrontendSettings();
        Assert.True(result.IsSuccessful);
        Assert.NotNull(result.Result);
    }
}
