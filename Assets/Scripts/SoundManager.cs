using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource bgm;
    public AudioSource sfx;
    public AudioSource startOver;
    public AudioSource blockSound;
    public AudioSource loopSound;
    private AudioSource secondarySfx;
    private AudioSource secondaryStartOver;
    private AudioSource secondaryBlockSound;
    float startTime = 0;
    float stopTime = 0;

    private AudioSource sfxSouce
    {
        get
        {
            if (!sfx.isPlaying) return sfx;
            if (secondarySfx == null) secondarySfx = (new GameObject("SFX")).AddComponent<AudioSource>();
            return secondarySfx;
        }
    }

    private AudioSource startOverSouce
    {
        get
        {
            if (!startOver.isPlaying) return startOver;
            if (secondaryStartOver == null) secondaryStartOver = (new GameObject("STARTOVER")).AddComponent<AudioSource>();
            return secondaryStartOver;
        }
    }

    private AudioSource blockSoundSouce
    {
        get
        {
            if (!blockSound.isPlaying) return blockSound;
            if (secondaryBlockSound == null) secondaryBlockSound = (new GameObject("BLOCKSOUND")).AddComponent<AudioSource>();
            return secondaryBlockSound;
        }
    }

    public SFXEntry[] sfxs;
    public BGMEntry[] bgms;
    public STARTOVEREntry[] startOvers;
    public BLOCKSOUNDEntry[] blocks;

    void Awake()
    {
        instance = this;
    }



    void Update()
    {
        if (stopTime != 0)
        {
            if (startTime < stopTime)
            {
                startTime += Time.deltaTime;
            }
            else
            {
                StopLoopSFX();
            }
        }
    }

    /// <summary>
    /// Play BGM base on time
    /// </summary>
    /// <param name="day">is play if current time is day</param>
    /// <param name="night">is play if current time is night</param>
    public void PlayBGM(BGM day, BGM night)
    {
        if (IsBgmOn())
        {
            int hour = System.DateTime.Now.Hour;
            if (hour > 6 && hour < 19)
            {
                PlayBGM(day);
            }
            else
            {
                PlayBGM(night);
            }
        }
    }

    public void PlayBGM(BGM bgmName)
    {
        if (IsBgmOn())
        {
            foreach (BGMEntry entry in bgms)
            {
                if (entry.name == bgmName)
                {
                    bgm.clip = entry.music;
                    bgm.Play();
                    return;
                }
            }
        }
    }

    public void StopAllPlayBGM()
    {
        if (!IsBgmOn())
        {
            foreach (BGMEntry entry in bgms)
            {
                bgm.clip = entry.music;
                bgm.Stop();
            }
        }
    }

    public void StopAllPlaySFX()
    {
        if (!IsSfxOn())
        {
            foreach (SFXEntry entry in sfxs)
            {
                sfxSouce.clip = entry.sound;
                sfxSouce.Play();
            }
        }
    }

    public void PlaySFX(SFX sfxName)
    {
        if (IsSfxOn())
        {
            foreach (SFXEntry entry in sfxs)
            {
                if (entry.name == sfxName)
                {
                    sfxSouce.clip = entry.sound;
                    sfxSouce.Play();
                    return;
                }
            }
        }
    }

    public void PlaySFX(SFX sfxName, float time)
    {
        if (IsSfxOn())
        {
            startTime = 0;
            stopTime = time;
            foreach (SFXEntry entry in sfxs)
            {
                if (entry.name == sfxName)
                {
                    loopSound.clip = entry.sound;
                    loopSound.Play();
                    return;
                }
            }
        }
    }

    public void StopLoopSFX()
    {
        loopSound.Stop();
        stopTime = 0;
    }

    public void StopPlaySFX(SFX sfxName)
    {
        if (IsSfxOn())
        {
            foreach (SFXEntry entry in sfxs)
            {
                if (entry.name == sfxName)
                {
                    sfxSouce.clip = entry.sound;
                    sfxSouce.Stop();
                    return;
                }
            }
        }
    }

    public void PlaySTART_OVER(STARTOVER stateOverName)
    {
        if (IsSfxOn())
        {
            foreach (STARTOVEREntry entry in startOvers)
            {
                if (entry.name == stateOverName)
                {
                    startOver.clip = entry.sound;
                    startOver.Play();
                    return;
                }
            }
        }
    }

    public void StopPlaySTART_OVER(STARTOVER stateOverName)
    {
        if (IsSfxOn())
        {
            foreach (STARTOVEREntry entry in startOvers)
            {
                if (entry.name == stateOverName)
                {
                    startOver.clip = entry.sound;
                    startOver.Stop();
                    return;
                }
            }
        }
    }

    public void PlayBLOCKSOUND(BLOCKSOUND blockSoundName)
    {
        if (IsSfxOn())
        {
            foreach (BLOCKSOUNDEntry entry in blocks)
            {
                if (entry.name == blockSoundName)
                {
                    blockSound.clip = entry.sound;
                    blockSound.Play();
                    return;
                }
            }
        }
    }

    /// <summary>
    /// Check setting
    /// </summary>
    /// <returns></returns>
    public bool IsBgmOn()
    {
        return (Attributes.backgroundMusic == Attributes.IS_ON);
    }


    /// <summary>
    /// Check setting
    /// </summary>
    /// <returns></returns>
    public bool IsSfxOn()
    {
        return (Attributes.effect == Attributes.IS_ON);
    }
}

public enum BGM
{
    GAME_DAY,
    GAME_NIGHT,
    MENU_DAY,
    MENU_NIGHT,
    END_GAME,
    LOADING
}
public enum SFX
{
    OPEN_DIALOG,
    CLICK_BUTTON,
    MISS_COMBO,
    BLOCK_YELL,
    EAT_BLOCK_FAIL,
    EAT_1,
    HENTAI,
    BUNNY,
    BIRD_FLY,
    BIRD_PERCHE,
    DOG,
    STORY,
    BUNHIN,
    CAUVONG,
    LUOIHAI,
    MAYCAY
};

public enum STARTOVER
{
    LAST_7S,
    COUNT03_START,
    COUNT02_START,
    COUNT01_START,
    START,
    TIME_OVER
}

public enum BLOCKSOUND
{
    APPLE_HAPPY,
    CARROT_HAPPY,
    CHILI_HAPPY,
    CORN_HAPPY,
    EGGPLANT_HAPPY,
    PINEAPPLE_HAPPY,
    PUMPKIN_HAPPY,
    PURPLEONION_HAPPY,
    STRAWBERRY_HAPPY,
    SUN_HAPPY,
    TOMATO_HAPPY,
    BIRD_HAPPY,
    BUNNY_HAPPY,
    PUPPY_HAPPY,
    DEFAULT
}

[System.Serializable]
public struct BGMEntry
{
    public BGM name;
    public AudioClip music;
}

[System.Serializable]
public struct SFXEntry
{
    public SFX name;
    public AudioClip sound;
}

[System.Serializable]
public struct STARTOVEREntry
{
    public STARTOVER name;
    public AudioClip sound;
}

[System.Serializable]
public struct BLOCKSOUNDEntry
{
    public BLOCKSOUND name;
    public AudioClip sound;
}
