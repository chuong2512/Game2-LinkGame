using UnityEngine;
using System.Collections;

public class BunnyAniControl : MonoBehaviour
{
    int row;
    // Use this for initialization
    Block parent;
    float x, y;

    Vector2 start, end;

    bool running = false;

    SpecialBlockEffect effect;
    Block[] blocks;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < end.x && running)
        {
            Vector2 positon = transform.position;
            positon.x += 5 * Time.deltaTime;
            transform.position = positon;
        }
        else
        {
            running = false;
            effect.OnBunnyEffectDestroyed();
            Destroy(gameObject);
        }
    }

    public void SetRun(SpecialBlockEffect effect)
    {
		parent = transform.parent.gameObject.GetComponent<Block>();
		start = BoardManager.instance.GetBlock(parent.y, 0).transform.position;
		transform.position = start;
		end = BoardManager.instance.GetBlock(parent.y, BoardManager.instance.width - 1).transform.position;
        running = true;
        this.effect = effect;
        blocks = BoardManager.instance.GetRow(effect.block.y);
    }
}
