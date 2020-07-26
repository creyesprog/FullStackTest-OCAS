using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Infrastructure.Models.DTOs
{
    public class _BaseResponseDTO
    {
        public _BaseResponseDTO()
        {
            Errors = new List<Errors>();
        }

        public List<Errors> Errors { get; set; }
    }

    public class Errors
    {
        public string ErrorMessage { get; set; }
    }
}
