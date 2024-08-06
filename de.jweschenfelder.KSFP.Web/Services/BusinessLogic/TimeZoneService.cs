using Microsoft.JSInterop;

namespace de.jweschenfelder.KSFP.Web.Services.BusinessLogic
{
	public class TimeZoneService
	{
		private readonly IJSRuntime _jsRuntime;

		public TimeZoneService(IJSRuntime jsRuntime)
		{
			_jsRuntime = jsRuntime;
		}

		public async ValueTask<string> GetLocalDateTime()
		{
			string localTime = await _jsRuntime.InvokeAsync<string>("GetDateTime");
			return localTime;
		}
	}
}
