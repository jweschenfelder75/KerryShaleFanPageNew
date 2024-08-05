using de.jweschenfelder.KSFP.Web.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace de.jweschenfelder.KSFP.Web.Pages.Components
{
    public class InitializeTimeZone : ComponentBase
    {
        [Inject] public TimeProvider TimeProvider { get; set; } = default!;
        [Inject] public IJSRuntime JSRuntime { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && TimeProvider is BrowserTimeProvider browserTimeProvider && !browserTimeProvider.IsLocalTimeZoneSet)
            {
                try
                {
                    await using var module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/timezone.js");
                    var timeZone = await module.InvokeAsync<string>("getBrowserTimeZone");
                    browserTimeProvider.SetBrowserTimeZone(timeZone);
                }
                catch (JSDisconnectedException)
                {
                }
            }
        }
    }
}
