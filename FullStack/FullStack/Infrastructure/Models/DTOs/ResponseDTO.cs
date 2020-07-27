using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Models.DTOs
{
    public class ResponseDTO : ErrorModel
    {
        public ResponseDTO(IErrorModel errorModel)
        {
            Errors = errorModel.Errors;
        }
    }
}
