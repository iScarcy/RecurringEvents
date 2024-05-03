using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Net;

namespace RecurringEvents.Web.Swagger
{
    public class ProducesResponseTypeConvention : IApplicationModelConvention
    {
        //elenco in maniera statica i miei actioinResult void
        private List<Type> _voidActionResults = new List<Type>() { typeof(void), typeof(Task) };
        public void Apply(ApplicationModel application)
        {
            var actions = application.Controllers.SelectMany(c => c.Actions).ToList();
            foreach (var action in actions)
            {
                if (_voidActionResults.Contains(action.ActionMethod.ReturnType))
                {
                    action.Filters.Add(new ProducesResponseTypeAttribute((int)HttpStatusCode.NoContent));
                }
                else
                {
                    var httpMethodAttribute = action.Attributes.OfType<HttpMethodAttribute>().FirstOrDefault();
                    switch (httpMethodAttribute?.HttpMethods.FirstOrDefault())
                    {
                        case "GET":
                            action.Filters.Add(new ProducesResponseTypeAttribute((int)HttpStatusCode.OK));
                            if (!action.ActionMethod.ReturnType.IsAssignableFrom(typeof(Enumerable)))
                            {
                                action.Filters.Add(new ProducesResponseTypeAttribute((int)HttpStatusCode.NotFound));
                            }
                            break;
                        case "POST":
                            action.Filters.Add(new ProducesResponseTypeAttribute((int)HttpStatusCode.OK));
                            action.Filters.Add(new ProducesResponseTypeAttribute((int)HttpStatusCode.BadRequest));
                            break;
                        case "PUT":
                            break;
                        case "DELETE":
                            break;
                        case "PATCH":
                            break;



                    }
                }
            }
        }
    }
}
