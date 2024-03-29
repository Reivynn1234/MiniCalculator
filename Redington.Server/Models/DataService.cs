﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Redington.Server.Models
{
    // This service class is the middleman between Data Model and Calculation Controller to keep thin controllers and models
    public class DataService
    {
        public bool IsValid(Data dataToValidate)
        {
            // If A or B is null this will short circut and not cause a exception
            return dataToValidate.A != null && dataToValidate.B != null && dataToValidate.A >= 0 && dataToValidate.A <= 1 && dataToValidate.B >= 0 && dataToValidate.B <= 1;
        }

        public double CombinedWith(Data data)
        {
            if (!IsValid(data))
            {
                return -1;
            }
            return data.A * data.B ?? throw new Exception("Null values in input"); // This shouldn't happen because of validation
        }

        public double Either(Data data)
        {
            if (!IsValid(data))
            {
                return -1;
            }
            return data.A + data.B - CombinedWith(data) ?? throw new Exception("Null values in input"); // This shouldn't happen because of validation
        }
    }
}
