using System.Collections.Generic;
using System.Linq;

namespace AlgoRay
{
    public class AlgorithmicResponse<T>
    {
        public AlgorithmicResponse(ICollection<T> result, bool isSuccessful)
        {
            this.Result = result;
            this.IsSuccessful = isSuccessful;
        }

        public ICollection<T> Result { get; }

        public bool IsSuccessful { get; }

        public static implicit operator T[](AlgorithmicResponse<T> response)
            => response.Result.ToArray();

        public static implicit operator List<T>(AlgorithmicResponse<T> response)
            => response.Result.ToList();
    }
}
