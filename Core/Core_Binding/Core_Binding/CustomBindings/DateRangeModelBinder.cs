using Core_Binding.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace Core_Binding.CustomBindings
{
    public class DateRangeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            //get the query string parameter
            var query = bindingContext.HttpContext.Request.Query;
            //fetch the values based on the key
            var daterangequerystring = query["range"].ToString();
            //check if the value is null or empty
            if (string.IsNullOrEmpty(daterangequerystring))
            {
                return Task.CompletedTask;
            }

            //split the values by '-'
            var datevalues = daterangequerystring.Split('-');
            if (datevalues.Length != 2)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid Date Range Format");
                return Task.CompletedTask;
            }
            if (datevalues.Length == 2 && DateTime.TryParseExact(datevalues[0], "MM/dd/yyyy",
                provider, DateTimeStyles.None, out DateTime startDate) && DateTime.TryParseExact(
                    datevalues[1], "MM/dd/yyyy", provider, DateTimeStyles.None, out DateTime endDate))
            {
                var dateRange = new DateRange { StartDate = startDate, EndDate = endDate };
                bindingContext.Result = ModelBindingResult.Success(dateRange);
                return Task.CompletedTask;
            }
            else
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid Date Range Format");
                return Task.CompletedTask;
            }
        }
    }
}
