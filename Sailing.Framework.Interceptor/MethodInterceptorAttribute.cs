using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sailing.Framework.Interceptor
{
    public abstract class MethodInterceptorAttribute : Attribute
    {
        public int Order { get; protected set; }

        public MethodInterceptorAttribute()
        {
            Order = 0;
        }

        public MethodInterceptorAttribute(int order)
        {
            Order = order;
        }

        public abstract Action Use(IInvocation invocation, Action action);
    }
}
