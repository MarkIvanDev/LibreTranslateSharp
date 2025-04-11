using System;
using System.Net.Http;

namespace LibreTranslateSharp;

public partial class LibreTranslateClient : IDisposable
{
    private readonly LibreTranslateOptions options;
    private readonly HttpClient client;

    public LibreTranslateClient(LibreTranslateOptions options, HttpClient client)
    {
        this.options = options;
        this.client = client;
        this.client.BaseAddress = options.Url ?? new Uri("https://libretranslate.com");
    }

    public LibreTranslateClient(LibreTranslateOptions options) : this(options, new HttpClient())
    {
    }

    public void Dispose()
    {
        ((IDisposable)client).Dispose();
    }
}
