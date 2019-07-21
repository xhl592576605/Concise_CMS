using Microsoft.AspNetCore.Antiforgery;
using Concise_CMS.Controllers;

namespace Concise_CMS.Web.Host.Controllers
{
    public class AntiForgeryController : Concise_CMSControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
