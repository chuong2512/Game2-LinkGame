using UnityEngine;
using System.Collections;

public class BonusText : MonoBehaviour
{

    public TextMesh content;

    public void Open(string message, Vector3 position)
    {
        gameObject.SetActive(false);
        transform.position = position;
        content.text = message;
        gameObject.SetActive(true);
    }

    public void FinishText()
    {
        gameObject.SetActive(false);
    }
}
