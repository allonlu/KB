using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.ActionResult
{
    public static class ActionResultHelper
    {

        public static MyActionResult<T> Success<T>(T data)
        {
            return new MyActionResult<T> { Data = data, IsSuccess = true };
        }
        public static MyActionResult<T> Success<T>(T data,string message)
        {
            return new MyActionResult<T> { Data = data, IsSuccess = true ,Message=message};
        }
        public static MyActionResult<string> Fail(Exception e)
        {
            return new MyActionResult<string>() { IsSuccess = false, Message = e.Message };
        }
        public static MyActionResult<string> Fail(Exception e, string message)
        {
            return new MyActionResult<string>() { IsSuccess = false, Message = message, Data = e.Message };
        }

        public static MyActionResult<T> Fail<T>(Exception e)
        {

            return new MyActionResult<T>() { IsSuccess = false, Message = e.Message };
        }

        public static MyActionResult<string> Fail(string message)
        {
            return new MyActionResult<string>() { IsSuccess = false, Message = message};
        }
    }
}
