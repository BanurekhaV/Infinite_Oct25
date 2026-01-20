using Microsoft.AspNetCore.Mvc.ModelBinding;
using Core_Binding.Models;
using Core_Binding.CustomBindings;

namespace Core_Binding.CustomBindings
{
    public class DateRangeModelProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            //based on model type meta data, this method will decide to call eitherthe custom binding
            //or not
            if(context.Metadata.ModelType == typeof(DateRange))
            {
                return new DateRangeModelBinder();
            }
            return null;
        }
    }
}
