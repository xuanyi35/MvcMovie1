#pragma checksum "/home/osboxes/ASP/MvcMovie1/MvcMovie1/Views/Home/About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8bc5039f6ac5a7820f0fa7145bb7674bbfe54033"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/About.cshtml", typeof(AspNetCore.Views_Home_About))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bc5039f6ac5a7820f0fa7145bb7674bbfe54033", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08ee33a4654b952c7336f7d6198f501b07b1db4f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/home/osboxes/ASP/MvcMovie1/MvcMovie1/Views/Home/About.cshtml"
  
    ViewData["Title"] = "About";

#line default
#line hidden
            BeginContext(38, 65, true);
            WriteLiteral("\n<script>window.sessionStorage.removeItem(\'page\');</script>\n\n<h2>");
            EndContext();
            BeginContext(104, 17, false);
#line 7 "/home/osboxes/ASP/MvcMovie1/MvcMovie1/Views/Home/About.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(121, 912, true);
            WriteLiteral(@"</h2>


<h3 > User Guidance </h3>
<br>
<h4 style=""margin-left:5%;""> Description </h4>
<p id=""desc"" style=""line-height:1.5; margin-left:5%;"">
    You can find the latest Movies in Movie Station.<br /> Key points: <br />
    <li style=""line-height:1.5; margin-left:6%;""> Search by keyword </li>
    <li style=""line-height:1.5; margin-left:6%;""> Search by Genres </li>
    <li style=""line-height:1.5; margin-left:6%;""> Show Movie Details</li>
    <li style=""line-height:1.5; margin-left:6%;""> Show Trailer if it is uploaded </li>
    <li style=""line-height:1.5; margin-left:6%;""> Reconmend smilar movies </li>
    <li style=""line-height:1.5; margin-left:6%;""> Add movie to your favourite movie list after login</li>
    <li style=""line-height:1.5; margin-left:6%;""> Login to manage your favouite movie list </li>
</p>
<br>

<img src=""../../images/Movie_UI.png"" alt=""UI"" style=""width:90%; margin:1%  0  5%  5%;"" >

 ");
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
