using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API.Exceptions
{

    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }
}
