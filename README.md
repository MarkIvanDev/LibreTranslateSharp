# LibreTranslateSharp
A [LibreTranslate API](https://libretranslate.com/) client for C#.

## Getting started

**NOTE: If you're not self-hosting, you will need an API Key which can be obtained [here](https://portal.libretranslate.com/).**


## Usage

```csharp
var client = new LibreTranslateClient(new LibreTranslateOptions
{
	Url = // optional. defaults to https://libretranslate.com/
	ApiKey = // optional. API Key you got from the portal
});

// Translate endpoints
var detectedLanguage = await client.DetectLanguage("Hello");
var languages = await client.GetLanguages();
var translation = await client.Translate("Hello", "en", "es", null, 0);
var translationFile = await client.TranslateFile("file.txt", data, "en", "es");

// Frontend endpoints
var frontendSettings = await client.GetFrontendSettings();

// Feedback endpoints
var suggestionResult = await client.Suggest("Hello world", "Hola mundo", "en", "es");
```


## Support
If you like my work and want to support me, buying me a coffee would be awesome! Thanks for your support!

<a href="https://www.buymeacoffee.com/markivandev" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/v2/default-blue.png" alt="Buy Me A Coffee" style="height: 60px !important;width: 217px !important;" ></a>

---------
**Mark Ivan Basto** &bullet; **GitHub**
**[@MarkIvanDev](https://github.com/MarkIvanDev)**