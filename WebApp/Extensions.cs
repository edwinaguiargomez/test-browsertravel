using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace WebApp.Extensions
{

    static class Extensions
    {
        public static string GetFullErrorMessage(this Exception exception)
        {
            var messages = new List<string>();

            while (exception != null)
            {
                messages.Add(exception.Message);
                exception = exception.InnerException;
            }

            return String.Join(" ", messages);
        }
    }
}