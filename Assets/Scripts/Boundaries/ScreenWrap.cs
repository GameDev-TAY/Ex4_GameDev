using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Vector2 screenBounds;
    private Vector2 objectBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        objectBounds = transform.GetComponent<Renderer>().bounds.size / 2;
        Wrap();
    }

    private void Wrap()
    {
        Vector3 pos = transform.position;
        if (transform.position.x > screenBounds.x + objectBounds.x)
        {
            pos.x = -(screenBounds.x + objectBounds.x);
        }
        if (transform.position.x < -screenBounds.x - objectBounds.x)
        {
            pos.x = screenBounds.x + objectBounds.x;
        }
        if (transform.position.y > screenBounds.y + objectBounds.y)
        {
            pos.y = -(screenBounds.y + objectBounds.y);
        }
        if (transform.position.y < -screenBounds.y - objectBounds.y)
        {
            pos.y = screenBounds.y + objectBounds.y;
        }
        transform.position = pos;
    }
}
