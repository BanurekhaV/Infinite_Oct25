using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core_Binding.CustomBindings
{
    public class CommaSeparatedprovider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(List<int>))
            {
                return new CommaSeperatedModel();
            }
            return null;
        }
    }
   
}
