using System;

namespace LibreTranslateSharp.Models;

public class LibreTranslateResult<TResult>
    where TResult : class
{
    private readonly TResult? result;
    private readonly string? error;

    private LibreTranslateResult(bool isSuccessful, TResult? result, string? error)
    {
        IsSuccessful = isSuccessful;
        this.result = result;
        this.error = error;
    }

    public static LibreTranslateResult<TResult> Success(TResult result)
    {
        return new LibreTranslateResult<TResult>(true, result, null);
    }

    public static LibreTranslateResult<TResult> Failed(string error)
    {
        return new LibreTranslateResult<TResult>(false, null, error);
    }

    public bool IsSuccessful { get; }

    public TResult Result
    {
        get => result ?? throw new InvalidOperationException();
    }

    public string Error
    {
        get => error ?? throw new InvalidOperationException();
    }
}

public record class ErrorResult(string Error);