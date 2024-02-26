using UnityEngine;
using System.Collections;

public class BirdEffect : MonoBehaviour
{

    public Block target;
    public System.Action<BirdEffect> onDestroy;
    private float speed = 2.0f;
    bool runable = false;

    void Update()
    {
        if (target != null && Vector3.Distance(transform.position, target.transform.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);
        }
        else
        {
            onDestroy(this);
            Destroy(gameObject);
        }
    }
}
