namespace AlgoRay.Helpers
{
    public class AlgorithmicResult<T>
    {
        public AlgorithmicResult(T result, bool isSuccessful)
        {
            this.AlgorithmResult = result;
            this.IsSuccessful = isSuccessful;
        }

        public T AlgorithmResult { get; }

        public bool IsSuccessful { get; }
    }
}
