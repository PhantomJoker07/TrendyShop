#pragma checksum "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c29eb631735bd1401a8252c868f48e6687973ff3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 4 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c29eb631735bd1401a8252c868f48e6687973ff3", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae704499564c51386f8cbc7db1f8d99c6833b460", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AccountDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c29eb631735bd1401a8252c868f48e6687973ff35969", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>");
#nullable restore
#line 10 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - TrendyShop</title>\r\n\r\n    <!-- Bootstrap core CSS -->\r\n    <link href=\"/vendor/bootstrap/css/bootstrap.min.css\" rel=\"stylesheet\">\r\n\r\n    <!-- Custom styles for this template -->\r\n    <link href=\"/css/modern-business.css\" rel=\"stylesheet\">\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c29eb631735bd1401a8252c868f48e6687973ff37561", async() => {
                WriteLiteral(@"

    <!-- Navigation -->
    <nav class=""navbar fixed-top navbar-expand-lg navbar-dark bg-dark fixed-top"">
        <div class=""container"">
            <a class=""navbar-brand"" href=""/"">Inicio</a>
            <button class=""navbar-toggler navbar-toggler-right"" type=""button"" data-toggle=""collapse"" data-target=""#navbarResponsive"" aria-controls=""navbarResponsive"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                <span class=""navbar-toggler-icon""></span>
            </button>
            <div class=""collapse navbar-collapse"" id=""navbarResponsive"">
                <ul class=""navbar-nav ml-auto"">

");
#nullable restore
#line 30 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                     if (SignInManager.IsSignedIn(User))
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <li class=""nav-item dropdown"">
                            <a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdownPortfolio"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                Anuncios
                            </a>
                            <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""navbarDropdownPortfolio"">
                                <a class=""dropdown-item"" href=""/Add/NewAdd"">Nuevo Anuncio</a>
                                <a class=""dropdown-item"" href=""/Add"">Anuncios</a>
                            </div>
                        </li>
");
#nullable restore
#line 41 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"nav-item\">\r\n                            <a class=\"nav-link\" href=\"/Add\">Anuncios</a>\r\n                        </li>\r\n");
#nullable restore
#line 47 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 49 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                     if (SignInManager.IsSignedIn(User))
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"nav-item\">\r\n                            <a class=\"nav-link\" href=\"/ShoppingCart\">Carrito de Compra</a>\r\n                        </li>\r\n");
#nullable restore
#line 54 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 56 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                     if (SignInManager.IsSignedIn(User))
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <li class=""nav-item dropdown"">
                            <a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdownPortfolio"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                Subasta
                            </a>
                            <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""navbarDropdownPortfolio"">
                                <a class=""dropdown-item"" href=""/Auction/NewAuction"">Nueva Subasta</a>
                                <a class=""dropdown-item"" href=""/Auction"">Subastas</a>
                            </div>
                        </li>
");
#nullable restore
#line 67 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                    }

                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"nav-item\">\r\n                            <a class=\"nav-link\" href=\"/Auction\">Subastas</a>\r\n                        </li>\r\n");
#nullable restore
#line 74 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                    <li class=""nav-item"">
                        <a class=""nav-link"" href=""/Home/About"">Acerca de</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" href=""/Home/Contact"">Contáctanos</a>
                    </li>

                    <li class=""nav-item dropdown"">
");
#nullable restore
#line 84 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                         if (SignInManager.IsSignedIn(User))
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"nav-item dropdown\">\r\n                            <a class=\"btn btn-dark\" href=\"#\" id=\"navbarDropdownBlog\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">");
#nullable restore
#line 87 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                                                                                                                                                  Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("<i class=\"fas fa-sort-down\"></i></a>\r\n                            <div class=\"dropdown-menu dropdown-menu-right\" aria-labelledby=\"navbarDropdownBlog\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c29eb631735bd1401a8252c868f48e6687973ff313894", async() => {
                    WriteLiteral("Perfil");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-userName", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 89 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                                                                                                                   WriteLiteral(User.Identity.Name);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userName"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-userName", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userName"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c29eb631735bd1401a8252c868f48e6687973ff316587", async() => {
                    WriteLiteral("\r\n                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c29eb631735bd1401a8252c868f48e6687973ff316890", async() => {
                        WriteLiteral("Salir");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </div>\r\n                        </li>\r\n");
#nullable restore
#line 95 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdownPortfolio"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                            Usuario
                        </a>
                        <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""navbarDropdownPortfolio"">
                            <a class=""dropdown-item"" href=""/User/Login"">Entrar</a>
                            <a class=""dropdown-item"" href=""/User/Register"">Registrar</a>
                        </div>
");
#nullable restore
#line 105 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </nav>\r\n\r\n\r\n        <div class=\"container\">\r\n            <main role=\"main\" class=\"pb-3\">\r\n                ");
#nullable restore
#line 115 "E:\Cibernetics Core\3er Año\+IS+\TrendyShop\TrendyShop\Views\Shared\_Layout.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </main>
        </div>

        <!-- /.container -->
        <!-- Footer -->
        <footer class=""py-5 bg-dark"">
            <div class=""container"">
                <p class=""m-0 text-center text-white"">Copyright &copy; Trendy Shop 2019-2020</p>
            </div>
            <!-- /.container -->
        </footer>

        <!-- Bootstrap core JavaScript -->
        <script src=""/vendor/jquery/jquery.min.js""></script>
        <script src=""/vendor/bootstrap/js/bootstrap.bundle.min.js""></script>

    ");
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
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<User> SignInManager { get; private set; }
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
