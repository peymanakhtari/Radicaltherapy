#pragma checksum "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Home\ActiveNotification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "764fcb06bdae13c1952dc5583e339d6a276f603d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ActiveNotification), @"mvc.1.0.view", @"/Views/Home/ActiveNotification.cshtml")]
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
#line 1 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\_ViewImports.cshtml"
using RadicalTherapy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\_ViewImports.cshtml"
using RadicalTherapy.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"764fcb06bdae13c1952dc5583e339d6a276f603d", @"/Views/Home/ActiveNotification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff49281639dda514ac4512511195c403d412d181", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ActiveNotification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/teach-noti1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/teach-noti2.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/teach-noti3.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "G:\radicaltherapy\radicaltherapy-v2-23\RadicalTherapy\Views\Home\ActiveNotification.cshtml"
  
    ViewData["Title"] = "ActiveNotification";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<br />
<br />
<br />
<br />
<br />
<input type=""button"" onclick=""requestNotification()"" style=""margin:auto;display:block;width:40%;height:60px;background-color:#61fffa;font-family:'Iranian Sans';font-weight:bold"" value=""فعالسازی نتیفیکیشن"" />

<div class=""teach-active-notification"">
    <p dir=""rtl"" style=""text-align:center;font-size:22px""> ابتدا سه مرحله زیر را انجام دهید سپس روی <span style=""font-weight:bold;color:#1ac4bf"">دکمه بالا</span> بزنید </p>
    <p dir=""rtl""> 1- روی علامت قفل کنار وبسایت را لمس کنید </p>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "764fcb06bdae13c1952dc5583e339d6a276f603d5441", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <p dir=\"rtl\">2-سپس <span>permissions</span> یا مجوز ها را انتخاب کنید. </p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "764fcb06bdae13c1952dc5583e339d6a276f603d6643", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <p dir=\"rtl\"> 3-سپس دکمه <span>reset</span> یا ریست را بزنید   </p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "764fcb06bdae13c1952dc5583e339d6a276f603d7754", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<br />
<br />
<br />
<br />

<script>
    function requestNotification() {

        Notification.requestPermission(function (status) {

            if (status == ""granted"") {
                IsNotificatinAllow();
            } 
        });
    }

    function IsNotificatinAllow() {
        navigator.serviceWorker.register(""/ServiceWorker.js"")
            .then((reg) => {
                reg.pushManager.getSubscription().then(function (sub) {
                    if (sub === null) {
                        reg.pushManager.subscribe({
                            userVisibleOnly: true,
                            /**/
                            applicationServerKey: ""BI3xMbriuQ8IReKLWBZOADVA0-4hSWjDUnc0q3amFNhrJc06S4uBavwoRkEWzcagqr6YyBvOZAbv8hNvxGNUO_Y""
                            /**/
                        }).then(function (sub) {
                            var auth = arrayBufferToBase64(sub.getKey(""auth""));
                            var p256dh = arrayBufferToBase64(s");
            WriteLiteral(@"ub.getKey(""p256dh""));
                            var endpoint = sub.endpoint
                            localStorage.setItem('auth000', auth);
                            localStorage.setItem('p256dh000', p256dh);
                            localStorage.setItem('endpoint000', endpoint);

                        }).catch(function (e) {
                            console.error(""Unable to subscribe to push"", e);
                        });
                    } else {
                        var auth = arrayBufferToBase64(sub.getKey(""auth""));
                        var p256dh = arrayBufferToBase64(sub.getKey(""p256dh""));
                        var endpoint = sub.endpoint
                        localStorage.setItem('auth000', auth);
                        localStorage.setItem('p256dh000', p256dh);
                        localStorage.setItem('endpoint000', endpoint);
                    }
                });
            })
    }
    function arrayBufferToBase64(buffer) {
        var bi");
            WriteLiteral("nary = \'\';\r\n        var bytes = new Uint8Array(buffer);\r\n        var len = bytes.byteLength;\r\n        for (var i = 0; i < len; i++) {\r\n            binary += String.fromCharCode(bytes[i]);\r\n        }\r\n        return window.btoa(binary);\r\n    }\r\n</script>");
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
