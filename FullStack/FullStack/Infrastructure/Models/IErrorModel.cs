using System.Collections.Generic;

namespace FullStack.Infrastructure.Models.DTOs
{
    public interface IErrorModel
    {
        List<IError> Errors { get; set; }
    }
}