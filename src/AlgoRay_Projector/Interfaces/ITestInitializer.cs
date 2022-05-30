using System;
using System.Collections.Generic;
using System.Reflection;

namespace AlgoRay_Projector.Interfaces
{
    internal interface ITestInitializer
    {
        public void IfClassInitializeAttrExists_Initialize(Type typeofClass, object instance = null);

        public void IfTestInitializeAttrExists_Initialize(Type typeofClass, object instance = null);

        public dynamic GetTestClassInstance(Type type);

        public ICollection<MethodInfo> GetTestsFromAssembly(Type typeInAssembly);
    }
}
