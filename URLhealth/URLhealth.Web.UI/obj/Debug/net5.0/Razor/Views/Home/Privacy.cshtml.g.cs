#pragma checksum "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Home\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96c9601ff9eabfe94d9c4c27e0f028f3c94aea31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\_ViewImports.cshtml"
using URLhealth.Web.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\_ViewImports.cshtml"
using URLhealth.Web.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Home\Privacy.cshtml"
using URLhealth.Entities.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Home\Privacy.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Home\Privacy.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96c9601ff9eabfe94d9c4c27e0f028f3c94aea31", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0bad40f0d4f0a4de0d6549a1e8cd4e435f5ed2d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<URLhealth.Entities.DTO.UrlDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Home\Privacy.cshtml"
  
    ViewData["Title"] = "URL Monitoring";
    string name = "";
    int uid = 0;
    USERS sessionManager = null;
    var value = HttpContextAccessor.HttpContext.Session.GetString("SessionManager");

    short logged = 0;

    if (value != null)
    {
        sessionManager = JsonConvert.DeserializeObject<USERS>(value);
        if (sessionManager != null)
        {
            uid = sessionManager.ID;
            logged = 1;
            name = sessionManager.MAIL;
        }
        else
        {
            Context.Response.Redirect("/Home/Index");
        }
    }
    else
    {
        Context.Response.Redirect("/Home/Index");
    }
    ViewData["Name"] = name;


#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Privacy</h1>\r\n\r\n<p>Use this page to detail your site\'s privacy policy.</p>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<URLhealth.Entities.DTO.UrlDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
