using System.Collections.Generic;
using System.Linq;

namespace AlgoRay
{
    public class AlgorithmicResponse<T>
    {


        public ICollection<T> Results { get; set; }

        public static implicit operator T[](AlgorithmicResponse<T> response)
            => response.Results.ToArray();

        public static implicit operator List<T>(AlgorithmicResponse<T> response)
            => response.Results.ToList();
    }
}
