#pragma checksum "C:\Aktueller Kurs\ASPNETCore_Grundlagen20210426\ASPNETCore_Grundlagen_20210426\StateManangementSample\Views\StateManagement\ViewBagSample.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c37570b7f2a6bb0205e72c96da569fe5a7b55a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StateManagement_ViewBagSample), @"mvc.1.0.view", @"/Views/StateManagement/ViewBagSample.cshtml")]
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
#line 1 "C:\Aktueller Kurs\ASPNETCore_Grundlagen20210426\ASPNETCore_Grundlagen_20210426\StateManangementSample\Views\_ViewImports.cshtml"
using StateManangementSample;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Aktueller Kurs\ASPNETCore_Grundlagen20210426\ASPNETCore_Grundlagen_20210426\StateManangementSample\Views\_ViewImports.cshtml"
using StateManangementSample.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c37570b7f2a6bb0205e72c96da569fe5a7b55a1", @"/Views/StateManagement/ViewBagSample.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b61209fadac34f9df18c0b11cb4585321d9a26b", @"/Views/_ViewImports.cshtml")]
    public class Views_StateManagement_ViewBagSample : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Aktueller Kurs\ASPNETCore_Grundlagen20210426\ASPNETCore_Grundlagen_20210426\StateManangementSample\Views\StateManagement\ViewBagSample.cshtml"
  
    ViewData["Title"] = "ViewBagSample";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>ViewBagSample</h1>\r\n\r\n");
#nullable restore
#line 8 "C:\Aktueller Kurs\ASPNETCore_Grundlagen20210426\ASPNETCore_Grundlagen_20210426\StateManangementSample\Views\StateManagement\ViewBagSample.cshtml"
Write(ViewBag.Wetter);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 10 "C:\Aktueller Kurs\ASPNETCore_Grundlagen20210426\ASPNETCore_Grundlagen_20210426\StateManangementSample\Views\StateManagement\ViewBagSample.cshtml"
Write(ViewBag.CBA);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
