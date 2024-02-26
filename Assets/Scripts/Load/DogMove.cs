using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DogMove : LoadTime
{
    Rigidbody2D rb;
    public RectTransform bar;
    public float DogSpeed = 10;
    public float barWidth = 0;
    Image barImage;
    public float offsetX = 0;
    //private Vector2 t;
    void Start()
    {
        barWidth = bar.rect.width;
        barImage = bar.GetComponent<Image>();

        UpdatePosition();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector2 pos = transform.localPosition;
        pos.x = (0.5f - barImage.fillAmount) * barWidth - 25;
        transform.localPosition = pos;
    }
}
