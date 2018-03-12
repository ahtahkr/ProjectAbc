using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Library;

namespace ProjectAbc.Controllers
{
    [Route("")]
    public class AdminController : Controller
    {
        [Route("")]
        public void Main()
        {

            var method = System.Reflection.MethodBase.GetCurrentMethod();
            var fullName = string.Format("{0}.{1}({2})", method.ReflectedType.FullName, method.Name, string.Join(",", method.GetParameters().Select(o => string.Format("{0} {1}", o.ParameterType, o.Name)).ToArray()));

            string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Response.Redirect(baseUrl + "/GitAccessor");

            /*if ((User != null) && User.Identity.IsAuthenticated)
            {
                Response.Redirect(baseUrl + "/Account/Index");
            } else
            {
                Response.Redirect(baseUrl + "/Account/Login");
            }*/
        }
    }
}