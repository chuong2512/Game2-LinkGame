using UnityEngine;
using System.Collections;

public class SpecialBlock : Block {
	public bool isWakeUp, isSleep;

    public GameObject effectPrefab;

	// Use this for initialization

	public override void SetState(BlockState state)
	{
		isWakeUp = false;
		isSleep = false;
		switch (state)
		{
		case BlockState.Destroy:
			if (isMoving) {
				Debug.Log ("Dang chay anh oi");
			}
			PlaySoundForBlockType();
			SetState(BlockState.Normal);
			Destroy(gameObject);
			break;
		case BlockState.Normal:
			if(lineRender != null)
			{
				lineRender.UnUsed();
				lineRender = null;
			}
			if (ComboManager.instance.isCombo)
				ChangeAnimation(BlockAnimationState.EXCITED);
			else 
				ChangeAnimation(BlockAnimationState.SLEEP);
			break;
		case BlockState.Selected:
			ChangeAnimation(BlockAnimationState.WAKEUP);
			//Kich hoat am thanh trang thai bien hinh
			if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.HENTAI);
			break;
		}

	}
}
