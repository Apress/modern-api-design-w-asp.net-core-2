using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;
using System.Reflection;

namespace AwesomeConventions
{
    public class AwesomeApiControllerConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            var controllers = Assembly
            .GetExecutingAssembly()
            .GetExportedTypes()
            .Where(t => t.Name.EndsWith("Api"));
            foreach (var controller in controllers)
            {
                var controllerName = controller.Name.Replace("Api", "");
                var model = new ControllerModel(controller.GetTypeInfo(),
               controller.GetCustomAttributes().ToArray());
                model.ControllerName = controllerName;
                model.Selectors.Add(new SelectorModel
                {

                    AttributeRouteModel = new AttributeRouteModel()
                    {
                        Template = $"{controller.Namespace.Replace(".", "/")}/{controllerName}"
                    }
                });
                foreach (var action in controller.GetMethods().Where(p =>
               p.ReturnType == typeof(IActionResult)))
                {
                    var actionModel = new ActionModel(action, new object[] { new HttpGetAttribute() })
                    {
                        ActionName = action.Name
                    };
                    actionModel.Selectors.Add(new SelectorModel());
                    model.Actions.Add(actionModel);
                }
                application.Controllers.Add(model);
            }
        }
    }
}
