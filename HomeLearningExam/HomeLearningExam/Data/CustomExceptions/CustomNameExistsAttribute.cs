using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CustomExceptions
{
    public class CustomNameExistsAttribute : ValidationAttribute
    {

        public CustomNameExistsAttribute(string name)
        {
            CustomName = name;
        }

        public string CustomName { get; }

        public string GetErrorMessage() =>
            $"Can't create Task with existing name. Choose new name";

        //protected override ValidationResult IsValid(object value,
        //    ValidationContext validationContext)
        //{
        //    var movie = (Movie)validationContext.ObjectInstance;
        //    var releaseYear = ((DateTime)value).Year;

        //    if (movie.Genre == Genre.Classic && releaseYear > Year)
        //    {
        //        return new ValidationResult(GetErrorMessage());
        //    }

        //    return ValidationResult.Success;
        //}
    }
}
