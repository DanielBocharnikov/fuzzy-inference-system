using System;
using System.Collections.Generic;

namespace FuzzyInferenceSystem.SeedWork.Functional
{
  public abstract class Result
  {
    public bool Success { get; protected set; }

    public bool Failure => !Success;
  }

  public abstract class Result<T> : Result
  {
    private T _data;

    protected Result(T data) => Data = data;

    public T Data
    {
      get
        => Success
          ? _data
          : throw new Exception($"You can't access .{nameof(Data)} when .{nameof(Success)} is false");

      set => _data = value;
    }
  }

  public class SuccessResult : Result
  {
    public SuccessResult() => Success = true;
  }

  public class SuccessResult<T> : Result<T>
  {
    public SuccessResult(T data) : base(data) => Success = true;
  }

  public class ErrorResult : Result, IErrorResult
  {
    public string Message { get; }

    public IReadOnlyCollection<Error> Errors { get; }

    public ErrorResult(string message, IReadOnlyCollection<Error> errors)
    {
      Message = message;
      Success = false;
      Errors = errors ?? Array.Empty<Error>();
    }
  }

  public class ErrorResult<T> : Result<T>, IErrorResult
  {
    public string Message { get; set; }

    public IReadOnlyCollection<Error> Errors { get; set; }

    public ErrorResult(string message)
      : this(message, Array.Empty<Error>())
    {
    }

    public ErrorResult(string message, IReadOnlyCollection<Error> errors)
      : base(default)
    {
      Message = message;
      Success = false;
      Errors = errors ?? Array.Empty<Error>();
    }
  }

  internal interface IErrorResult
  {
    string Message { get; }

    IReadOnlyCollection<Error> Errors { get; }
  }

  public class Error
  {
    public string Code { get; }

    public string Details { get; }

    public Error(string details) : this(null, details)
    {
    }

    public Error(string code, string details)
      => (Code, Details) = (code, details);
  }
}
