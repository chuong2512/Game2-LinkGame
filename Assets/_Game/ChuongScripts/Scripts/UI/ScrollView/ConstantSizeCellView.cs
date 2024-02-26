using EnhancedUI.EnhancedScroller;

namespace ChuongCustom
{
	using System;
	using UnityEngine;

	public abstract class ConstantSizeCellView : AdvanceCellView
	{
		[SerializeField] private float _cellViewSize;

		public abstract override Type Type { get; }

		public override float CellViewSize(ScrollData data = null) { return _cellViewSize; }
	}
}