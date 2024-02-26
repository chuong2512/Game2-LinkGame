using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpecialBlockEffect : BlockObserver
{

    private BoardManager boardManager;
    public Block block;

    private Vector3 startPosition = new Vector3(0, 7.5f, -1.0f);
    private List<BirdEffect> birdEffects;
    List<Block> blocks = new List<Block>();
    public Queue<Block> specialBlocks = new Queue<Block>();

    GameState state;

    public SpecialBlockEffect()
    {
        this.boardManager = BoardManager.instance;
        state = GameState.PLAYING;
    }

    public SpecialBlockEffect(BoardManager boardManager)
    {
        this.boardManager = boardManager;
        state = GameState.PLAYING;
    }

    public SpecialBlockEffect(BoardManager boardManager, GameState state)
    {
        this.boardManager = boardManager;
        this.state = state;
    }


    public void Effect(Block block)
    {
		if (block == null) {
			Execute();
			return;
		}

        block.SetState(BlockState.Selected);
        GameManager.instance.SetGameState(GameState.EFFECT);
        this.block = block;
        blocks.Clear();
		blocks.Add (block);
	
        switch (block.type)
        {
            case BlockType.Bunny:
                BunnyEffect();
                break;

            case BlockType.Puppy:
                block.transform.GetChild(0).gameObject.SetActive(true);
                block.GetComponentInChildren<PuppyAniControl>().StartEffect(this);
                PuppyEffect(block);
                break;
            case BlockType.Bird:
                BirdEffect(block as SpecialBlock);
                //List<Block> boardPath = boardManager.GetPath();
                //BlockType type = boardPath[boardPath.Count-1].type;
                break;
            default:
                Debug.Log("Loai hoa qua nay khong co tac dung dac biet");
                break;
        }
    }

    /*
	 * RandomBlockType(): Random loai blocktype trong game
	 * Input: void
	 * Output: BlockType
	 * 
	*/
    private BlockType RandomBlockType()
    {
        while (true)
        {
            int row = Random.Range(0, boardManager.height);
            int col = Random.Range(0, boardManager.width);
            Block block = boardManager.GetBlock(row, col);
            if (!Block.IsSpecialBlock(block) && block.type != BlockType.Sun)
            {
                return block.type;
            }
        }
    }

    /// <summary>
    /// Start effect
    /// </summary>
    private void BunnyEffect()
    {
        if (block == null)
        {
            Debug.Log("Special blog effect null");
            return;
        }
        block.transform.GetChild(0).gameObject.SetActive(true);
        Block[] blocksInRow = BoardManager.instance.GetRow(block.y);
        foreach (Block blockEntry in blocksInRow)
        {
            blockEntry.SetState(BlockState.Selected);
            if (SpecialBlock.IsSpecialBlock(blockEntry) && block != blockEntry && !specialBlocks.Contains(block))
            {
                AddSpecialBlock(blockEntry);
            }
            if (!Block.IsSpecialBlock(blockEntry))
            {
                if (!blocks.Contains(blockEntry))
                    blocks.Add(blockEntry);
            }
        }
        //Kich hoat am thanh
        if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.BUNNY);
        block.transform.GetComponentInChildren<BunnyAniControl>().SetRun(this);

    }

    /*
	 * PuppyEffect(): Hieu ung chay cua cho con
	 * Input: block cho con
	 * Output: void
	 * 
	*/
    private void PuppyEffect(Block block)
    {
        this.block = block;
        //block.transform.GetChild(0).gameObject.SetActive(true);
        int row = block.y;
        int col = block.x;


        for (int i = row - 1; i <= row + 1; ++i)
        {
            for (int j = col - 1; j <= col + 1; ++j)
            {
                if (i >= 0 && j >= 0 && i < boardManager.width && j < boardManager.height)
                {
                    Block b = boardManager.GetBlock(i, j);
                    b.SetState(BlockState.Selected);
                    if (SpecialBlock.IsSpecialBlock(b) && b != block && !specialBlocks.Contains(b))
                    {
                        AddSpecialBlock(b);
                    }
                    if (!SpecialBlock.IsSpecialBlock(b))
                    {
                        if (!blocks.Contains(b))
                            blocks.Add(b);
                    }
                }
            }
        }
        //Kich hoat am thanh
        if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.DOG);

    }

    private void BirdEffect(SpecialBlock block)
    {
        // Random blocktype
        BlockType blockType = RandomBlockType();
        birdEffects = new List<BirdEffect>();
        this.block = block;
        //Kich hoat am thanh
        if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.BIRD_FLY);
        for (int i = 0; i < BoardManager.instance.width; i++)
        {
            for (int j = 0; j < BoardManager.instance.height; j++)
            {
                Block blockEntry = BoardManager.instance.GetBlock(i, j);
                if (blockEntry.type == blockType)
                {
                    blocks.Add(blockEntry);
                    blockEntry.SetState(BlockState.Selected);
                    GameObject go = GameObject.Instantiate(block.effectPrefab, startPosition, Quaternion.identity) as GameObject;
                    BirdEffect effect = go.GetComponent<BirdEffect>();
                    effect.target = blockEntry;
                    effect.onDestroy = OnBirdEffectDestroyed;
                    birdEffects.Add(effect);
                }
            }
        }
        //Kich hoat am thanh
		Debug.Log ("So luong quan: " + blocks.Count);
        if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.BIRD_PERCHE);
    }

    public void OnBirdEffectDestroyed(BirdEffect effect)
    {
        if (birdEffects.Count > 0)
        {
            birdEffects.Remove(effect);
        }
        if (birdEffects.Count == 0)
        {
            OnFinish();
        }
    }

    public void OnPuppyEffectDestroyed()
    {
        OnFinish();
    }

    public void OnBunnyEffectDestroyed()
    {
        OnFinish();
    }

    public void OnFinish()
    {
        foreach (Block block in blocks)
        {
            if (!BoardManager.instance.GetPath().Contains(block))
                BoardManager.instance.GetPath().Add(block);
        }
        Block.observers.Clear();
		Block.PrepareEatBlock ();
        //Block.numBlock = 0;
        //Block.numHandled = 0;
        Block.observers.Add(this);
        BoardManager.instance.EatBlocks(EatType.SpecialEat);
    }

	public void AddSpecialBlock(Block block) {
		if (block != null) {
			specialBlocks.Enqueue(block);
			return;
		}
		Debug.Log ("Add special Block null");
	}

    public void Execute()
    {
        GameManager.instance.SetGameState(GameState.PLAYING);
        if (specialBlocks.Count > 0)
        {
			if (specialBlocks.Peek() == null) {
				Debug.Log ("Special Block null");
			}
            GameManager.instance.SetGameState(GameState.EFFECT);
            Effect(specialBlocks.Dequeue());
            return;
        }

        if (state == GameState.GAMEOVER)
            GameManager.instance.SetGameState(GameState.GAMEOVER);
    }

}
