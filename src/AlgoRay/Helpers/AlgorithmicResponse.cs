using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Helpers
{
    public class AlgorithmicResponse<T>
    {
        public AlgorithmicResponse(ICollection<T> result, bool isSuccessful)
        {
            this.AlgorithmResult = result;
            this.IsSuccessful = isSuccessful;
        }

        public ICollection<T> AlgorithmResult { get; }

        public bool IsSuccessful { get; }

        public static implicit operator T[](AlgorithmicResponse<T> response)
            => response.AlgorithmResult.ToArray();

        public static implicit operator List<T>(AlgorithmicResponse<T> response)
            => response.AlgorithmResult.ToList();
    }
}
