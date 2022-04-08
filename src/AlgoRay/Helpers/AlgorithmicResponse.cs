namespace AlgoRay.Helpers
{
    public class AlgorithmicResponse<T>
    {
        public AlgorithmicResponse(T result, bool isSuccessful)
        {
            this.AlgorithmResult = result;
            this.IsSuccessful = isSuccessful;
        }

        public T AlgorithmResult { get; }

        public bool IsSuccessful { get; }
    }
}
