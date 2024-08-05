using de.jweschenfelder.KSFP.Web.Extensions;
using de.jweschenfelder.KSFP.Web.Providers;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;

namespace de.jweschenfelder.KSFP.Web.Pages.Components
{
    public class LocalTime : ComponentBase, IDisposable
    {
        [Inject]
        public TimeProvider TimeProvider { get; set; } = default!;

        [Parameter]
        public DateTime? DateTime { get; set; }

        protected override void OnInitialized()
        {
            if (TimeProvider is BrowserTimeProvider browserTimeProvider)
            {
                browserTimeProvider.LocalTimeZoneChanged += LocalTimeZoneChanged;
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (DateTime != null)
            {
                builder.AddContent(0, TimeProvider.ToLocalDateTime(DateTime.Value));
            }
        }

        public void Dispose()
        {
            if (TimeProvider is BrowserTimeProvider browserTimeProvider)
            {
                browserTimeProvider.LocalTimeZoneChanged -= LocalTimeZoneChanged;
            }
        }

        private void LocalTimeZoneChanged(object? sender, EventArgs e)
        {
            _ = InvokeAsync(StateHasChanged);
        }
    }
}
