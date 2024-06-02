namespace StreamPilot.API.Common
{
   public static class ResultExtensions
{
    public static Result OnSuccess(this Result result, Action action)
    {
        if (result.IsSuccess)
        {
            action();
        }

        return result;
    }

    public static Result<T> OnSuccess<T>(this Result result, Func<T> func)
    {
        return result.IsSuccess ? Result.Ok(func()) : Result.Fail<T>(result.Error);
    }

    public static Result OnSuccess(this Result result, Func<Result> func)
    {
        return result.IsSuccess ? func() : result;
    }

    public static Result OnSuccess<T>(this Result<T> result, Action<T> action)
    {
        if (result.IsSuccess)
        {
            action(result.Value);
        }

        return result;
    }

    public static Result<TK> OnSuccess<T, TK>(this Result<T> result, Func<T, TK> func)
    {
        return result.IsSuccess ? Result.Ok(func(result.Value)) : Result.Fail<TK>(result.Error);
    }

    public static Result OnFailure(this Result result, Action action)
    {
        if (result.IsFailure)
        {
            action();
        }

        return result;
    }

    public static Result OnFailure(this Result result, Action<string> action)
    {
        if (result.IsFailure)
        {
            action(result.Error);
        }

        return result;
    }

    public static Result<T> OnFailure<T>(this Result<T> result, Action<string> action)
    {
        if (result.IsFailure)
        {
            action(result.Error);
        }

        return result;
    }

    public static Result Ensure(this Result result, Func<bool> predicate, string errorMessage)
    {
        if (result.IsFailure)
        {
            return result;
        }

        return predicate() ? result : Result.Fail(errorMessage);
    }

    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
    {
        if (result.IsFailure)
        {
            return result;
        }

        return predicate(result.Value) ? result : Result.Fail<T>(errorMessage);
    }

    public static Result<T> Map<T>(this Result result, Func<T> func)
    {
        return result.IsSuccess ? Result.Ok(func()) : Result.Fail<T>(result.Error);
    }

    public static Result<TK> Map<T, TK>(this Result<T> result, Func<T, TK> func)
    {
        return result.IsSuccess ? Result.Ok(func(result.Value)) : Result.Fail<TK>(result.Error);
    }
}

}