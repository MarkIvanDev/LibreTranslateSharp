namespace LibreTranslateSharp.Tests;

public static class Client
{
    public static readonly LibreTranslateClient ApiClient;

    static Client()
    {
        ApiClient = new LibreTranslateClient(new LibreTranslateOptions
        {
            Url = new Uri("http://localhost:5000")
        });
    }
}
