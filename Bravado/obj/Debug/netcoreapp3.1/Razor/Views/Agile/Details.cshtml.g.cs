#pragma checksum "/Users/grantwatson/Desktop/Dev/Bravado-Work-Board/Bravado/Views/Agile/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1cfca652947bd9e3fa31198af77fe635fcda6c77"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Agile_Details), @"mvc.1.0.view", @"/Views/Agile/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1cfca652947bd9e3fa31198af77fe635fcda6c77", @"/Views/Agile/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0552a497cc8dd0eefb05a0afca38e283da12247", @"/Views/_ViewImports.cshtml")]
    public class Views_Agile_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Bravado.ViewModel.AgileViewModels.BoardView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/grantwatson/Desktop/Dev/Bravado-Work-Board/Bravado/Views/Agile/Details.cshtml"
  
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Bravado.ViewModel.AgileViewModels.BoardView> Html { get; private set; }
    }
}
#pragma warning restore 1591
