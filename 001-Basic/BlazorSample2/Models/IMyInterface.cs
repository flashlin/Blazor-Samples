using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSample2.Models
{
	public interface IMyInterface
	{
		string GetHello();
	}

	public class MyService : IMyInterface
	{
		public string GetHello()
		{
			return "Hello, Flash";
		}
	}
}
