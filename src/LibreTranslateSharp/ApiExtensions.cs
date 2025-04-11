using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LibreTranslateSharp.Models;

namespace LibreTranslateSharp;

public static class ApiExtensions
{
    private static readonly JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
        }
    };

    public static async Task<LibreTranslateResult<TResult>> Get<TResult>(this HttpClient client, string requestUri)
        where TResult : class
    {
        try
        {
            var response = await client.GetAsync(requestUri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TResult>(options).ConfigureAwait(false);
                if (result is not null)
                {
                    return LibreTranslateResult<TResult>.Success(result);
                }
            }
            else
            {
                var result = await response.Content.ReadFromJsonAsync<ErrorResult>(options).ConfigureAwait(false);
                if (result is not null)
                {
                    return LibreTranslateResult<TResult>.Failed(result.Error);
                }
            }

            return LibreTranslateResult<TResult>.Failed("Unknown error");
        }
        catch (Exception ex)
        {
            return LibreTranslateResult<TResult>.Failed(ex.Message);
        }
    }

    public static async Task<LibreTranslateResult<TResult>> Post<TParameter, TResult>(this HttpClient client, string requestUri, TParameter parameter)
        where TParameter : class
        where TResult : class
    {
        try
        {
            var response = await client.PostAsJsonAsync(requestUri, parameter, options).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TResult>(options).ConfigureAwait(false);
                if (result is not null)
                {
                    return LibreTranslateResult<TResult>.Success(result);
                }
            }
            else
            {
                var result = await response.Content.ReadFromJsonAsync<ErrorResult>(options).ConfigureAwait(false);
                if (result is not null)
                {
                    return LibreTranslateResult<TResult>.Failed(result.Error);
                }
            }

            return LibreTranslateResult<TResult>.Failed("Unknown error");
        }
        catch (Exception ex)
        {
            return LibreTranslateResult<TResult>.Failed(ex.Message);
        }
    }

    public static async Task<LibreTranslateResult<TResult>> PostUpload<TResult>(this HttpClient client, string requestUri, MultipartFormDataContent content)
        where TResult : class
    {
        try
        {
            var response = await client.PostAsync(requestUri, content).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TResult>(options).ConfigureAwait(false);
                if (result is not null)
                {
                    return LibreTranslateResult<TResult>.Success(result);
                }
            }
            else
            {
                var result = await response.Content.ReadFromJsonAsync<ErrorResult>(options).ConfigureAwait(false);
                if (result is not null)
                {
                    return LibreTranslateResult<TResult>.Failed(result.Error);
                }
            }

            return LibreTranslateResult<TResult>.Failed("Unknown error");
        }
        catch (Exception ex)
        {
            return LibreTranslateResult<TResult>.Failed(ex.Message);
        }
    }
}
