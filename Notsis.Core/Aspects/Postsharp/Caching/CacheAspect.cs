using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Notsis.Core.CrossCuttingConcerns.Caching;
using Notsis.Core.Utilities.IoC;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Notsis.Core.Aspects.Postsharp.Caching
{
    [PSerializable]
    public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cacheType;
        private ICacheManager _cacheManager;
        private int _duration;

        public CacheAspect(Type cacheType, int duration = 60)
        {
            _duration = duration;
            _cacheType = cacheType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (!typeof(ICacheManager).IsAssignableFrom(_cacheType))
            {
                throw new Exception("Wrong cache type");
            }
            if (_cacheType != null)
            {
                //_cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
                _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            }
            
            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            //Notsis.Business.Concrete.Productmanager.Getlist()
            var methodName = string.Format($"{args.Method.ReflectedType.FullName}.{args.Method.Name}");

            var arguments = args.Arguments.ToList();

            var key = string
                .Format($"{methodName}({arguments.Select(i => i.ToString() ?? "<Null>")})");

            if (_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.Get(key);
                return;
            }
            base.OnInvoke(args);
            _cacheManager.Add(key,args.ReturnValue,_duration);
        }
    }
}
