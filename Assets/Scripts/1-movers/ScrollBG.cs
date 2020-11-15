using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        Material mat = GetComponent<MeshRenderer>().material;
        Vector2 offset = mat.mainTextureOffset;
        offset.y += Time.deltaTime*speed;
        mat.mainTextureOffset = offset;
    }
}
