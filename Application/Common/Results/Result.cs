namespace ERPAppApplication.Common.Results
{
    public class Result<T>
    {
        public bool Succeeded { get;}
        public T? Data { get;}
        public IReadOnlyList<string> Errors { get;}

        private Result(bool succeeded,T? data, IReadOnlyList<string> errors)
        {
            Succeeded = succeeded;
            Data = data;
            Errors = errors;
        }
        public static Result<T> Success(T data)
            => new(true,data,Array.Empty<string>());

        public static Result<T> Failure(params string[] errors)
            => new(false,default,errors);

    }
}
