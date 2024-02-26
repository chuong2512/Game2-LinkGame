using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : ItemInterface
{

    private bool isRunning = false;

    SpecialBlockEffect eff;

    int currentTime = 0;

    public static CarController instance;

    Vector3 start, end;

    void Awake()
    {
        timeConditionActive = 2;
        type = BlockType.Strawberry;
        gameObject.SetActive(false);
        instance = this;

    }

    public override void CheckRunConditon(BlockType type)
    {
        if (this.type == type)
        {
            ++currentTime;
            if (currentTime == timeConditionActive)
                SetRun();
        }
        else
        {
            currentTime = 0;
        }
    }

    public override void SetRun()
    {
        GameManager.instance.SetGameState(GameState.EFFECT);
        int row = Random.Range(0, BoardManager.instance.height - 1);
        start = BoardManager.instance.GetBlock(row, 0).transform.position;
        end = BoardManager.instance.GetBlock(row, BoardManager.instance.width - 1).transform.position;
        transform.position = start;
        isRunning = true;
        gameObject.SetActive(true);

        //
		if (SoundManager.instance != null)
			SoundManager.instance.PlaySFX (SFX.MAYCAY);

        eff = new SpecialBlockEffect(BoardManager.instance);
        List<Block> blocks = new List<Block>();

        Block block;
        for (int col = 0; col < BoardManager.instance.width; ++col)
        {
            block = BoardManager.instance.GetBlock(row, col);
            if (!Block.IsSpecialBlock(block))
            {
                blocks.Add(block);
            }
            else
            {

                eff.AddSpecialBlock(block);
            }
            block.SetState(BlockState.Selected);
        }

        for (int i = 0; i < blocks.Count; ++i)
        {
            if (!BoardManager.instance.GetPath().Contains(blocks[i]))
                BoardManager.instance.GetPath().Add(blocks[i]);
        }
    }

    void Update()
    {
        if (isRunning)
        {
            while (transform.position.x < end.x)
            {
                Vector3 currentPos = transform.position;
                currentPos.x += 5 * Time.deltaTime;
                transform.position = currentPos;
                return;
            }
            isRunning = false;
            Block.observers.Clear();
            //Block.numBlock = 0;
            //Block.numHandled = 0;
			Block.PrepareEatBlock();
            if (eff.specialBlocks.Count > 0)
                Block.observers.Add(eff);
            else
                Block.observers.Add(GameManager.instance);
            BoardManager.instance.EatBlocks(EatType.SpecialEat);
            currentTime = 0;
            gameObject.SetActive(false);
        }
    }

}
