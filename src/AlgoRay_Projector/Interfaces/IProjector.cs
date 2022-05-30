using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace AlgoRay_Projector.Interfaces
{
    internal interface IProjector
    {
        public Task<(int successTests, int failedTests)> MainLogic(ICollection<MethodInfo> allTestMethods);
    }
}
