using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SuggestionMove : MonoBehaviour
{

    public BoardManager boardManager;

    public List<Block> searchPath = new List<Block>();

    private float waitingTime = 0f;

    private bool isHinted = false;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameState == GameState.PLAYING)
        {
            if (waitingTime < 3.0f)
            {
                waitingTime += Time.deltaTime;
            }
            else if ((GameManager.instance.gameState == GameState.PLAYING) && !isHinted)
            {
                GetHint();
            }
        }
    }

    public void SetBoardManager(BoardManager boardManager)
    {
        this.boardManager = boardManager;
    }

    /*
	 * GetHint(): Hien thi goi y trong game
	 * Input: void
	 * Output: SearchPath trong game
	 * 
	*/
    public void GetHint()
    {
        isHinted = true;
        searchPath.Clear();
        searchPath = SearchPath();
        foreach (Block block in searchPath)
        {
            block.SetState(BlockState.Selected);
        }
    }

    public void Disable()
    {
        foreach (Block block in searchPath)
        {
            block.SetState(BlockState.Normal);
        }
    }

    /*
	 * CheckPath(): Kiem tra xem tren man choi con duong di hay khong
	 * Input: void
	 * Output: True: con duong, False: Het duong di
	 * 
	*/
    public bool CheckPath()
    {
        searchPath.Clear();
        searchPath = SearchPath();
        if (searchPath.Count == 0)
        {
            return false;
        }
        return true;
    }

    /*
	 * SearchPath: Kiem tra xem con duong di trong game hay khong
	 * Input: void
	 * Ouput: List<Block> duong di trong game
	 * 
	 * 
	*/
    private List<Block> SearchPath()
    {
        searchPath = new List<Block>();

        //Kiem tra quan dac biet tren man choi
        for (int row = 0; row < boardManager.width; ++row)
        {
            for (int col = 0; col < boardManager.height; ++col)
            {
                Block blockTemp = boardManager.GetBlock(row, col);
                if (Block.IsSpecialBlock(blockTemp))
                {
                    searchPath.Add(blockTemp);
                    return searchPath;
                }
            }
        }
        //Kiem tra nuoc di quan thuong tren man choi
        for (int row = 0; row < boardManager.width; ++row)
        {
            for (int col = 0; col < boardManager.height; ++col)
            {
                searchPath.Clear();
                searchPath.Add(boardManager.GetBlock(row, col));
                for (int i = 0; i < 3; i++)
                {
                    Block blockTemp = CheckNextBlockToPath(searchPath);
                    if (blockTemp)
                    {
                        searchPath.Add(blockTemp);
                    }
                }
                if (searchPath.Count == 3)
                    return searchPath;
            }
        }
        searchPath.Clear();
        return searchPath;
    }

    /*
	 * CheckNextBlockToPath(): Kiem tra xem tai vi tri hien tai, co the ve duoc hay khong?
	 * Input: col, row hien tai trong boardgame
	 * Output: Block voi toa do tiep theo
	 * 
	*/
    private Block CheckNextBlockToPath(List<Block> searchPath)
    {
        Block nextBlock = null;
        Block currentBlock = searchPath[searchPath.Count - 1];
        int row = currentBlock.y;
        int col = currentBlock.x;
        if (row - 1 >= 0)
        {
            nextBlock = boardManager.GetBlock(row - 1, col);
            if (isDrawNextBlock(currentBlock, nextBlock))
                return nextBlock;

            if (col + 1 < boardManager.height)
            {
                nextBlock = boardManager.GetBlock(row - 1, col + 1);
                if (isDrawNextBlock(currentBlock, nextBlock))
                    return nextBlock;
            }
            if (col - 1 >= 0)
            {
                nextBlock = boardManager.GetBlock(row - 1, col - 1);
                if (isDrawNextBlock(currentBlock, nextBlock))
                    return nextBlock;
            }
        }

        if (col + 1 < boardManager.height)
        {
            nextBlock = boardManager.GetBlock(row, col + 1);
            if (isDrawNextBlock(currentBlock, nextBlock))
                return nextBlock;

            if (row + 1 < boardManager.width)
            {
                nextBlock = boardManager.GetBlock(row + 1, col + 1);
                if (isDrawNextBlock(currentBlock, nextBlock))
                    return nextBlock;
            }

            if (row - 1 >= 0)
            {
                nextBlock = boardManager.GetBlock(row - 1, col + 1);
                if (isDrawNextBlock(currentBlock, nextBlock))
                    return nextBlock;
            }
        }

        if (col - 1 >= 0)
        {
            nextBlock = boardManager.GetBlock(row, col - 1);
            if (isDrawNextBlock(currentBlock, nextBlock))
                return nextBlock;

            if (row + 1 < boardManager.width)
            {
                nextBlock = boardManager.GetBlock(row + 1, col - 1);
                if (isDrawNextBlock(currentBlock, nextBlock))
                    return nextBlock;
            }
            if (row - 1 >= 0)
            {
                nextBlock = boardManager.GetBlock(row - 1, col - 1);
                if (isDrawNextBlock(currentBlock, nextBlock))
                    return nextBlock;
            }
        }

        if (row + 1 < boardManager.width)
        {
            nextBlock = boardManager.GetBlock(row + 1, col);
            if (isDrawNextBlock(currentBlock, nextBlock))
                return nextBlock;

            if (col + 1 < boardManager.height)
            {
                nextBlock = boardManager.GetBlock(row + 1, col + 1);
                if (isDrawNextBlock(currentBlock, nextBlock))
                    return nextBlock;
            }

            if (col - 1 >= 0)
            {
                nextBlock = boardManager.GetBlock(row + 1, col - 1);
                if (isDrawNextBlock(currentBlock, nextBlock))
                    return nextBlock;
            }
        }

        return null;
    }

    private bool isDrawNextBlock(Block currentBlock, Block nextBlock)
    {
        if (!searchPath.Contains(nextBlock) &&
            currentBlock.IsSameType(nextBlock) &&
            currentBlock.IsNear(nextBlock))
            return true;
        return false;
    }

    public void ResetTime()
    {
        waitingTime = 0f;
        isHinted = false;
    }
}
