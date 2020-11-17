using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    [Tooltip("Movement of star material in meters per second")] [SerializeField] float speed = 0.1f;
    
    // move the stars by changing the offset of the texture material.
    // Update is called once per frame
    void Update()
    {
        Material mat = GetComponent<MeshRenderer>().material;
        Vector2 offset = mat.mainTextureOffset;
        offset.y += Time.deltaTime*speed;
        mat.mainTextureOffset = offset;
    }
}
