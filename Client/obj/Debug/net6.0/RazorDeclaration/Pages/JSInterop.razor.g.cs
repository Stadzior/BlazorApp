// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "c:\Users\stadryniakk\Desktop\Blazor\KarieraIT\BlazorApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Users\stadryniakk\Desktop\Blazor\KarieraIT\BlazorApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "c:\Users\stadryniakk\Desktop\Blazor\KarieraIT\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "c:\Users\stadryniakk\Desktop\Blazor\KarieraIT\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "c:\Users\stadryniakk\Desktop\Blazor\KarieraIT\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "c:\Users\stadryniakk\Desktop\Blazor\KarieraIT\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "c:\Users\stadryniakk\Desktop\Blazor\KarieraIT\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "c:\Users\stadryniakk\Desktop\Blazor\KarieraIT\BlazorApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "c:\Users\stadryniakk\Desktop\Blazor\KarieraIT\BlazorApp\Client\_Imports.razor"
using BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "c:\Users\stadryniakk\Desktop\Blazor\KarieraIT\BlazorApp\Client\_Imports.razor"
using BlazorApp.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/js")]
    public partial class JSInterop : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 8 "c:\Users\stadryniakk\Desktop\Blazor\KarieraIT\BlazorApp\Client\Pages\JSInterop.razor"
     
    public async Task SayHello()
    {
        await JSRuntime.InvokeVoidAsync("Hello");
        //await JSRuntime.InvokeVoidAsync("alert('Hello from the other side!')");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
