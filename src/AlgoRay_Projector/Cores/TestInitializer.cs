using AlgoRay.UnitTests.Helpers;
using AlgoRay_Projector.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AlgoRay_Projector.Cores
{
    internal class TestInitializer : ITestInitializer
    {
        private readonly HashSet<Type> _initilizedClasses = new HashSet<Type>();
        private readonly Dictionary<Type, dynamic> _testClassInstances = new Dictionary<Type, object>();

        public void IfClassInitializeAttrExists_Initialize(Type typeofClass, object instance = null)
        {
            if (_initilizedClasses.Contains(typeofClass))
            {
                return;
            }

            var classInitializeMethod = typeofClass.GetMethods()
                .FirstOrDefault(method => method.GetCustomAttributes(typeof(ClassInitializeAttribute), false).Length > 0);

            _initilizedClasses.Add(typeofClass);

            classInitializeMethod?.Invoke(instance, new object[] { null });
        }

        public void IfTestInitializeAttrExists_Initialize(Type typeofClass, object instance = null)
        {
            var testInitializeMethod = typeofClass.GetMethods()
                .FirstOrDefault(method => method.GetCustomAttributes(typeof(TestInitializeAttribute), false).Length > 0);

            testInitializeMethod?.Invoke(instance, new object[0]);
        }

        public dynamic GetTestClassInstance(Type type)
        {
            if (_testClassInstances.ContainsKey(type))
            {
                return _testClassInstances[type];
            }

            var newInstance = Activator.CreateInstance(type);

            _testClassInstances[type] = newInstance;

            return newInstance;
        }

        public ICollection<MethodInfo> GetTestsFromAssembly(Type typeInAssembly)
        => Assembly
                .GetAssembly(typeInAssembly?? typeof(TestRunner))
                .GetExportedTypes()
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(typeof(TestMethodAttribute), false).Length > 0)
                .ToArray();
    }
}
