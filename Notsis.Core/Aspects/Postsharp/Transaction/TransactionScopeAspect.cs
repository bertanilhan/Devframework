using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Notsis.Core.Aspects.Postsharp.Transaction
{
    [PSerializable]
    public class TransactionScopeAspect:OnMethodBoundaryAspect
    {
        public TransactionScopeAspect()
        {
            
        }
        private TransactionScopeOption _option;
        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope();
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope) args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}
