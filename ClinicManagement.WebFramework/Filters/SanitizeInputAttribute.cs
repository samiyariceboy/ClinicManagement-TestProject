using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace ClinicManagement.WebFramework.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SanitizeInputAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sanitizer = new Ganss.XSS.HtmlSanitizer();
            if (context.ActionArguments != null)
            {
                foreach (var parameter in context.ActionArguments)
                {
                    var properties = parameter.Value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Where(x => x.CanRead && x.CanWrite && x.PropertyType == typeof(string) && x.GetGetMethod(true).IsPublic && x.GetSetMethod(true).IsPublic);
                    foreach (var propertyInfo in properties)
                    {
                        if (propertyInfo.GetValue(parameter.Value) != null)
                            propertyInfo.SetValue(parameter.Value,
                                sanitizer.Sanitize(propertyInfo.GetValue(parameter.Value).ToString()));
                    }
                }
            }
        }
    }
}
