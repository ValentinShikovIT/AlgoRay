namespace AlgoRay.UnitTests.Helpers
{
    public class TestResult<T>
    {
        public TestResult(bool isSuccessful, T result)
        {
            this.IsSuccessful = isSuccessful;
            this.Value = result;
        }

        public bool IsSuccessful { get; }

        public T Value { get; }
    }
}
