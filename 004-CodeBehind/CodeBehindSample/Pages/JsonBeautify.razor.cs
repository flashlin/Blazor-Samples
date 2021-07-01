using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace CodeBehindSample.Pages
{
	public partial class JsonBeautify : ComponentBase
	{
		private string _jsonData;
		private string _formattedJsonData;

		private void ConvertJsonDataToFormattedJsonData()
		{
			var obj = JsonDocument.Parse(_jsonData);
			using (var stream = new MemoryStream())
			{
				var writer = new Utf8JsonWriter(stream, new JsonWriterOptions()
				{
					Indented = true
				});
				obj.WriteTo(writer);
				writer.Flush();
				_formattedJsonData = Encoding.UTF8.GetString(stream.ToArray());
			}
		}
	}
}
