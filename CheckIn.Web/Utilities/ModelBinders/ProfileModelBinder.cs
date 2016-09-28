using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckIn.Web.Models.Channel.Profile;

namespace CheckIn.Web.Utilities.ModelBinders
{
    public class ProfileModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var result = bindingContext.ValueProvider.GetValue("ModelType");
            var type = Type.GetType((string)result.ConvertTo(typeof(string)), true);
            if (!typeof(BaseProfileModel).IsAssignableFrom(type))
            {
                throw new InvalidOperationException("Bad Type - Cannot Bind");
            }
            var model = Activator.CreateInstance(type);
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);
            return model;
        }
    }
}