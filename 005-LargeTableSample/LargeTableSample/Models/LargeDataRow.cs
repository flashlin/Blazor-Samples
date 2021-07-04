using System.Collections.Generic;
using System.Data;

namespace LargeTableSample.Models
{
	public class LargeDataRow
	{
		private readonly DataRow _row;
		private readonly LargeDataTable _largeDataTable;

		public LargeDataRow(LargeDataTable largeDataTable, DataRow row)
		{
			_largeDataTable = largeDataTable;
			_row = row;
		}

		public List<string> GetColumnValues()
		{
			var result = new List<string>();
			foreach (var columnName in _largeDataTable.GetColumnNames())
			{
				result.Add($"{_row[columnName]}");
			}

			return result;
		}
	}
}