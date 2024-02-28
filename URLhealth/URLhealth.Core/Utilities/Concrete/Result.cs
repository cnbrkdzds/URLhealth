using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.Core.Utilities.Abstract;
using URLhealth.Core.Utilities.ComplexTypes;

namespace URLhealth.Core.Utilities.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        public Result(ResultStatus resultStatus, string message, Exception excepiton)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = excepiton;
        }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }

        public Exception Exception { get; }
    }
}
