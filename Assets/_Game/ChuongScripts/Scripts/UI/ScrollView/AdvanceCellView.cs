namespace ChuongCustom
{
	using EnhancedUI.EnhancedScroller;
	using System;

	public abstract class AdvanceCellView : EnhancedScrollerCellView
	{
		public abstract Type Type { get; }

		public abstract float CellViewSize(ScrollData data = null);
	}
}