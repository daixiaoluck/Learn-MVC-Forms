using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication1.Validation
{
    public class MustBeChecked:ValidationAttribute, IClientValidatable
    {
        public MustBeChecked():base("{0} must be checked.")
        {

        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationType = "mustbechecked";
            yield return rule;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is bool)
            {
                bool parseValue = (bool)value;
                if (parseValue)
                {
                    return ValidationResult.Success;
                }
            }
            var errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return new ValidationResult(errorMessage);
        }
    }
}