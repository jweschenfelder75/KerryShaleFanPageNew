using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace de.jweschenfelder.KSFP.Web.Annotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public sealed class SecuredEmailAddressAttribute : DataTypeAttribute
    {
        public SecuredEmailAddressAttribute()
            : base(DataType.EmailAddress)
        {
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            if (!(value is string valueAsString))
            {
                return false;
            }

            // only return true if there is only 1 '@' character
            // and it is neither the first nor the last character
            int index = valueAsString.IndexOf('@');

            return
                index > 0 &&
                index != valueAsString.Length - 1 &&
                index == valueAsString.LastIndexOf('@');
        }
    }
}
