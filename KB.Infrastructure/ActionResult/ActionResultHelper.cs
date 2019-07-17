using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.ActionResult
{
    public static class ActionResultHelper
    {

        public static ActionResult<T> Success<T>(T data)
        {
            return new ActionResult<T> { Data = data, IsSuccess = true };
        }
        public static ActionResult<T> Success<T>(T data,string message)
        {
            return new ActionResult<T> { Data = data, IsSuccess = true ,Message=message};
        }
        public static ActionResult<string> Fail(Exception e)
        {
            return new ActionResult<string>() { IsSuccess = false, Message = e.Message };
        }
        public static ActionResult<string> Fail(Exception e, string message)
        {
            return new ActionResult<string>() { IsSuccess = false, Message = message, Data = e.Message };
        }
        public static ActionResult<string> Fail(string message)
        {
            return new ActionResult<string>() { IsSuccess = false, Message = message};
        }
    }
}
