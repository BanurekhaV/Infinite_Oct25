using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core_Binding.CustomBindings
{
    public class CommaSeperatedModel : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //get the query string parameter
            var query = bindingContext.HttpContext.Request.Query;

            //fetch the value based on the key
            var Ids = query["Ids"].ToString();

            //check if the value is not null
            if(string.IsNullOrEmpty(Ids) )
            {
                return Task.CompletedTask;
            }

            //splitting the comma seperated values
            var values = Ids.Split(',').Select(int.Parse).ToList();
                
                //create a model binding result
            bindingContext.Result = ModelBindingResult.Success(values);
            return Task.CompletedTask;
        }
    }
}
