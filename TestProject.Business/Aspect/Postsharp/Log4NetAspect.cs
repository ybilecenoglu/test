using Castle.Core.Logging;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Log.Log4Net;

namespace TestProject.Business.Aspect.Postsharp
{
    [Serializable]
    public class Log4NetAspect : OnMethodBoundaryAspect
    {
        Type _type;
        public Log4NetAspect(Type logType)
        {
            _type = logType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {

            //Log4NetTool.Log4NetLog(_type);
        }
    }
}
