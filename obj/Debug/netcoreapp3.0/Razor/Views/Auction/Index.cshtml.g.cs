#pragma checksum "B:\Computers Science\3rd year\2do semestre\IS\Proyecto\TrendyShop\TrendyShop\Views\Auction\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "472f6a084b9f4050ee62f73357ecc24739c8af8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auction_Index), @"mvc.1.0.view", @"/Views/Auction/Index.cshtml")]
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
#line 1 "B:\Computers Science\3rd year\2do semestre\IS\Proyecto\TrendyShop\TrendyShop\Views\_ViewImports.cshtml"
using TrendyShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "B:\Computers Science\3rd year\2do semestre\IS\Proyecto\TrendyShop\TrendyShop\Views\Auction\Index.cshtml"
using TrendyShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"472f6a084b9f4050ee62f73357ecc24739c8af8a", @"/Views/Auction/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae704499564c51386f8cbc7db1f8d99c6833b460", @"/Views/_ViewImports.cshtml")]
    public class Views_Auction_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Auction>>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "472f6a084b9f4050ee62f73357ecc24739c8af8a3387", async() => {
                WriteLiteral("\r\n\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 308, "\"", 318, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n    <meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 345, "\"", 355, 0);
                EndWriteAttribute();
                WriteLiteral(@">

    <title>Compra Venta (Subastas)</title>

    <!-- Bootstrap core CSS -->
    <link href=""/vendor/bootstrap/css/bootstrap.min.css"" rel=""stylesheet"">

    <!-- Custom styles for this template -->
    <link href=""/css/modern-business.css"" rel=""stylesheet"">

");
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "472f6a084b9f4050ee62f73357ecc24739c8af8a5143", async() => {
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

                    <li class=""nav-item dropdown"">
                        <a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdownPortfolio"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                            Artículos
                        </a>
                        <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""navbarDropdownPortf");
                WriteLiteral(@"olio"">
                            <a class=""dropdown-item"" href=""/Home/NewArticle"">Anunciar</a>
                            <a class=""dropdown-item"" href=""/Home/Articles"">Lista de Artículos</a>
                        </div>
                    </li>

                    <li class=""nav-item dropdown"">
                        <a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdownPortfolio"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                            Subasta
                        </a>
                        <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""navbarDropdownPortfolio"">
                            <a class=""dropdown-item"" href=""/Home/NewAuction"">Nueva Subasta</a>
                            <a class=""dropdown-item"" href=""/Home/Auctions"">Lista de Subastas</a>
                        </div>
                    </li>

                    <li class=""nav-item"">
                        <a class=""nav-link"" href=""/Home/About"">Acer");
                WriteLiteral(@"ca de</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" href=""/Home/Contact"">Contáctanos</a>
                    </li>

                    <li class=""nav-item dropdown"">
                        <a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdownPortfolio"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                            Usuario
                        </a>
                        <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""navbarDropdownPortfolio"">
                            <a class=""dropdown-item"" href=""/Home/Login"">Entrar</a>
                            <a class=""dropdown-item"" href=""/Home/Register"">Registrar</a>
                        </div>
                    </li>

                </ul>
            </div>
        </div>
    </nav>

    <!-- Page Content -->
    <div class=""container"">

        <!-- Page Heading/Breadcrumbs -->
        <div class=""row");
                WriteLiteral(@""">
            <h1 class=""col-lg-4 mt-4 mb-3"">
                Subastas
                <small>(Filtros)</small>
            </h1>

            <div class=""col-lg-2""></div>
            <input type=""text"" class=""form-control col-lg-5 mt-4 mb-3"" id=""name"">
            <a class=""col-lg-1 btn btn-primary mt-4 mb-4 text-white"">Buscar</a>
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
                <div class=""list-group"">
                    <a");
                BeginWriteAttribute("href", " href=\"", 4500, "\"", 4507, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"list-group-item\">Próximas</a>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 4569, "\"", 4576, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"list-group-item\">En curso</a>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 4638, "\"", 4645, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"list-group-item\">Previas</a>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"col-lg-9 mb-4\">\r\n                <h2>Subastas</h2>\r\n\r\n                <div class=\"row\">\r\n");
#nullable restore
#line 117 "B:\Computers Science\3rd year\2do semestre\IS\Proyecto\TrendyShop\TrendyShop\Views\Auction\Index.cshtml"
                     foreach (Auction a in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"col-lg-12 mb-4\">\r\n                        <div class=\"card h-100\">\r\n                            <h4 class=\"card-header\">");
#nullable restore
#line 121 "B:\Computers Science\3rd year\2do semestre\IS\Proyecto\TrendyShop\TrendyShop\Views\Auction\Index.cshtml"
                                               Write(a.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n                            <div class=\"card-body\">\r\n                                <p class=\"card-text\">");
#nullable restore
#line 123 "B:\Computers Science\3rd year\2do semestre\IS\Proyecto\TrendyShop\TrendyShop\Views\Auction\Index.cshtml"
                                                Write(a.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                            </div>

                            <div class=""card-footer"">
                                <div class=""row"">
                                    <div class=""col-lg-10"">
                                        <h5>Participantes: xxx</h5>
                                    </div>
                                    <div class=""col-lg-2"">
");
                WriteLiteral("                                        ");
#nullable restore
#line 133 "B:\Computers Science\3rd year\2do semestre\IS\Proyecto\TrendyShop\TrendyShop\Views\Auction\Index.cshtml"
                                   Write(Html.ActionLink("Unirse", "Details", "Auction", new { id = a.Id }, null));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 139 "B:\Computers Science\3rd year\2do semestre\IS\Proyecto\TrendyShop\TrendyShop\Views\Auction\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </div>

            </div>
        </div>

    </div>
    <!-- /.container -->
    <!-- Footer -->
    <footer class=""py-5 bg-dark"">
        <div class=""container"">
            <p class=""m-0 text-center text-white"">Copyright &copy; Your Website 2019</p>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Auction>> Html { get; private set; }
    }
}
#pragma warning restore 1591
