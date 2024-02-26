using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Đề nghị các bạn tuyệt đối không sửa đổi bất kỳ cái gì trong class này trừ khi biết chắc mình làm gì
/// Class này chỉ được phép xử lý GameObject chứ nó và các object con của nó, không gọi bất kỳ cái gì từ bên ngoài
/// Muốn popup làm gì khi tắt thì gán onCloseEvent cho 1 hàm void để xử lý
/// Bạn duypq rút kinh nghiệm nhé
/// </summary>
public class Popup : MonoBehaviour
{
    public System.Action onOpenEvent;
    public System.Action onCloseEvent;

    public Text[] texts;
    public Image[] images;


    public void Open(string[] textContent = null, Sprite[] sprites = null)
    {
        if (texts != null && textContent != null)
        {
            for (int i = 0; i < textContent.Length; i++)
            {
                if (i < texts.Length)
                {
                    texts[i].text = textContent[i];
                }
            }
        }
        if (images != null && sprites != null)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                if (i < sprites.Length)
                {
                    images[i].sprite = sprites[i];
                }
            }
        }
        gameObject.SetActive(true);
        if (onOpenEvent != null)
            onOpenEvent();
        if (SoundManager.instance != null) SoundManager.instance.PlaySFX(SFX.OPEN_DIALOG);
    }

    public void Open(System.Action action, string[] textContent = null, Sprite[] sprites = null)
    {
        onOpenEvent = action;
        Open(textContent, sprites);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        if (onCloseEvent != null)
        {
            onCloseEvent();
        }

    }

    public void Close(System.Action action)
    {
        onCloseEvent = action;
        Close();
    }

	/*public void WTF() {
		UIController.instance.OpenResult ();
	}*/

}
