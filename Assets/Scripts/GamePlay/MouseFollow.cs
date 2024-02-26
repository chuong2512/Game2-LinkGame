using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour
{

    public float distance = 10;
    public ParticleSystem effect;
    // Use this for initialization
    void Start()
    {
        effect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            effect.Play();
        }
        if (Input.GetMouseButton(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 pos = r.GetPoint(distance);
            transform.position = pos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            effect.Stop();
        }
    }
}
