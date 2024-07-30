using Newtonsoft.Json.Converters;
using System;
using System.Text.Json.Serialization;

namespace de.jweschenfelder.KSFP.Shared.Enums
{
	[Serializable, JsonConverter(typeof(StringEnumConverter))]
	public enum NewsCategoryEnum
	{
		None = 0,
		Current = 1,
		Old = 2,
		Uncomfirmed = 3
	}
}
