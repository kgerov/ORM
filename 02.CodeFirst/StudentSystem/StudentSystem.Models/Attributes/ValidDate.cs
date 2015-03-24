namespace StudentSystem.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ValidDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = Convert.ToDateTime(value);

            if (date <= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
