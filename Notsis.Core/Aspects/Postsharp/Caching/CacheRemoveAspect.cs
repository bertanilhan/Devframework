using System;
using System.Collections.Generic;
using System.Text;
using Notsis.Core.CrossCuttingConcerns.Caching.Microsoft;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Notsis.Core.Aspects.Postsharp.Caching
{
    [PSerializable]
    public class CacheRemoveAspect:OnMethodBoundaryAspect
    {
        private string _pattern;

        public CacheRemoveAspect()
        {
        }

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
        }

        public CacheRemoveAspect(Type typeManager)
        {
            _pattern = string.Format("{0}.{1}.*", typeManager.ReflectedType.Namespace, typeManager.ReflectedType.Name);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            var cacheManager = new MemoryCacheManager();

            cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern)
                ? string.Format("{0}.{1}.*", args.Method.ReflectedType.Namespace, args.Method.ReflectedType.Name)
                : _pattern);
        }
    }
}
