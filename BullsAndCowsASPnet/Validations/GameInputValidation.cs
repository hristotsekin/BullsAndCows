using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace BullsAndCowsASPnet.Validations
{
    public class GameInputValidation : RemoteAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            Type controller = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(
                    type => type.Name.ToLower() ==
                            string.Format("{0}Controller",
                                this.RouteData["controller"].ToString().ToLower())
                );

            return new ValidationResult("Not found");
        }
    }
}