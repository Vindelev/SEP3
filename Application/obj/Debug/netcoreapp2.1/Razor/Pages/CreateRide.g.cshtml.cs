#pragma checksum "E:\Coding projects\Visual Studio projects\ProofOfConcept\Application\Pages\CreateRide.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b43dab7605ecc519fff2095b94ae6fb02b26ee08"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Application.Pages.Pages_CreateRide), @"mvc.1.0.razor-page", @"/Pages/CreateRide.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/CreateRide.cshtml", typeof(Application.Pages.Pages_CreateRide), null)]
namespace Application.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\Coding projects\Visual Studio projects\ProofOfConcept\Application\Pages\_ViewImports.cshtml"
using Application;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b43dab7605ecc519fff2095b94ae6fb02b26ee08", @"/Pages/CreateRide.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c90dca39a37f6f45ea220907f468a30a4a34bc9f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_CreateRide : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "CreateRide", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(31, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "E:\Coding projects\Visual Studio projects\ProofOfConcept\Application\Pages\CreateRide.cshtml"
      if(!(User.Identity.IsAuthenticated)){
		Response.Redirect("Index");
	}

#line default
#line hidden
            BeginContext(114, 900, true);
            WriteLiteral(@"
    <nav class=""navbar navbar-default navbar-inverse"" role=""navigation"">
        <div class=""container-fluid"">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class=""navbar-header"">
                <button type=""button"" class=""navbar-toggle collapsed"" data-toggle=""collapse"" data-target=""#bs-example-navbar-collapse-1"">
                <span class=""sr-only"">Toggle navigation</span>
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
                <span class=""icon-bar""></span>
            </button>
            <a class=""navbar-brand"" href=""Index"">WeRide</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class=""collapse navbar-collapse"" id=""bs-example-navbar-collapse-1"">
                <ul class=""nav navbar-nav"">
");
            EndContext();
#line 24 "E:\Coding projects\Visual Studio projects\ProofOfConcept\Application\Pages\CreateRide.cshtml"
                     if(User.Identity.IsAuthenticated){

#line default
#line hidden
            BeginContext(1071, 88, true);
            WriteLiteral("                        <li class=\"active\"><a href=\"CreateRide\">Create a ride</a></li>\r\n");
            EndContext();
#line 26 "E:\Coding projects\Visual Studio projects\ProofOfConcept\Application\Pages\CreateRide.cshtml"
                    }

#line default
#line hidden
            BeginContext(1182, 133, true);
            WriteLiteral("                    <li><a href=\"#\">About</a></li>\r\n                </ul>\r\n                <ul class=\"nav navbar-nav navbar-right\">\r\n");
            EndContext();
#line 30 "E:\Coding projects\Visual Studio projects\ProofOfConcept\Application\Pages\CreateRide.cshtml"
                 if(!(@User.Identity.IsAuthenticated)){

#line default
#line hidden
            BeginContext(1372, 362, true);
            WriteLiteral(@"                        <li class=""dropdown"">
                            <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown""><b>Login</b> <span class=""caret""></span></a>
			                <ul id=""login-dp"" class=""dropdown-menu"">
				                <li>
                                    <div class=""row"">
                                        ");
            EndContext();
            BeginContext(1734, 877, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd165298abfb453ca14b8968aae1205a", async() => {
                BeginContext(1779, 825, true);
                WriteLiteral(@"

                                            <div class=""form-group"">
                                                <input type=""text"" name=""Email"" class=""form-control appButtons"" placeholder=""Email"">
                                            </div>

                                            <div class=""form-group"">
                                                <input type=""password"" name=""Password"" class=""form-control appButtons"" placeholder=""Password"">
                                            </div>

                                            <div class=""form-group"">
                                                <button type=""submit"" class=""btn btn-success btn-block appButtons"">Login</button>
                                            </div>

                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2611, 408, true);
            WriteLiteral(@"

                                        <div class=""form-group"">
                                            <button type=""submit"" class=""btn btn-primary btn-block appButtons"" action=""Register.cshtml"">Register</button>
                                        </div>
                                    </div>     
				                </li>
			                </ul>
                        </li>  
");
            EndContext();
#line 59 "E:\Coding projects\Visual Studio projects\ProofOfConcept\Application\Pages\CreateRide.cshtml"
                }
                else{

#line default
#line hidden
            BeginContext(3061, 133, true);
            WriteLiteral("                    <li class=\"dropdown\">\r\n                            <a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\"><b>");
            EndContext();
            BeginContext(3195, 18, false);
#line 62 "E:\Coding projects\Visual Studio projects\ProofOfConcept\Application\Pages\CreateRide.cshtml"
                                                                                     Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(3213, 533, true);
            WriteLiteral(@"</b> <span class=""caret""></span></a>
			                <ul id=""login-dp"" class=""dropdown-menu"">
				                <li>
                                    <div class=""row"">
                                         <div class=""form-group"">
                                            <button type=""submit"" class=""btn btn-info btn-block appButtons"">Account</button>
                                        </div>

                                        <div class=""form-group"">
                                            ");
            EndContext();
            BeginContext(3746, 230, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1dea5907b2504150aa2dd20fd1efea82", async() => {
                BeginContext(3792, 177, true);
                WriteLiteral("\r\n                                                <button type=\"submit\" class=\"btn btn-danger btn-block appButtons\">Logout</button>\r\n                                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3976, 182, true);
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n\t\t\t\t                </li>\r\n\t\t\t                </ul>\r\n                        </li>    \r\n");
            EndContext();
#line 79 "E:\Coding projects\Visual Studio projects\ProofOfConcept\Application\Pages\CreateRide.cshtml"
                }

#line default
#line hidden
            BeginContext(4177, 241, true);
            WriteLiteral("                </ul>\r\n            </div><!-- /.navbar-collapse -->\r\n        </div><!-- /.container-fluid -->\r\n    </nav>\r\n\r\n\r\n   <div class=\"container\">\r\n\r\n        <div class=\"form-sec\">\r\n            <h4>Create a ride</h4>\r\n  \r\n            ");
            EndContext();
            BeginContext(4418, 2290, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f990e8117d444aeb9bd03ce7169302e", async() => {
                BeginContext(4468, 2233, true);
                WriteLiteral(@"

                <div class=""form-group"">
                    <label>Available seats:</label>
                    <input class=""form-control""  placeholder=""Available seats"" name=""seats""/>
                </div>
                <div class=""form-group"">
                    <label>From:</label>
                    <input class=""form-control""  placeholder=""Starting point"" name=""start""/>
                </div>
    
                <div class=""form-group"">
                    <label>To:</label>
                    <input class=""form-control""  placeholder=""Destination city"" name=""destC""/>
                </div>
	            <div class=""form-group"">
                    <label>Destination address: </label>
                    <input class=""form-control""  placeholder=""Destination address"" name=""destA""/>
                </div>
 
                <div class=""form-group"">
                    <div class=""col-xs-5 date"">
                        <div class=""input-group input-append date"" id=""datePicker""");
                WriteLiteral(@">
                            <input type=""text"" class=""form-control"" name=""date"" placeholder=""9/11/2001""/>
                            <span class=""input-group-addon add-on""><span class=""glyphicon glyphicon-calendar""></span></span>
                        </div>
                    </div>
                </div>

                <div class=""form-group"">
                    <table>
                        <tr>
                            <td><label>Starting time:</label></td>
                            <td><input class=""form-control""  placeholder=""23"" name=""hour"" size=""1""/></td>
                            <td><p>:</p></td>
                            <td><input class=""form-control""  placeholder=""59"" name=""min"" size=""1""/></td>
                        </tr>
                    </table>
                </div>

	            
                <div class=""form-group"">
                    <label>Comment: </label>
                    <textarea name=""comment"" class=""form-control"" placeholder=""Do y");
                WriteLiteral("ou want to say something about the ride?\"></textarea>\r\n                </div>\r\n\r\n\r\n    \r\n                <button type=\"submit\" class=\"btn btn-default\">Create ride</button>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6708, 38, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    \r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreateRideModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CreateRideModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CreateRideModel>)PageContext?.ViewData;
        public CreateRideModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
