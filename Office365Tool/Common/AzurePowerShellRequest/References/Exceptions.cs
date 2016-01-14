using Microsoft.Online.Administration.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    internal class DynamicPInvokeException : Exception
    {
        public DynamicPInvokeException(string msg)
            : base(msg)
        { }
    }

    internal class WindowsLiveException : Exception
    {
        public WindowsLiveException(int errorCodeParameter, string msg)
           : base(string.Format("{0}, errorCode : {1}, details:{2}", errorCodeParameter, msg, ErrorMessageTable.GetErrorMessage(errorCodeParameter)))
        {
            this.ErrorCodeParameter = errorCodeParameter;
        }

        public int ErrorCodeParameter { get; private set; }
    }
}
