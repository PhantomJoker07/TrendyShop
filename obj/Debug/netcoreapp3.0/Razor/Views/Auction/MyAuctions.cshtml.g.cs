#pragma checksum "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6819b9059de51792283a5cfbc53d8a31e10cd61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auction_MyAuctions), @"mvc.1.0.view", @"/Views/Auction/MyAuctions.cshtml")]
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
#line 1 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
using TrendyShop.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6819b9059de51792283a5cfbc53d8a31e10cd61", @"/Views/Auction/MyAuctions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae704499564c51386f8cbc7db1f8d99c6833b460", @"/Views/_ViewImports.cshtml")]
    public class Views_Auction_MyAuctions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AuctionIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Auction", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PriceFilter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AllFilter", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-myAucts", "True", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6819b9059de51792283a5cfbc53d8a31e10cd616542", async() => {
                WriteLiteral("\r\n\r\n    <!-- Page Content -->\r\n    <div class=\"container\">\r\n\r\n        <!-- Page Heading/Breadcrumbs -->\r\n        <h1 class=\"col-lg-4 mt-4 mb-3\">Mis Subastas</h1>\r\n\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6819b9059de51792283a5cfbc53d8a31e10cd616989", async() => {
                    WriteLiteral(@"
            <div class=""d-flex"">
                <div class=""ml-auto"">
                    <div class=""d-flex"">
                        <input type=""search"" class=""form-control"" id=""search"" name=""search"">
                        <input type=""hidden"" id=""myAucts"" name=""myAucts"" value=""True"">
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
        <li class=""breadcrumb-item active"">Subastas</li>
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
                BeginWriteAttribute("style", " style=\"", 1782, "\"", 1790, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6819b9059de51792283a5cfbc53d8a31e10cd6110345", async() => {
                    WriteLiteral(@"
                                    <ul class=""nav flex-column"">
                                        <li class=""nav-item mb-1 ml-4"">
                                            <div class=""list-group-item"">
                                                <div class=""d-flex flex-column"">
                                                    <label for=""minp"">Min</label>
                                                    <input type=""number"" name=""minp"" id=""minp"" />

                                                    <label for=""maxp"">Max</label>
                                                    <input type=""number"" name=""maxp"" id=""maxp"" />

                                                    <input type=""hidden"" id=""myAucts"" name=""myAucts"" value=""True"">
                                                </div>
                                                <div class=""d-flex"">
                                                    <button type=""submit"" class=""btn btn-dark mt-3 ml-auto"">Filtrar<");
                    WriteLiteral("/button>\r\n                                                </div>\r\n                                            </div>\r\n                                        </li>\r\n                                    </ul>\r\n                                ");
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
                BeginWriteAttribute("style", " style=\"", 3591, "\"", 3599, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <ul class=\"nav flex-column\">\r\n");
#nullable restore
#line 75 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                     foreach (Category cat in Model.Categories)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <li class=\"nav-item mb-1 ml-4\">\r\n                                            ");
#nullable restore
#line 78 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                       Write(Html.ActionLink(cat.Name, "CategoryFilter", "Auction", new { categoryId = cat.CategoryId, myAucts = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        </li>\r\n");
#nullable restore
#line 80 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
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
                BeginWriteAttribute("style", " style=\"", 4525, "\"", 4533, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <ul class=\"nav flex-column\">\r\n                                    <li class=\"nav-item mb-1 ml-4\">\r\n                                        ");
#nullable restore
#line 89 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                   Write(Html.ActionLink("Nuevo", "ConditionFilter", "Auction", new { isNew = true, myAucts = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </li>\r\n                                    <li class=\"nav-item mb-1 ml-4\">\r\n                                        ");
#nullable restore
#line 92 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                   Write(Html.ActionLink("De Uso", "ConditionFilter", "Auction", new { isNew = false, myAucts = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" href=""#"" data-toggle=""collapse"" aria-expanded=""false"" data-target=""#submenu-1-2"" aria-controls=""submenu-1-2""><i class=""fas fa-parachute-box""></i> Estado</a>
                            <div id=""submenu-1-2"" class=""collapse submenu""");
                BeginWriteAttribute("style", " style=\"", 5528, "\"", 5536, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <ul class=\"nav flex-column\">\r\n                                    <li class=\"nav-item mb-1 ml-4\">\r\n                                        ");
#nullable restore
#line 102 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                   Write(Html.ActionLink("Cerradas", "StateFilter", "Auction", new { state = 1, myAucts = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </li>\r\n                                    <li class=\"nav-item mb-1 ml-4\">\r\n                                        ");
#nullable restore
#line 105 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                   Write(Html.ActionLink("En curso", "StateFilter", "Auction", new { state = 2, myAucts = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </li>\r\n                                    <li class=\"nav-item mb-1 ml-4\">\r\n                                        ");
#nullable restore
#line 108 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                   Write(Html.ActionLink("Pendientes", "StateFilter", "Auction", new { state = 3, myAucts = true }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </li>\r\n                                </ul>\r\n                            </div>\r\n                        </li>\r\n");
                WriteLiteral("                        <li class=\"nav-item\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6819b9059de51792283a5cfbc53d8a31e10cd6119268", async() => {
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
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-myAucts", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["myAucts"] = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </li>\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"col-lg-9 mb-4\">\r\n            <h2>Subastas</h2>\r\n\r\n");
#nullable restore
#line 127 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
             foreach (Auction a in Model.Auctions)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"card\">\r\n                    <div class=\"card-body\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c6819b9059de51792283a5cfbc53d8a31e10cd6121874", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 7157, "~/images/", 7157, 9, true);
#nullable restore
#line 131 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
AddHtmlAttributeValue("", 7166, a.Article.Image, 7166, 16, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <h4 class=\"card-title border-bottom\">");
#nullable restore
#line 132 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                                        Write(a.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n                        <div class=\"d-flex\">\r\n                            <p><i class=\"far fa-calendar-alt\"></i> ");
#nullable restore
#line 134 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                                              Write(a.Start.ToString("dd/MM/yy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                            <p class=\"ml-2\"><i class=\"far fa-clock\"></i> ");
#nullable restore
#line 135 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                                                    Write(a.Start.ToString("hh:mm tt"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                            <p class=\"ml-2\"><i class=\"fas fa-hourglass-end\"></i> ");
#nullable restore
#line 136 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                                                            Write(a.Duration);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                        </div>\r\n                        <p>Artículo: ");
#nullable restore
#line 138 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                Write(a.Article.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n\r\n                        <p class=\"card-text\">");
#nullable restore
#line 140 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                                        Write(a.Article.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                        <div class=\"d-flex\">\r\n                            <div class=\"ml-auto\">\r\n");
                WriteLiteral("                                ");
#nullable restore
#line 144 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                           Write(Html.ActionLink("Eliminar", "Delete", "Auction", new { aid = a.ArticleId }, null));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
#nullable restore
#line 145 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
                           Write(Html.ActionLink("Detalles", "Details", "Auction", new { id = a.ArticleId }, null));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 150 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Auction\MyAuctions.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <!-- /.container -->\r\n    <!-- Footer -->\r\n    <!-- Bootstrap core JavaScript -->\r\n\r\n");
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
            WriteLiteral("\r\n\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AuctionIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
