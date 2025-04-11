namespace LibreTranslateSharp.Tests;

public class FeedbackTests
{

    [Fact]
    public async Task Suggest()
    {
        var result = await Client.ApiClient.Suggest("Hello world", "Hola mundo", "en", "es");
        Assert.True(result.IsSuccessful);
        Assert.True(result.Result.Success);
    }
}
