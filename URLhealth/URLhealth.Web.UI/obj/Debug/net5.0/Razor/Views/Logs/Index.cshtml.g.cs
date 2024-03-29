#pragma checksum "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a25ad2dcd8e37ddc10c7a026076517800249c67"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Logs_Index), @"mvc.1.0.view", @"/Views/Logs/Index.cshtml")]
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
#line 3 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml"
using URLhealth.Entities.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a25ad2dcd8e37ddc10c7a026076517800249c67", @"/Views/Logs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0bad40f0d4f0a4de0d6549a1e8cd4e435f5ed2d", @"/Views/_ViewImports.cshtml")]
    public class Views_Logs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<URLhealth.Entities.Concrete.LOGS>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml"
  
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
    }
    else
    {
        Context.Response.Redirect("/Home/Index");
    }
    ViewData["Name"] = name;


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 36 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml"
 if (Model != null)
{
    long ctr = 1;


#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row"">
        <table class=""table table-striped table-bordered"" id=""myTable"">
            <thead>
                <tr>
                    <th scope=""col"">#</th>
                    <th scope=""col"">Başlık</th>
                    <th scope=""col"">Operasyon</th>
                    <th scope=""col"">Mesaj</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 51 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <th scope=\"row\">");
#nullable restore
#line 54 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml"
                                   Write(ctr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <td>");
#nullable restore
#line 55 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml"
                       Write(item.LEVEL);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 56 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml"
                       Write(item.URL);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 57 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml"
                       Write(item.MESSAGE);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 59 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml"

                    ctr++;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
#nullable restore
#line 65 "C:\Users\DIZDAS\source\GitHub\URLhealth\URLhealth\URLhealth.Web.UI\Views\Logs\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<URLhealth.Entities.Concrete.LOGS>> Html { get; private set; }
    }
}
#pragma warning restore 1591
