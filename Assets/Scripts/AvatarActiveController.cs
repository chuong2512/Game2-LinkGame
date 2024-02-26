using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarActiveController : MonoBehaviour
{
    public static void AvatarEffect()
    {
        switch (Attributes.selectedAvatar)
        {
			case Strings.AVATAR_ACE:
                //Tang 5s khi duoc trang bi
                LoadTime.instance.AddTime(5);
                break;
			case Strings.AVATAR_CHOPPER:
                //Tang 10s khi duoc trang bi
                LoadTime.instance.AddTime(10);
                break;

			case Strings.AVATAR_FRANKY:
                //Tang 15s khi duoc trang bi
                LoadTime.instance.AddTime(15);
                break;
			case Strings.AVATAR_KAITO:
                //Tang 20% EXp khi duoc trang bi
				GameManager.instance.effectAvatarToExp = 0.2f;
                break;
			case Strings.AVATAR_KIMTAN:
                //Tang 40% EXP khi duoc trang bi
				GameManager.instance.effectAvatarToExp = 0.4f;
                break;
			case Strings.AVATAR_LEN:
                //Tang 60% EXP khi duoc trang bi
				GameManager.instance.effectAvatarToExp = 0.6f;
                break;
			case Strings.AVATAR_LUFFY:
                //Tang 30% luong gold trong moi man choi
				GameManager.instance.effectAvatarToGold = 0.3f;
                break;
			case Strings.AVATAR_LUKA:
                ///Tang 50% luong gold sau moi man choi
				GameManager.instance.effectAvatarToGold = 0.5f;
                break;
			case Strings.AVATAR_MIKU:
                //Bat dau man choi voi 3 quan dac biet
				//Kiem tra boardgame da duoc tao chua
				if(BoardManager.instance.listBlocks == null)
					BoardManager.instance.BoardInit ();
				//Neu tao roi thi ramdom
				
				int row, col;
				row = Random.Range(0, 7);
				col = Random.Range(0, 7);
				BoardManager.instance.CreateRandomBlock(row, col, BlockType.Bird);
				
				while (true)
				{
					row = Random.Range(0, 7);
					col = Random.Range(0, 7);
					if (BoardManager.instance.GetBlock(row, col) != null)
						continue;
					BoardManager.instance.CreateRandomBlock(row, col, BlockType.Puppy);
					break;
				}
				
				while (true)
				{
					row = Random.Range(0, 7);
					col = Random.Range(0, 7);
					if (BoardManager.instance.GetBlock(row, col) != null)
						continue;
					BoardManager.instance.CreateRandomBlock(row, col, BlockType.Bunny);
					break;
				}
                break;

			case Strings.AVATAR_NAMI:
                //Bat dau tu 500.000d
                ScoreCalculator.instance.SetScore(500000);
                break;
			case Strings.AVATAR_RIN:
                //Bo 1 loai quan khi bat dau choi
				int id;
				do {
					id  = Random.Range(0, BlockMaker.instance.listBlocks.Count);
					
				}while(BlockMaker.instance.listBlocks[id].GetComponent<Block>().type == BlockType.Sun);
					BlockMaker.instance.listBlocks.Remove(BlockMaker.instance.listBlocks[id]);
                break;
			case Strings.AVATAR_ROBIN:
                //Bo 2 loai quan khi bat dau choi
				do {
					id  = Random.Range(0, BlockMaker.instance.listBlocks.Count);
					
				}while(BlockMaker.instance.listBlocks[id].GetComponent<Block>().type == BlockType.Sun);
				BlockMaker.instance.listBlocks.Remove(BlockMaker.instance.listBlocks[id]);
				do {
					id  = Random.Range(0, BlockMaker.instance.listBlocks.Count);
					
				}while(BlockMaker.instance.listBlocks[id].GetComponent<Block>().type == BlockType.Sun);
				BlockMaker.instance.listBlocks.Remove(BlockMaker.instance.listBlocks[id]);
                break;
            default:
                //Khong tac dung gi. Avtar mac dinh
                break;
        }
    }

}
