﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Collections.Generic;

namespace Supermarket.API.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage)
                             .ToList();
        }
    }
}

// convert the validation errors into simple strings to return to the client.