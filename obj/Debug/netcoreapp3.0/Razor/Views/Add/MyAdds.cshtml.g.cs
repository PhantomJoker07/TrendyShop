#pragma checksum "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0993782c93b5314cb28b49f3b7e19d6ae17c52e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Add_MyAdds), @"mvc.1.0.view", @"/Views/Add/MyAdds.cshtml")]
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
#nullable restore
#line 1 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
using TrendyShop.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0993782c93b5314cb28b49f3b7e19d6ae17c52e7", @"/Views/Add/MyAdds.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae704499564c51386f8cbc7db1f8d99c6833b460", @"/Views/_ViewImports.cshtml")]
    public class Views_Add_MyAdds : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AddsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PriceFilter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AllFilter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-myAdds", "True", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid rounded"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("200"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("300"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0993782c93b5314cb28b49f3b7e19d6ae17c52e76446", async() => {
                WriteLiteral("\r\n\r\n    <!-- Page Content -->\r\n    <div class=\"container\">\r\n        <!-- Page Heading/Breadcrumbs -->\r\n        <h1 class=\"col-lg-4 mt-4 mb-3\">Mis Artículos</h1>\r\n\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0993782c93b5314cb28b49f3b7e19d6ae17c52e76890", async() => {
                    WriteLiteral(@"
            <div class=""d-flex"">
                <div class=""ml-auto"">
                    <div class=""d-flex"">
                        <input type=""search"" class=""form-control"" id=""search"" name=""search"">
                        <input type=""hidden"" id=""myAdds"" name=""myAdds"" value=""True"">
                        <button type=""submit"" class=""btn btn-dark ml-1"">Buscar</button>
                    </div>
                </div>
            </div>
        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    </div>

    <ol class=""breadcrumb"">
        <li class=""breadcrumb-item"">
            <a href=""/Home/Index"">Inicio</a>
        </li>
        <li class=""breadcrumb-item active"">Artículos</li>
    </ol>

    <!-- Content Row -->
    <div class=""row"">
        <!-- Sidebar Column -->
        <div class=""col-lg-3 mb-4"">
            <div class=""card"">
                <div class=""card-body"">
                    <ul class=""navbar-nav flex-column"">
                        <li class=""card-title border-bottom h2"">
                            Filtrar por...
                        </li>
                        <li class=""nav-item"">
                            <a href=""#"" class=""nav-link"" data-toggle=""collapse"" aria-expanded=""false"" data-target=""#submenu-0"" aria-controls=""submenu-0""><i class=""fas fa-dollar-sign""></i> Precio</a>
                            <div id=""submenu-0"" class=""collapse submenu""");
                BeginWriteAttribute("style", " style=\"", 1714, "\"", 1722, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0993782c93b5314cb28b49f3b7e19d6ae17c52e710247", async() => {
                    WriteLiteral(@"
                                    <ul class=""nav flex-column"">
                                        <li class=""nav-item mb-1 ml-4"">
                                            <div class=""list-group-item"">
                                                <div class=""d-flex flex-column"">
                                                    <label for=""minp"">Min</label>
                                                    <input type=""number"" name=""minp"" id=""minp"" />

                                                    <label for=""maxp"">Max</label>
                                                    <input type=""number"" name=""maxp"" id=""maxp"" />

                                                    <input type=""hidden"" id=""myAdds"" name=""myAdds"" value=""True"">
                                                </div>
                                                <div class=""d-flex"">
                                                    <button type=""submit"" class=""btn btn-dark mt-3 ml-auto"">Filtrar</b");
                    WriteLiteral("utton>\r\n                                                </div>\r\n                                            </div>\r\n                                        </li>\r\n                                    </ul>\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </div>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link active"" href=""#"" data-toggle=""collapse"" aria-expanded=""false"" data-target=""#submenu-1"" aria-controls=""submenu-1""><i class=""fas fa-chart-bar""></i> Categoría <span class=""badge badge-success""></span></a>
                            <div id=""submenu-1"" class=""collapse submenu""");
                BeginWriteAttribute("style", " style=\"", 3517, "\"", 3525, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <ul class=\"nav flex-column\">\r\n");
#nullable restore
#line 73 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
                                     foreach (Category cat in Model.Categories)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <li class=\"nav-item mb-1 ml-4\">\r\n                                            ");
#nullable restore
#line 76 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
                                       Write(Html.ActionLink(cat.Name, "CategoryFilter", "Add", new { categoryId = cat.CategoryId, myAdds = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        </li>\r\n");
#nullable restore
#line 78 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </ul>
                            </div>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" href=""#"" data-toggle=""collapse"" aria-expanded=""false"" data-target=""#submenu-1-1"" aria-controls=""submenu-1-1""><i class=""fas fa-gift""></i> Condición</a>
                            <div id=""submenu-1-1"" class=""collapse submenu""");
                BeginWriteAttribute("style", " style=\"", 4446, "\"", 4454, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <ul class=\"nav flex-column\">\r\n                                    <li class=\"nav-item mb-1 ml-4\">\r\n                                        ");
#nullable restore
#line 87 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
                                   Write(Html.ActionLink("Nuevo", "ConditionFilter", "Add", new { isNew = true, myAdds = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </li>\r\n                                    <li class=\"nav-item mb-1 ml-4\">\r\n                                        ");
#nullable restore
#line 90 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
                                   Write(Html.ActionLink("De Uso", "ConditionFilter", "Add", new { isNew = false, myAdds = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </li>\r\n                                </ul>\r\n                            </div>\r\n                        </li>\r\n                        <li class=\"nav-item\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0993782c93b5314cb28b49f3b7e19d6ae17c52e716904", async() => {
                    WriteLiteral("<i class=\"fas fa-globe\"></i> Ver todos");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-myAdds", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["myAdds"] = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
                WriteLiteral("                        </li>\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"col-lg-9 mb-4\">\r\n            <h2>Lista de Artículos</h2>\r\n\r\n");
#nullable restore
#line 107 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
             foreach (Add a in Model.Adds)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"col-lg-12 mb-4\">\r\n                    <div class=\"card h-100\">\r\n                        <div class=\"card-body\" ");
                WriteLiteral(">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0993782c93b5314cb28b49f3b7e19d6ae17c52e719641", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 5911, "~/images/", 5911, 9, true);
#nullable restore
#line 112 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
AddHtmlAttributeValue("", 5920, a.Article.Image, 5920, 16, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            <h4 class=\"card-title border-bottom\">");
#nullable restore
#line 113 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
                                                            Write(a.Article.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n\r\n                            <div class=\"d-flex\">\r\n                                <h5> <i class=\"fas fa-money-bill-alt\"></i> Precio: ");
#nullable restore
#line 116 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
                                                                              Write(a.Article.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("$</h5>\r\n                                <h5 class=\"ml-2\"><i class=\"fas fa-certificate\"></i> Marca: ");
#nullable restore
#line 117 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
                                                                                      Write(a.Article.Brand);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                            </div>\r\n                            <p class=\"card-text\">");
#nullable restore
#line 119 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
                                            Write(a.Article.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n\r\n                            <div class=\"d-flex\">\r\n                                ");
#nullable restore
#line 122 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
                           Write(Html.ActionLink("Ver Anuncio...", "Details", "Add", new { id = a.ArticleId }, new { @class = "ml-2 mt-2" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
#nullable restore
#line 123 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
                           Write(Html.ActionLink("Editar", "Edit", "Add", new { aid = a.Article.ArticleId, uid = a.User.Id }, new { @class = "ml-2 mt-2" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
#nullable restore
#line 124 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
                           Write(Html.ActionLink("Eliminar", "Delete", "Add", new { aid = a.Article.ArticleId, uid = a.User.Id }, new { @class = "ml-2 mt-2" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 129 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Add\MyAdds.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n");
                WriteLiteral("    </div>\r\n\r\n    <!-- /.container -->\r\n    <!-- Bootstrap core JavaScript -->\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AddsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
