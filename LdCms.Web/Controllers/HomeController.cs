using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace LdCms.Web.Controllers
{
    using LdCms.IBLL.Sys;
    using LdCms.Web.Models;
    

    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        private readonly SiteConfig SiteConfig;
        private readonly IHttpContextAccessor Accessor;
        private readonly IConfigService ConfigService;
        
        public HomeController(IOptions<SiteConfig> SiteConfig, IHttpContextAccessor Accessor, IConfigService ConfigService)
        {
            this.SiteConfig = SiteConfig.Value;
            this.Accessor = Accessor;
            this.ConfigService = ConfigService;
        }
        public IActionResult Index()
        {
            try
            {
                int systemId = BaseSystemConfig.SystemID;
                string companyId = SiteConfig.CompanyID;
                var entity = ConfigService.GetConfig(systemId, companyId);
                string homeUrl =string.IsNullOrEmpty(entity.HomeUrl)? SiteConfig.HomeUrl : entity.HomeUrl;
                return Redirect(homeUrl);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IActionResult Error()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                @ViewBag.Error = ex.Message;
                return View();
            }
        }
        public JsonResult Show()
        {
            return Json(SiteConfig);
        }

    }


}
