using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MeetingScheduler.Validation
{
    public class ComboBoxValidation: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
            {
                return new ValidationResult(false, "Please select an item from the list.");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
