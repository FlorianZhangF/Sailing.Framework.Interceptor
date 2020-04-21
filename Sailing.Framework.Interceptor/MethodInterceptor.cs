using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sailing.Framework.Interceptor
{
    internal class MethodInterceptor : StandardInterceptor
    {
        /// <summary>
        /// 1、调用前
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PreProceed(IInvocation invocation)
        {
        }

        /// <summary>
        /// 2、返回时，只有这边调用base.PerformProceed(invocation)才会执行具体的方法
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PerformProceed(IInvocation invocation)
        {
            Action action = () =>
            {
                base.PerformProceed(invocation);
            };

            //将object数组转成MethodInterceptorAttribute的List
            var attributeList = Array.ConvertAll(invocation.Method.GetCustomAttributes(typeof(MethodInterceptorAttribute), true), new Converter<object, MethodInterceptorAttribute>(u =>
             {
                 return (MethodInterceptorAttribute)u;
             }));

            //var list = new List<MethodInterceptorAttribute>();

            //foreach (var attribute in invocation.Method.GetCustomAttributes(typeof(MethodInterceptorAttribute), true).ToArray().Reverse())
            foreach (var attribute in attributeList.OrderBy(u => u.Order).Reverse())
            {
                action = attribute.Use(invocation, action);
            }

            action.Invoke();
        }

        /// <summary>
        /// 3、调用后
        /// </summary>
        /// <param name="invocation"></param>
        protected override void PostProceed(IInvocation invocation)
        {
        }
    }
}
