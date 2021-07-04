using System.Collections.Generic;
using System.Data;
using LargeTableSample.Components;

namespace LargeTableSample.Models
{
	public class LargeDataTable
	{
		private readonly DataTable _table;

		public LargeDataTable(DataTable table)
		{
			_table = table;
		}

		public List<LargeDataRow> Rows { get; set; } = new List<LargeDataRow>();

		public List<string> GetColumnNames()
		{
			var columnNames = new List<string>();
			if (_table == null)
			{
				return columnNames;
			}
			foreach (DataColumn column in _table.Columns)
			{
				columnNames.Add(column.ColumnName);
			}
			return columnNames;
		}

		public List<LargeDataRow> GetRows(int startIndex, int count)
		{
			var result = new List<LargeDataRow>();
			var loaded = 0;
			for (var idx = startIndex; idx < Rows.Count; idx++)
			{
				result.Add(Rows[idx]);
				loaded++;
				if (loaded >= count)
				{
					break;
				}
			}
			return result;
		}
	}
}