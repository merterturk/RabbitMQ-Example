#pragma checksum "C:\Users\merturk\source\repos\RabbitMQExample\RabbitMQWeb.ExcelCreate\Views\Product\Files.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03929e3c86050983aae009ff7413e51027e1d08c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Files), @"mvc.1.0.view", @"/Views/Product/Files.cshtml")]
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
#line 1 "C:\Users\merturk\source\repos\RabbitMQExample\RabbitMQWeb.ExcelCreate\Views\_ViewImports.cshtml"
using RabbitMQWeb.ExcelCreate;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\merturk\source\repos\RabbitMQExample\RabbitMQWeb.ExcelCreate\Views\_ViewImports.cshtml"
using RabbitMQWeb.ExcelCreate.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03929e3c86050983aae009ff7413e51027e1d08c", @"/Views/Product/Files.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7504ab609e4a87826331d156c04c64d991740fe", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Files : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<UserFile>>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Files</h1>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(" \r\n<script>\r\n    $(document).ready(function () {\r\n        var hasStartCreatingExcel = \'");
#nullable restore
#line 6 "C:\Users\merturk\source\repos\RabbitMQExample\RabbitMQWeb.ExcelCreate\Views\Product\Files.cshtml"
                                Write(TempData["StartCreatingExcel"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';

        if (hasStartCreatingExcel) {
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Excel olu??turma i??lemi ba??lam????t??r. Bitti??inde bildiri alacaks??n??z.',
                showConfirmButton: false,
                timer:2500
            })
        }
    })
</script>
");
            }
            );
            WriteLiteral("<table class=\"table table-striped\">\r\n    <thead>\r\n        <tr>\r\n            <th>File Name</th>\r\n            <th>Created Date</th>\r\n            <th>File Status</th>\r\n            <th>Download</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 30 "C:\Users\merturk\source\repos\RabbitMQExample\RabbitMQWeb.ExcelCreate\Views\Product\Files.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 33 "C:\Users\merturk\source\repos\RabbitMQExample\RabbitMQWeb.ExcelCreate\Views\Product\Files.cshtml"
               Write(item.FileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 34 "C:\Users\merturk\source\repos\RabbitMQExample\RabbitMQWeb.ExcelCreate\Views\Product\Files.cshtml"
               Write(item.GetCreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 35 "C:\Users\merturk\source\repos\RabbitMQExample\RabbitMQWeb.ExcelCreate\Views\Product\Files.cshtml"
               Write(item.FileStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "03929e3c86050983aae009ff7413e51027e1d08c5495", async() => {
                WriteLiteral("Download");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1017, "~/files/", 1017, 8, true);
#nullable restore
#line 37 "C:\Users\merturk\source\repos\RabbitMQExample\RabbitMQWeb.ExcelCreate\Views\Product\Files.cshtml"
AddHtmlAttributeValue("", 1025, item.FilePath, 1025, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1048, "btn", 1048, 3, true);
            AddHtmlAttributeValue(" ", 1051, "btn-primary", 1052, 12, true);
#nullable restore
#line 37 "C:\Users\merturk\source\repos\RabbitMQExample\RabbitMQWeb.ExcelCreate\Views\Product\Files.cshtml"
AddHtmlAttributeValue(" ", 1063, item.FileStatus==FileStatus.Creating ? "disabled" : "", 1064, 57, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 40 "C:\Users\merturk\source\repos\RabbitMQExample\RabbitMQWeb.ExcelCreate\Views\Product\Files.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<UserFile>> Html { get; private set; }
    }
}
#pragma warning restore 1591
