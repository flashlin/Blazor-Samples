using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace CodeBehindSample.Pages
{
	public partial class Counter : ComponentBase
	{
		private int currentCount = 0;

		private void IncrementCount()
		{
			currentCount++;
		}

	}
}
