using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAbc.Controllers
{
    //[Route("[controller]")]
    //public class AccountController : Controller
    //{
    //    [Route("")]
    //    public void Main()
    //    {
    //        var method = System.Reflection.MethodBase.GetCurrentMethod();
    //        var fullName = string.Format("{0}.{1}({2})", method.ReflectedType.FullName, method.Name, string.Join(",", method.GetParameters().Select(o => string.Format("{0} {1}", o.ParameterType, o.Name)).ToArray()));
            
    //        string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/Account/";
    //        if ((User != null) && User.Identity.IsAuthenticated)
    //        {
    //            baseUrl += "Index";
    //        } else {
    //            baseUrl += "Login";
    //        }
    //        Response.Redirect(baseUrl);
    //    }

    //    [Route("[action]")]
    //    public IActionResult Index()
    //    {
    //        var method = System.Reflection.MethodBase.GetCurrentMethod();
    //        var fullName = string.Format("{0}.{1}({2})", method.ReflectedType.FullName, method.Name, string.Join(",", method.GetParameters().Select(o => string.Format("{0} {1}", o.ParameterType, o.Name)).ToArray()));
            
    //        return View();
    //    }

    //    [Route("[action]")]
    //    public IActionResult Login()
    //    {
    //        var method = System.Reflection.MethodBase.GetCurrentMethod();
    //        var fullName = string.Format("{0}.{1}({2})", method.ReflectedType.FullName, method.Name, string.Join(",", method.GetParameters().Select(o => string.Format("{0} {1}", o.ParameterType, o.Name)).ToArray()));
            
    //        return View();
    //    }

    //    [Route("[action]")]
    //    public IActionResult Logout()
    //    {
    //        var method = System.Reflection.MethodBase.GetCurrentMethod();
    //        var fullName = string.Format("{0}.{1}({2})", method.ReflectedType.FullName, method.Name, string.Join(",", method.GetParameters().Select(o => string.Format("{0} {1}", o.ParameterType, o.Name)).ToArray()));
            
    //        return View();
    //    }
    //}
}