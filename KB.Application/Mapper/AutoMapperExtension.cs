using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Application.AppServices
{
   public static class AutoMapperExtension
    {
        public static S MapTo<S>(this object source){
            return AutoMapper.Mapper.Map<S>(source);
        }
    }
}
