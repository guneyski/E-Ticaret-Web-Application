#pragma checksum "C:\Users\burak\Documents\ProjeA\ShopApp.WebUI\Views\Shared\_resultMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ede561d26dc2118861f54e9ed0d2947635f6ba6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__resultMessage), @"mvc.1.0.view", @"/Views/Shared/_resultMessage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_resultMessage.cshtml", typeof(AspNetCore.Views_Shared__resultMessage))]
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
#line 1 "C:\Users\burak\Documents\ProjeA\ShopApp.WebUI\Views\_ViewImports.cshtml"
using ShopApp.Entities;

#line default
#line hidden
#line 2 "C:\Users\burak\Documents\ProjeA\ShopApp.WebUI\Views\_ViewImports.cshtml"
using ShopApp.WebUI.Extensions;

#line default
#line hidden
#line 3 "C:\Users\burak\Documents\ProjeA\ShopApp.WebUI\Views\_ViewImports.cshtml"
using ShopApp.WebUI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ede561d26dc2118861f54e9ed0d2947635f6ba6", @"/Views/Shared/_resultMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bba9d18e6cd03824774928bc0c6e7efed7781353", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__resultMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultMessage>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(22, 171, true);
            WriteLiteral("\r\n<div id=\"myModal\" class=\"modal\">\r\n    <div class=\"modal-content\">\r\n        <span class=\"close\">&times;</span>\r\n        <h4 style=\"text-align:center\" class=\"alert-title\">");
            EndContext();
            BeginContext(194, 11, false);
#line 6 "C:\Users\burak\Documents\ProjeA\ShopApp.WebUI\Views\Shared\_resultMessage.cshtml"
                                                     Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(205, 44, true);
            WriteLiteral("</h4>\r\n        <p style=\"text-align:center\">");
            EndContext();
            BeginContext(250, 13, false);
#line 7 "C:\Users\burak\Documents\ProjeA\ShopApp.WebUI\Views\Shared\_resultMessage.cshtml"
                                Write(Model.Message);

#line default
#line hidden
            EndContext();
            BeginContext(263, 24, true);
            WriteLiteral("</p>\r\n    </div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultMessage> Html { get; private set; }
    }
}
#pragma warning restore 1591
