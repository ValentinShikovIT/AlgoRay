namespace AlgoRay.Helpers
{
    public class AlgorithmicResult<T>
    {
        public AlgorithmicResult(T result, string exceptionMessage = null)
        {
            this.AlgorithmResult = result;
            this.ExceptionMessage = exceptionMessage;
        }

        public T AlgorithmResult { get; }

        public string ExceptionMessage { get; }
    }
}
