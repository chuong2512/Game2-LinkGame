using EnhancedUI.EnhancedScroller;

namespace ChuongCustom
{
	using System;

	public abstract class ResizeWithDataCellView<T> : AdvanceCellView where T : ScrollData
	{
		public override Type Type => typeof(T);

		public override float CellViewSize(ScrollData data)
		{
			var vData = (T) data;

			if (vData == null)
			{
				return 0;
			}

			return CellViewSize(vData);
		}

		protected abstract float CellViewSize(T data);
	}
}