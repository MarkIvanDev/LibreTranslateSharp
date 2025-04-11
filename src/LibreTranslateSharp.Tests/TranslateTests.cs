using LibreTranslateSharp.Models;

namespace LibreTranslateSharp.Tests;

public class TranslateTests
{
    [Fact]
    public async Task DetectSuccessful()
    {
        var result = await Client.ApiClient.DetectLanguage("Hello");
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public async Task Languages()
    {
        var result = await Client.ApiClient.GetLanguages();
        Assert.True(result.IsSuccessful);
        Assert.NotEmpty(result.Result);
    }

    [Fact]
    public async Task TranslateNoAlternatives()
    {
        var result = await Client.ApiClient.Translate("Hello", "en", "es", null, 0);
        Assert.True(result.IsSuccessful);
        Assert.Null(result.Result.Alternatives);
    }

    [Fact]
    public async Task TranslateOneAlternative()
    {
        var result = await Client.ApiClient.Translate("Hello", "en", "es", null, 1);
        Assert.True(result.IsSuccessful);
        Assert.NotNull(result.Result.Alternatives);
        Assert.Empty(result.Result.Alternatives);
    }

    [Fact]
    public async Task TranslateManyAlternatives()
    {
        var result = await Client.ApiClient.Translate("Hello", "en", "es", null, 2);
        Assert.True(result.IsSuccessful);
        Assert.NotNull(result.Result.Alternatives);
        Assert.NotEmpty(result.Result.Alternatives);
    }

    [Fact]
    public async Task TranslateHtml()
    {
        var result = await Client.ApiClient.Translate("<p>Hello</p>", "en", "es", TranslationFormat.Html, 2);
        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public async Task TranslateTxtFile()
    {
        var data = "Hello world!"u8.ToArray();
        var result = await Client.ApiClient.TranslateFile("file.txt", data, "en", "es");
        Assert.True(result.IsSuccessful);
        Assert.NotEmpty(result.Result.TranslatedFileUrl);
    }

}
