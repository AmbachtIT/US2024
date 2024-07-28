using Ambacht.Common;
using Ambacht.Common.Blazor;
using Ambacht.Common.Maps;
using MudBlazor.Services;

namespace D66.US2024.App
{
	public static class DI
	{

		public static void AddUS2024App(this IServiceCollection services, string baseAddress)
		{
			services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
			services.AddAmbachtCommon();
			services.AddAmbachtCommonMaps();
			services.AddAmbachtCommonBlazor(baseAddress);
			services.AddMudServices();
		}

	}
}
