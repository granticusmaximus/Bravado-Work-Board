#pragma checksum "/Users/grantwatson/Desktop/Dev/Bravado-Work-Board/Bravado/Views/Boards/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0ce0827c580c868d930bcc741b2782fd09ae661"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Boards_Details), @"mvc.1.0.view", @"/Views/Boards/Details.cshtml")]
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
#line 1 "/Users/grantwatson/Desktop/Dev/Bravado-Work-Board/Bravado/Views/_ViewImports.cshtml"
using Bravado;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/grantwatson/Desktop/Dev/Bravado-Work-Board/Bravado/Views/_ViewImports.cshtml"
using Bravado.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0ce0827c580c868d930bcc741b2782fd09ae661", @"/Views/Boards/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0552a497cc8dd0eefb05a0afca38e283da12247", @"/Views/_ViewImports.cshtml")]
    public class Views_Boards_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Bravado.ViewModel.BoardViewModels.BoardView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/grantwatson/Desktop/Dev/Bravado-Work-Board/Bravado/Views/Boards/Details.cshtml"
  
    ViewBag.Title = "title";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Board Details</h2>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Bravado.ViewModel.BoardViewModels.BoardView> Html { get; private set; }
    }
}
#pragma warning restore 1591
