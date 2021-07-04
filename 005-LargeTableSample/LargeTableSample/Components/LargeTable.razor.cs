using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LargeTableSample.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LargeTableSample.Components
{
	public partial class LargeTable : ComponentBase
	{
		ElementReference BodyReference;

		private int _pageSize = 20;
		private int _currentRowIndex = 0;
		private int _totalPage = 0;
		private int _currentPage = 0;

		private LargeDataTable _dataTable = new LargeDataTable(new DataTable());


		[Inject]
		private IJSRuntime Js { get; set; }

		protected override async Task OnInitializedAsync()
		{
			var table = new DataTable();
			table.Columns.Add(new DataColumn("Id", typeof(int)));
			table.Columns.Add(new DataColumn("Name", typeof(string)));
			table.Columns.Add(new DataColumn("Birth", typeof(DateTime)));
			table.Columns.Add(new DataColumn("Desc", typeof(string)));

			var myTable = new LargeDataTable(table);
			for (var i = 0; i < 1000; i++)
			{
				var row = table.NewRow();
				row["Id"] = i + 1;
				row["Name"] = $"Name{i}";
				row["Birth"] = new DateTime(2010, 1, 1).AddHours(i);
				row["Desc"] = "";

				var myRow = new LargeDataRow(myTable, row);
				myTable.Rows.Add(myRow);
				table.Rows.Add(row);
			}

			_dataTable = myTable;
			_totalPage = (myTable.Rows.Count + _pageSize - 1) / _pageSize;

			await base.OnInitializedAsync();
		}

		private string GetPageIndexActiveCss(int userPageIndex)
		{
			return (userPageIndex - 1) == _currentPage ? "active" : "";
		}

		private List<int> GetUserPageIndexList()
		{
			return Enumerable.Range(1, _totalPage)
				.ToList();
		}

		private string GetPreviousPageCss()
		{
			return _currentPage <= 0 ? "disabled" : "";
		}

		private void GoToPreviousPage()
		{
			if (_currentPage <= 0)
			{
				return;
			}
			GoToPage(_currentPage - 1);
		}

		private string GetNextPageCss()
		{
			return _currentPage == (_totalPage - 1) ? "disabled" : "";
		}

		private void GoToNextPage()
		{
			if (_currentPage >= _totalPage)
			{
				return;
			}
			GoToPage(_currentPage + 1);
		}

		private void GoToPage(int userPageIndex)
		{
			userPageIndex -= 1;
			if (0 <= userPageIndex && userPageIndex < _totalPage)
			{
				_currentPage = userPageIndex;
				_currentRowIndex = userPageIndex * _pageSize;
			}
		}

		private List<LargeDataRow> GetRows()
		{
			return _dataTable.GetRows(_currentRowIndex, _pageSize);
		}

		private async Task<ScrollInfo> GetScrollInfoAsync()
		{
			var scrollInfo = await Js.InvokeAsync<ScrollInfo>("BlazorUniversity.getScrollInfo", BodyReference);
			return scrollInfo;
		}
	}

	public class ScrollInfo
	{
		public int ScrollHeight { get; set; }
		public int ScrollTop { get; set; }
		public int ClientHeight { get; set; }
	}
}
