using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailing.Framework.Interceptor
{
    public class MethodInterceptorBuilder
    {
        public object BuildInstanceWithMethodInterceptor(object instance, Type instanceType)
        {
            ProxyGenerator generator = new ProxyGenerator();
            IInterceptor interceptor = new MethodInterceptor();
            return generator.CreateInterfaceProxyWithTarget(instanceType, instance, interceptor);
        }

        public T BuildInstanceWithMethodInterceptor<T>(T instance) where T : class
        {
            ProxyGenerator generator = new ProxyGenerator();
            IInterceptor interceptor = new MethodInterceptor();
            return generator.CreateInterfaceProxyWithTarget<T>(instance, interceptor);
        }
    }
}
