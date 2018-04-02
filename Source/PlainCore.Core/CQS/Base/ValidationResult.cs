﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlainCore.Core.CQS.Base
{
    public class ValidationResult
    {
        public ValidationResult()
        {
  
        }

        public ValidationResult(IList<ValidationError> errors) : this()
        {
            Errors = errors;
        }

        public ValidationResult(FluentValidation.Results.ValidationResult validationResult)
        {
            Errors = validationResult.Errors.Select(x => new ValidationError() { AttemptedValue = x.AttemptedValue, ErrorMessage = x.ErrorMessage, PropertyName = x.PropertyName }).ToList();
        }


        public IList<ValidationError> Errors { get; set; } = new List<ValidationError>();
        public bool IsValid
        {
            get
            {
                if (Errors.Count() > 0)
                    return false;
                else
                    return true;
            }
        }
    }
}
