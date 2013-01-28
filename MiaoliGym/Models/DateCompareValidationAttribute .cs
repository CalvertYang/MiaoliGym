using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.Mvc;

namespace MiaoliGym.Models
{
    public sealed class DateCompareValidationAttribute : ValidationAttribute, IClientValidatable
    {
        // 比較類型
        public enum CompareType
        {
            GreatherThen,
            GreatherThenOrEqualTo,
            EqualTo,
            LessThenOrEqualTo,
            LessThen
        }

        private CompareType _compareType;
        private DateTime _fromDate;
        private DateTime _toDate;
        private string _propertyNameToCompare;

        public DateCompareValidationAttribute(CompareType compareType, string message, string compareWith = "")
        {
            _compareType = compareType;
            _propertyNameToCompare = compareWith;
            ErrorMessage = message;
        }


        #region IClientValidatable Members

        /// <summary>
        /// Generates client validation rules
        /// </summary>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ValidateAndGetCompareToProperty(metadata.ContainerType);
            var rule = new ModelClientValidationRule();

            rule.ErrorMessage = ErrorMessage;
            rule.ValidationParameters.Add("comparetodate", _propertyNameToCompare);
            rule.ValidationParameters.Add("comparetype", _compareType);
            rule.ValidationType = "compare";

            yield return rule;
        }

        #endregion


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Have to override IsValid method. If you have any logic for server site validation, put it here. 
            return ValidationResult.Success;

        }

        /// <summary>
        /// verifies that the compare-to property exists and of the right types and returnes this property
        /// </summary>
        /// <param name="containerType">Type of the container object</param>
        /// <returns></returns>
        private PropertyInfo ValidateAndGetCompareToProperty(Type containerType)
        {
            var compareToProperty = containerType.GetProperty(_propertyNameToCompare);
            if (compareToProperty == null)
            {
                string msg = string.Format("Invalid design time usage of {0}. Property {1} is not found in the {2}", this.GetType().FullName, _propertyNameToCompare, containerType.FullName);
                throw new ArgumentException(msg);
            }
            if (compareToProperty.PropertyType != typeof(DateTime) && compareToProperty.PropertyType != typeof(DateTime?))
            {
                string msg = string.Format("Invalid design time usage of {0}. The type of property {1} of the {2} is not DateType", this.GetType().FullName, _propertyNameToCompare, containerType.FullName);
                throw new ArgumentException(msg);
            }

            return compareToProperty;
        }
    }
}