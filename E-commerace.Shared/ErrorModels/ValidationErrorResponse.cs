using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_commerace.Shared.ErrorModels
{
    public class ValidationErrorResponse : ErrorDetails
    {
        public ValidationErrorResponse()
           : base(StatusCodes.Status400BadRequest,
                 "One or more validation errors occurred.")
        {
        }
        [JsonPropertyOrder(3)]
        public IEnumerable<ValidationErrors> Errors { get; set; }

    }
    public class ValidationErrors
    {
        public string FieldName { get; set; }
        public IEnumerable<string> Message { get; set; }
    }
}

