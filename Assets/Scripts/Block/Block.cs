using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum BlockType
{
    Apple,
    Carrot,
    Corn,
    Pineapple,
    Pumpkin,
    Strawberry,
    Tomato,
    Eggplant,
    Bird,
    Bunny,
    Puppy,
    Sun,
    Chili,
    Purpleonion
};

public enum BlockState
{
    Normal,
    Selected,
    Destroy,
    Hint
};


public enum BlockAnimationState
{
    EXCITED,
    SLEEP,
    WAKEUP
}

public enum Trend
{
    Top,
    Bottom,
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
    Left,
    Right
};

public abstract class Block : MonoBehaviour
{

    public BlockType type;
    protected Animator anim;
    public int x, y;
    public float gravity = 1;
    public int score;
    private float velocity = 0;
    protected bool isMoving = false;
    public Vector3 direction;
    public const float diff = 0.9442858f;
    public LineRender lineRender = null;
    protected bool excited, sleep, wakeup;
    public static int numBlock = 0;
    public static int numHandled = -1;
    public static List<BlockObserver> observers = new List<BlockObserver>();


    void Awake()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.Log("Chua gan animation cho block!");
        }
        direction = transform.position;
    }


	public static void PrepareEatBlock() {
		numBlock = 0;
		numHandled = 0;
	}

    void Update()
    {
        if (!isMoving) return;
        velocity = gravity * Time.deltaTime;
        Vector3 currentPosition = transform.position;

        if (currentPosition.y <= direction.y)
        {
            currentPosition.y = direction.y;
            gravity = 0;
            velocity = 0;
            transform.position = currentPosition;
            direction = Vector3.zero;
            ++numHandled;
            if (numHandled == numBlock)
            {
                GameManager.instance.SetGameState(GameState.PLAYING);
                Notify();
            }
            isMoving = false;
            return;
        }

        currentPosition.y -= gravity;
        transform.position = currentPosition;
    }

    public bool IsSameType(Block block)
    {
        if (this.type == block.type || this.type == BlockType.Sun || block.type == BlockType.Sun)
        {
            return true;
        }

        return false;
    }

    public static bool CheckSameType(BlockType t1, BlockType t2)
    {
        if (t1 == t2 || t1 == BlockType.Sun || t2 == BlockType.Sun)
            return true;
        return false;
    }

    public abstract void SetState(BlockState state);

    public bool IsNear(Block another)
    {
        if (Mathf.Abs(this.x - another.x) >= 2 || Mathf.Abs(this.y - another.y) >= 2)
        {
            return false;
        }
        return true;
    }

    public void SetMove()
    {
        isMoving = true;
        gravity = 0.3f;
        ++numBlock;
    }

    public void SetDerection(Vector3 direction)
    {
        this.direction = direction;
    }

    public void MoveDown()
    {
        this.direction.y -= diff;
    }

    public static bool IsSpecialBlock(BlockType type)
    {
        if (type == BlockType.Bird || type == BlockType.Bunny || type == BlockType.Puppy)
        {
            return true;
        }
        return false;
    }

    public static bool IsSpecialBlock(Block block)
    {
        return IsSpecialBlock(block.type);
    }

    public void DrawLine(Block newBlock)
    {
        if (lineRender == null)
            lineRender = LineRenderPooling.current.GetPooledObject().GetComponent<LineRender>();
        lineRender.DrawLine(CheckBlockTrend(newBlock), transform.position);
    }

    //So sanh vi tri quan moi vs quan hien tai
    public Trend CheckBlockTrend(Block block)
    {
        if (x == block.x && y == block.y + 1)
            return Trend.Top;
        if (x == block.x && y == block.y - 1)
            return Trend.Bottom;
        if (x - 1 == block.x && y == block.y)
            return Trend.Left;
        if (x + 1 == block.x && y == block.y)
            return Trend.Right;
        if (x - 1 == block.x && y - 1 == block.y)
            return Trend.BottomLeft;
        if (x - 1 == block.x && y + 1 == block.y)
            return Trend.TopLeft;
        if (x + 1 == block.x && y - 1 == block.y)
            return Trend.BottomRight;
        return Trend.TopRight;
    }


    void SetFalseAll()
    {
        excited = false;
        sleep = false;
        wakeup = false;
    }

    public void ChangeAnimation(BlockAnimationState state)
    {
        if (anim == null)
        {
            Debug.Log("Animation null!");
            return;
        }

        SetFalseAll();

        switch (state)
        {

            case BlockAnimationState.EXCITED:
                excited = true;
                break;
            case BlockAnimationState.WAKEUP:
                wakeup = true;
                break;
            case BlockAnimationState.SLEEP:
                sleep = true;
                break;
            default:
                break;
        }

        //anim.SetBool ("Eat", eat);
        anim.SetBool("Excited", excited);
        anim.SetBool("Sleep", sleep);
        //anim.SetBool ("Tongue", tongue);
        anim.SetBool("WakeUp", wakeup);
        //anim.SetBool ("Wink", wink);
    }

    void Notify()
    {
        foreach (BlockObserver o in observers)
        {
            o.Execute();
        }
    }

    public void PlaySoundForBlockType()
    {
        BlockType blockType = gameObject.GetComponent<Block>().type;
        if (blockType != null)
        {
            switch (blockType)
            {
                case BlockType.Apple:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.APPLE_HAPPY);
                    break;
                case BlockType.Carrot:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.CARROT_HAPPY);
                    break;
                case BlockType.Chili:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.CHILI_HAPPY);
                    break;
                case BlockType.Corn:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.CORN_HAPPY);
                    break;
                case BlockType.Eggplant:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.EGGPLANT_HAPPY);
                    break;
                case BlockType.Pineapple:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.PINEAPPLE_HAPPY);
                    break;
                case BlockType.Pumpkin:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.PUMPKIN_HAPPY);
                    break;
                case BlockType.Purpleonion:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.PURPLEONION_HAPPY);
                    break;
                case BlockType.Strawberry:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.STRAWBERRY_HAPPY);
                    break;
                case BlockType.Sun:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.SUN_HAPPY);
                    break;
                case BlockType.Tomato:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.TOMATO_HAPPY);
                    break;
                case BlockType.Bird:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.BIRD_HAPPY);
                    break;
                case BlockType.Bunny:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.BUNNY_HAPPY);
                    break;
                case BlockType.Puppy:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.PUPPY_HAPPY);
                    break;
                default:
                    if (SoundManager.instance != null)
                        SoundManager.instance.PlayBLOCKSOUND(BLOCKSOUND.DEFAULT);
                    break;
            }
        }
    }
}