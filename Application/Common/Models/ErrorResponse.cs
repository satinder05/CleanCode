using System.Collections.Generic;

namespace Application.Common.Models
{
    public class ErrorResponse
    {
        public List<Error> Errors { get; set; } = new List<Error>();
    }
}
