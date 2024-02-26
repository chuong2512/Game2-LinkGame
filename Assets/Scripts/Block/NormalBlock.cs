using UnityEngine;
using System.Collections;

public class NormalBlock : Block
{
    //Trạng thái hoa quả

    private float t;

    private float t2;
    //private int i= 0;
    public float waitTime = 1f;
    public BlockState state;

    public override void SetState(BlockState state)
    {
        this.state = state;
        switch (state)
        {
            case BlockState.Destroy:
				if (isMoving) {
					Debug.Log ("Dang chay anh oi");
				}
                PlaySoundForBlockType();
                SetState(BlockState.Normal);
                FallDown(3);
                break;
            case BlockState.Selected:
                if (gameObject != null)
                    ChangeAnimation(BlockAnimationState.WAKEUP);
                //Kich hoat am thanh trang thai bien hinh
                if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.HENTAI);
                break;
            case BlockState.Normal:
                if (ComboManager.instance.isCombo)
                    ChangeAnimation(BlockAnimationState.EXCITED);
                else
                    ChangeAnimation(BlockAnimationState.SLEEP);
                if (lineRender != null)
                {
                    lineRender.UnUsed();
                    lineRender = null;
                }
                break;
            default:
                break;
        }

    }



    void FallDown(float timeToDestroy)
    {
        StartCoroutine(Fall(timeToDestroy));
    }

    Rigidbody2D rb;

    IEnumerator Fall(float time)
    {
        float currentTime = 0;
        GetComponent<Collider2D>().enabled = false;
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        Vector3 v = new Vector3(Random.Range(0, 0.75f), 1, 0);
        rb.AddForce(v * 400);
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            Color c = GetComponent<SpriteRenderer>().color;
            if (c.a > 0) c.a -= Time.deltaTime / time;
            GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }

}