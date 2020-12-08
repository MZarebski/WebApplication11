using System.Linq;
using System.Threading;
using System.Web.Http;
using ClassLibrary1;
//using Realms;
using Umbraco.Web.WebApi;
//using WebApplication11.Database;


namespace WebApplication11.Controllers
{
    public class HomeController : UmbracoApiController
    {
        [HttpGet]
        public string Index()
        {
            var foo = new Foo();
            foo.Bar();
            var content = UmbracoContext.Content.GetAtRoot();
            var properties = content.First().Properties;
            return "a";
        }
    }
}