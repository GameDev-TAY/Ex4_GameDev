using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    Transform Player;

    // Update is called once per frame
    void Update()
    {
        if(Player==null){
            GameObject Go = GameObject.Find("PlayerSpaceship");
            if (Go != null){
                Player = Go.transform;
            }
        }

        if (Player == null) return;

        Vector3 dir = Player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
    }
}
