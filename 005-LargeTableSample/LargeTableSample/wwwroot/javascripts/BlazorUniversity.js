var BlazorUniversity = BlazorUniversity || {};
BlazorUniversity.getScrollInfo = function (element) {
	return {
		ScrollHeight: element.scrollHeight,
		ScrollTop: element.scrollTop,
		ClientHeight: element.clientHeight
	};
};