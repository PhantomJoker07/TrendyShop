#pragma checksum "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\ShoppingCart\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b771d12f1613ef2e189a6b858d0f2210a6aaa014"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShoppingCart_Details), @"mvc.1.0.view", @"/Views/ShoppingCart/Details.cshtml")]
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
#line 1 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\_ViewImports.cshtml"
using TrendyShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\_ViewImports.cshtml"
using TrendyShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b771d12f1613ef2e189a6b858d0f2210a6aaa014", @"/Views/ShoppingCart/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae704499564c51386f8cbc7db1f8d99c6833b460", @"/Views/_ViewImports.cshtml")]
    public class Views_ShoppingCart_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TrendyShop.ViewModels.SLDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\ShoppingCart\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n<div class=\"col-lg-8 mb-4 mx-auto\">\r\n    <div class=\"card \">\r\n        <h2 class=\"card-header\">\r\n            ");
#nullable restore
#line 77 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\ShoppingCart\Details.cshtml"
       Write(Model.ShoppingListName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </h2>\r\n        <div class=\"card-body\">\r\n            <table class=\"table table-bordered\">\r\n                <tr>\r\n                    <th></th>\r\n                    <th></th>\r\n                    <th>Cantidad</th>  ");
            WriteLiteral("\r\n                    <th></th>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 88 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\ShoppingCart\Details.cshtml"
                 foreach (var art in Model.List)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 91 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\ShoppingCart\Details.cshtml"
                       Write(art.Article.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 92 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\ShoppingCart\Details.cshtml"
                       Write(art.Article.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 93 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\ShoppingCart\Details.cshtml"
                       Write(art.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("\r\n                    </tr>\r\n");
#nullable restore
#line 97 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\ShoppingCart\Details.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n        </div>\r\n        <div class=\"card-footer\">\r\n            ");
#nullable restore
#line 102 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\ShoppingCart\Details.cshtml"
       Write(Html.ActionLink("Cargar Lista", "LoadShoppingList", "ShoppingCart", new { sid = Model.ShoppingListId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TrendyShop.ViewModels.SLDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591