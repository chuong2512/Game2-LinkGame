using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventController : MonoBehaviour
{

    public static EventController instance;

    public bool specialHandle = false;


    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (GameManager.instance.gameState == GameState.PLAYING)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                //If something was hit, the RaycastHit2D.collider will not be null.
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "BlockingMaterial")
                        return;
                    Block block = hit.collider.gameObject.GetComponent<Block>();
                    if (block == null)
                    {
                        Debug.Log("Get component Block false");
                        return;
                    }


                    if (hit.collider.tag == "SpecialBlock")
                    {
                        SpecialBlockEffect eff = new SpecialBlockEffect(BoardManager.instance);
                        block.SetState(BlockState.Selected);
                        eff.Effect(block);
                    }
                }
            }

            if (Input.GetMouseButton(0))
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                //If something was hit, the RaycastHit2D.collider will not be null.
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "BlockingMaterial")
                        return;
                    Block block = hit.collider.gameObject.GetComponent<Block>();
                    if (block == null)
                    {
                        Debug.Log("Get component NormalBlock false");
                        return;
                    }

                    if (hit.collider.tag == "NormalBlock")
                    {
                        BoardManager.instance.AddBlockToPath(block);
                    }

                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                
                    Block.observers.Clear();


                    if (BoardManager.instance.CheckSameTypeInPath() == true)
                    {
                        ItemEffect.instance.type = BoardManager.instance.GetPath()[0].type;
                        Block.observers.Add(ItemEffect.instance);
                    }
                    else
                    {
                        Block.observers.Add(GameManager.instance);
                    }


                    //Block.numBlock = 0;
                    //Block.numHandled = 0;
					Block.PrepareEatBlock();
                    BoardManager.instance.EatBlocks();
                
            }
        }
    }

    public void OnResult()
    {
        RankingController.instance.ReportScore(ScoreCalculator.instance.GetScore());
    }

}
