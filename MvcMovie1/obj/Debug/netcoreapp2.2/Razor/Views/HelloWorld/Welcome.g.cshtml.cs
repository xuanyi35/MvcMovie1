#pragma checksum "/home/osboxes/ASP/MvcMovie1/MvcMovie1/Views/HelloWorld/Welcome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "058a93b3844c20a5831adccd303ea51bfeeda08f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HelloWorld_Welcome), @"mvc.1.0.view", @"/Views/HelloWorld/Welcome.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/HelloWorld/Welcome.cshtml", typeof(AspNetCore.Views_HelloWorld_Welcome))]
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
#line 1 "/home/osboxes/ASP/MvcMovie1/MvcMovie1/Views/_ViewImports.cshtml"
using MvcMovie1;

#line default
#line hidden
#line 2 "/home/osboxes/ASP/MvcMovie1/MvcMovie1/Views/_ViewImports.cshtml"
using MvcMovie1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"058a93b3844c20a5831adccd303ea51bfeeda08f", @"/Views/HelloWorld/Welcome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08ee33a4654b952c7336f7d6198f501b07b1db4f", @"/Views/_ViewImports.cshtml")]
    public class Views_HelloWorld_Welcome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/home/osboxes/ASP/MvcMovie1/MvcMovie1/Views/HelloWorld/Welcome.cshtml"
  
    ViewData["Title"] = "Welcome";

#line default
#line hidden
            BeginContext(40, 24, true);
            WriteLiteral("\n<h2>Welcome</h2>\n\n<ul>\n");
            EndContext();
#line 8 "/home/osboxes/ASP/MvcMovie1/MvcMovie1/Views/HelloWorld/Welcome.cshtml"
     for (int i = 0; i < (int)ViewData["NumTimes"]; i++)
    {

#line default
#line hidden
            BeginContext(127, 12, true);
            WriteLiteral("        <li>");
            EndContext();
            BeginContext(140, 19, false);
#line 10 "/home/osboxes/ASP/MvcMovie1/MvcMovie1/Views/HelloWorld/Welcome.cshtml"
       Write(ViewData["Message"]);

#line default
#line hidden
            EndContext();
            BeginContext(159, 6, true);
            WriteLiteral("</li>\n");
            EndContext();
#line 11 "/home/osboxes/ASP/MvcMovie1/MvcMovie1/Views/HelloWorld/Welcome.cshtml"
    }

#line default
#line hidden
            BeginContext(171, 5, true);
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
