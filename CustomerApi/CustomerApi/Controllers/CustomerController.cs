using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Filters;

namespace CustomerApi.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        [JsonOutput]
        public IEnumerable<Models.Customer> Get()
        {
            var response = new List<Models.Customer>() ;

           var customer = new  Models.Customer(1,"virender",37,"Wien",1020,"Wien","Austria");
            response.Add(customer);
            
            return new response;
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }

    public class JsonOutputAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            ObjectContent content = actionExecutedContext.Response.Content as ObjectContent;
            var value = content.Value;
            Type targetType = actionExecutedContext.Response.Content.GetType().GetGenericArguments()[0];

            var httpResponseMsg = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                RequestMessage = actionExecutedContext.Request,
                Content = new ObjectContent(targetType, value, new JsonMediaTypeFormatter(), (string)null)
            };

            actionExecutedContext.Response = httpResponseMsg;
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
