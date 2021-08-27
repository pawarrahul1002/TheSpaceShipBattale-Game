using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private float scrollSpeed = 4f;
    private float maxDownDistance = -20f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        BGScrolling();
    }


    /*BGScrolling : moving bg down with Translate and taking tranform to startPos after Max down distance */

    void BGScrolling()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        if (transform.position.y < maxDownDistance)
        {
            transform.position = startPos;
        }
    }


}
