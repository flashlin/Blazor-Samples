using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LargeTableSample.Components
{
	public partial class LargeTable : ComponentBase
	{
		ElementReference BodyReference;

		[Inject] 
		private IJSRuntime Js { get; set; }

		private async Task HandleOnScroll(EventArgs e)
		{
			var scrollInfo = await Js.InvokeAsync<ScrollInfo>("BlazorUniversity.getScrollInfo", BodyReference);
			var scrollValue = scrollInfo.ScrollTop + scrollInfo.ClientHeight;
			Console.WriteLine($"scrollValue={scrollValue} scHeight={scrollInfo.ScrollHeight}");
		}
	}

	public class ScrollInfo
	{
		public int ScrollHeight { get; set; }
		public int ScrollTop { get; set; }
		public int ClientHeight { get; set; }
	}
}
