#pragma checksum "C:\Users\Alekhandr0\Desktop\dot-net-core\PracticalApps\ApiMvcAuth4\ApiMvcAuth4\Views\Shared\_ExternalAuthentication.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ec6349a875af2533b4fc398f1008ef7e9b1e9f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ExternalAuthentication), @"mvc.1.0.view", @"/Views/Shared/_ExternalAuthentication.cshtml")]
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
#line 1 "C:\Users\Alekhandr0\Desktop\dot-net-core\PracticalApps\ApiMvcAuth4\ApiMvcAuth4\Views\_ViewImports.cshtml"
using ApiMvcAuth4;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Alekhandr0\Desktop\dot-net-core\PracticalApps\ApiMvcAuth4\ApiMvcAuth4\Views\Shared\_ExternalAuthentication.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alekhandr0\Desktop\dot-net-core\PracticalApps\ApiMvcAuth4\ApiMvcAuth4\Views\Shared\_ExternalAuthentication.cshtml"
using ApiMvcAuth4.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ec6349a875af2533b4fc398f1008ef7e9b1e9f8", @"/Views/Shared/_ExternalAuthentication.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b697e1d6ee19995474388a763a246cb48ae284bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ExternalAuthentication : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExternalLogin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(" \r\n");
            WriteLiteral(" \r\n<div class=\"col-md-4 offset-2\">\r\n    <section>\r\n        <h4>Use different service for log in:</h4>\r\n        <hr />\r\n");
#nullable restore
#line 10 "C:\Users\Alekhandr0\Desktop\dot-net-core\PracticalApps\ApiMvcAuth4\ApiMvcAuth4\Views\Shared\_ExternalAuthentication.cshtml"
          
            var providers = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (!providers.Any())
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div>\r\n                    <p>\r\n                        We couldn\'t find any external provider\r\n                    </p>\r\n                </div>\r\n");
#nullable restore
#line 19 "C:\Users\Alekhandr0\Desktop\dot-net-core\PracticalApps\ApiMvcAuth4\ApiMvcAuth4\Views\Shared\_ExternalAuthentication.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ec6349a875af2533b4fc398f1008ef7e9b1e9f85638", async() => {
                WriteLiteral("\r\n                    <div>\r\n                        <p>\r\n");
#nullable restore
#line 25 "C:\Users\Alekhandr0\Desktop\dot-net-core\PracticalApps\ApiMvcAuth4\ApiMvcAuth4\Views\Shared\_ExternalAuthentication.cshtml"
                             foreach (var provider in providers)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <input type=\"submit\" class=\"btn btn-info\"");
                BeginWriteAttribute("value", " value=\"", 963, "\"", 985, 1);
#nullable restore
#line 27 "C:\Users\Alekhandr0\Desktop\dot-net-core\PracticalApps\ApiMvcAuth4\ApiMvcAuth4\Views\Shared\_ExternalAuthentication.cshtml"
WriteAttributeValue("", 971, provider.Name, 971, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"provider\" />\r\n");
#nullable restore
#line 28 "C:\Users\Alekhandr0\Desktop\dot-net-core\PracticalApps\ApiMvcAuth4\ApiMvcAuth4\Views\Shared\_ExternalAuthentication.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </p>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-returnurl", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\Users\Alekhandr0\Desktop\dot-net-core\PracticalApps\ApiMvcAuth4\ApiMvcAuth4\Views\Shared\_ExternalAuthentication.cshtml"
                                                          WriteLiteral(ViewData["ReturnUrl"]);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnurl"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnurl", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnurl"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 32 "C:\Users\Alekhandr0\Desktop\dot-net-core\PracticalApps\ApiMvcAuth4\ApiMvcAuth4\Views\Shared\_ExternalAuthentication.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </section>\r\n</div>");
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