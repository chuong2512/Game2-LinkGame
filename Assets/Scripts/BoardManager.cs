using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;


public enum EatType
{
    SpecialEat,
    NormalEat
}


public class BoardManager : MonoBehaviour
{
    private bool check = false;

    public static BoardManager instance;

    float blockSize; //kich thuoc moi block

    public int width;

    public int height;

    public Block[,] listBlocks;

    //public GameObject blockMakerObj;
    List<Block> path = new List<Block>();
    SuggestionMove suggetionMove;
    public Vector3 firstElePostion;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        width = 7;
        height = 7;
        blockSize = 6.61f / width;
        listBlocks = new Block[width * 2, height * 2];



    }
    public void BoardInit()
    {
        AvatarActiveController.AvatarEffect();
        CreateBoardGame();
        suggetionMove = GetComponent<SuggestionMove>();
        suggetionMove.SetBoardManager(this);
		//----------------------Kiem tra duong di tren boardgame
		if (!suggetionMove.CheckPath())
		{
			//Tao moi boardgame khi het duong di
			Debug.Log("HET DUONG DI");
			RecreateBoardGame();
		}
    }

    public bool IsEmptyBoardGameStatus()
    {
        for (int row = 0; row < width; ++row)
        {
            for (int col = 0; col < height; ++col)
            {
                if (listBlocks[row, col] == null)
                    return true;
            }
        }
        return false;
    }

    //Tao boardgame khi khoi dong
    void CreateBoardGame()
    {

        for (int row = 0; row < width; ++row)
        {
            for (int col = 0; col < height; ++col)
            {
                if (listBlocks[row, col] == null)
                    CreateRandomBlock(row, col);
            }
        }
    }

    public Vector2 ToScreen(int x, int y)
    {
        float offset = (width % 2 == 0) ? blockSize / 2 : 0;
        int boardOffsetX = width / 2;
        int boardOffsetY = height / 2;
        return new Vector2((y - boardOffsetY) * blockSize + offset, (x - boardOffsetX) * blockSize + offset);
    }

    //Random cac doi tuong block trong game
    public void CreateRandomBlock(int row, int col)
    {
        Block block;

        while (true)
        {
            block = BlockMaker.instance.RandomInstanceGameObject();
            if (block.type != BlockType.Sun)
                break;
            Destroy(block.gameObject);
        }

        if (block == null)
        {
            Debug.Log("Khong tao duoc hoa qua");
            return;
        }
        block.gameObject.transform.SetParent(transform);
        block.gameObject.transform.position = new Vector3(row, col, 0);
        block.gameObject.transform.localPosition = ToScreen(row, col);

        block.x = col;
        block.y = row;
        listBlocks[row, col] = block;

        block.SetState(BlockState.Normal);
    }


    public void CreateRandomBlock(int row, int col, BlockType type)
    {
        Block block = BlockMaker.instance.InstanceBlock(type);
        if (block == null)
        {
            Debug.Log("Khong tao duoc hoa qua");
            return;
        }
        block.gameObject.transform.SetParent(transform);
        block.gameObject.transform.position = new Vector3(row, col, 0);
        block.gameObject.transform.localPosition = ToScreen(row, col);

        block.x = col;
        block.y = row;
        listBlocks[row, col] = block;

        block.SetState(BlockState.Normal);
    }

    void CreatBlockAfterEat(Dictionary<int, int> offsets)
    {
		int num = 0;
        for (int i = 0; i < path.Count; ++i)
        {

            int col = (int)path[i].x;

            CreateRandomBlock(offsets[col], col);
            ++offsets[(int)path[i].x];
			++num ;
        }
    }

    void DestroyBlockOnPath(Dictionary<int, int> offsets)
    {
		Block block;
        List<Block> blocksToDelete = new List<Block>();
        List<Block> moveLists = new List<Block>();

        for (int i = 0; i < path.Count; ++i)
        {
            int row = path[i].y;
            int col = path[i].x;

            for (int yPos = row; yPos < offsets[col] - 1; ++yPos)
            {
				block = listBlocks[yPos+1,col];
				block.SetDerection(block.transform.position);
            }
        }


        for (int i = 0; i < path.Count; ++i)
        {
            int row = path[i].y;
            int col = path[i].x;


            for (int yPos = row; yPos < offsets[col] - 1; ++yPos)
            {
				block = listBlocks[yPos + 1, col];
                if (!moveLists.Contains(block))
                {
                    moveLists.Add(block);
                }
                block.MoveDown();
            }
        }

        for (int i = 0; i < path.Count; ++i)
        {
            int row = path[i].y;
            int col = path[i].x;

			block = listBlocks[row,col];
            blocksToDelete.Add(block);

            for (int yPos = row; yPos < offsets[col] - 1; ++yPos)
            {
                listBlocks[yPos, col] = listBlocks[yPos + 1, col];
                listBlocks[yPos, col].y = yPos;

            }
            --offsets[col];
        }

		Debug.Log ("BLock to delete: " + blocksToDelete.Count);
		for (int i = 0; i < moveLists.Count; ++ i) {
			if (blocksToDelete.Contains(moveLists[i])) {
				moveLists.RemoveAt(i);
				--i;
			}
		}

        //Xoa & tinh diem
      
		foreach (Block b in moveLists) {
			if (b.transform.position.y <= b.direction.y) {
				Debug.Log("WTF");
			}
		}

		for (int i= 0; i < moveLists.Count; ++i) {
			if (blocksToDelete.Contains(moveLists[i])) {
				Debug.Log ("WTFFFF");
			}
		}

		for (int i = 0; i < blocksToDelete.Count; ++i)
		{
			GameManager.instance.currentScore += blocksToDelete[i].score;
			blocksToDelete[i].SetState(BlockState.Destroy);
		}


        for (int i = 0; i < moveLists.Count; ++i)
        {
            moveLists[i].SetMove();
        }

        path.Clear();

		/*
        if (GameManager.instance.gameState != GameState.PLAYING)
            GameManager.instance.SetGameState(GameState.PLAYING);
            */
        //Am thanh an block
        if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.EAT_1);
    }

    //Uncheck nhung block da chon
    void UnSelectBlockOnPath()
    {
        Block block;
        for (int i = 0; i < path.Count; ++i)
        {
            block = listBlocks[(int)path[i].y, (int)path[i].x];
            block.SetState(BlockState.Normal);
        }
        path.Clear();
    }

    public bool CheckSameTypeInPath()
    {
        if (path.Count == 0)
            return false;
        for (int i = 1; i < path.Count; ++i)
        {
            if (path[i].type != path[0].type)
            {
                return false;
            }
        }

        return true;
    }

    public void EatBlocks(EatType type = EatType.NormalEat)
    {
		if (path.Count < 0)
			return;

        if (path.Count < 3 && type == EatType.NormalEat)
        {
            UnSelectBlockOnPath();
            if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.EAT_BLOCK_FAIL);
            return;
        }

        suggetionMove.Disable();

        if (path.Count > 4 && type == EatType.NormalEat)
        {
            Block block;

            switch (path.Count)
            {
                case 5:
                    block = BlockMaker.instance.InstanceBlock(BlockType.Sun);
                    break;
                case 6:
                    block = BlockMaker.instance.InstanceBlock(BlockType.Bunny);
                    break;
                case 7:
                    block = BlockMaker.instance.InstanceBlock(BlockType.Puppy);
                    break;
                default:
                    block = BlockMaker.instance.InstanceBlock(BlockType.Bird);
                    int timeCombos = 2 * (path.Count - 8);
                    if (timeCombos != 0)
                    {
                        LoadTime.instance.AddTime(timeCombos);
                        string timeConbosText = "+" + timeCombos + "s";
                        ComboManager.instance.ActiveCombos(timeConbosText);
                    }
                    break;
            }


            if (block == null)
            {
                Debug.Log("Chua tao duoc quan dac biet");
                return;
            }
			block.SetState(BlockState.Normal);
            block.transform.SetParent(transform);


            int row = (int)path[path.Count - 1].y;
            int col = (int)path[path.Count - 1].x;

            block.transform.position = path[path.Count - 1].transform.position;
            block.x = path[path.Count - 1].x;
            block.y = path[path.Count - 1].y;
            listBlocks[row, col] = block;
            path[path.Count - 1].SetState(BlockState.Destroy);
            path.RemoveAt(path.Count - 1);
        }

		GameManager.instance.SetGameState (GameState.EFFECT);

        ComboManager.instance.Count();
        ComboManager.instance.ResetStartTime();
        ComboManager.instance.CheckCombo();
        ScoreCalculator.instance.CalculateScore(path, ComboManager.instance.GetCombo());

        Dictionary<int, int> offsets = new Dictionary<int, int>();

        for (int i = 0; i < width; ++i)
        {
            offsets.Add(i, height);
        }

        CreatBlockAfterEat(offsets);
        DestroyBlockOnPath(offsets);
        //----------------------Kiem tra duong di tren boardgame
        if (!suggetionMove.CheckPath())
        {
            //Tao moi boardgame khi het duong di
            Debug.Log("HET DUONG DI");
            RecreateBoardGame();
        }

        LineRenderPooling.current.UnUsedAllPooledObject();
        suggetionMove.ResetTime();
        return;
    }

    /*
	 * RecreateBoardGame(): Tai tao lai boardgame
	 * Input: Block[,] listBlocks
	 * Ouput: Emply listBlocks
	*/
    private void RecreateBoardGame()
    {
        path.Clear();
        Debug.Log("GAME STATE: " + GameManager.instance.gameState);

        for (int row = 0; row < width; ++row)
        {
            for (int col = 0; col < height; ++col)
            {
                path.Add(listBlocks[row, col]);
            }
        }

        EatAllBlockInPath();

        return;
    }
    public void AddBlockToPath(Block block)
    {
        //SpecialBlockEffect
        if (path.Count == 0)
        {
            path.Add(block);
            block.SetState(BlockState.Selected);
            return;
        }
        if (Block.IsSpecialBlock(path[0].type))
            return;
        if (path.Contains(block))
        {
            if (path.Count == 1)
                return;
            if (path[path.Count - 2] == block)
            {

                path[path.Count - 1].SetState(BlockState.Normal);
                path[path.Count - 2].lineRender.UnUsed();
                path[path.Count - 2].lineRender = LineRenderPooling.current.GetPooledObject().GetComponent<LineRender>();
                path[path.Count - 2].SetState(BlockState.Selected);
                path.RemoveAt(path.Count - 1);
            }
            return;
        }
        if (path[path.Count - 1].IsNear(block) && path[path.Count - 1].IsSameType(block))
        {
            path[path.Count - 1].DrawLine(block);
            path.Add(block);
            block.lineRender = LineRenderPooling.current.GetPooledObject().GetComponent<LineRender>();
            block.SetState(BlockState.Selected);
        }
    }

    public void AutoEatSpecialBlock()
    {

        SpecialBlockEffect eff = new SpecialBlockEffect(this, GameState.GAMEOVER);
        for (int row = 0; row < width; ++row)
        {
            for (int col = 0; col < height; ++col)
            {
                Block block = listBlocks[row, col];
                if (Block.IsSpecialBlock(block.type))
                {

                    eff.AddSpecialBlock(block);
                }
            }
        }

        if (eff.specialBlocks.Count > 0)
        {
            eff.Effect(eff.specialBlocks.Dequeue());
        }
        else
        {
			UnSelectBlockOnPath();

			foreach(Block block in suggetionMove.searchPath) {
				block.SetState(BlockState.Normal);
			}
            GameManager.instance.SetGameState(GameState.GAMEOVER);
        }
    }

    /*----------------------------------------------------------------------------
	 * EatAllBlockInPath(): An tat ca cac quan tren duong di co xet cac truong hop
	 * Input: Path List<>
	 * Output: void
	 * 
	------------------------------------------------------------------------------*/
    public void EatAllBlockInPath()
    {
		Block.observers.Clear();
		Block.observers.Add(GameManager.instance);
		Block.numBlock = 0;
		Block.numHandled = 0;
        Dictionary<int, int> offsets = new Dictionary<int, int>();

        for (int i = 0; i < width; ++i)
        {
            offsets.Add(i, height);
        }

        CreatBlockAfterEat(offsets);
        DestroyBlockOnPath(offsets);

    }

    public void EatBlock(Block block)
    {
        path.Add(block);
        EatAllBlockInPath();
    }

    public void SetPath(List<Block> path)
    {
        this.path = path;
    }

    public List<Block> GetPath()
    {
        return path;
    }

    public Block GetBlock(int row, int col)
    {
        return listBlocks[row, col];
    }


    public void ChangeAllToExcited()
    {
        for (int row = 0; row < width; ++row)
        {
            for (int col = 0; col < height; ++col)
            {
                listBlocks[row, col].ChangeAnimation(BlockAnimationState.EXCITED);
            }
        }
    }

    public void ChangeAllToNormal()
    {
        for (int row = 0; row < width; ++row)
        {
            for (int col = 0; col < height; ++col)
            {
                if (!path.Contains(listBlocks[row, col]))
                    listBlocks[row, col].ChangeAnimation(BlockAnimationState.SLEEP);
            }
        }
    }

    public Block[] GetRow(int row)
    {
        if (row > height)
            return null;
        Block[] blocks = new Block[width];
        for (int i = 0; i < width; i++)
        {
            blocks[i] = GetBlock(row, i);
        }
        return blocks;
    }

}

