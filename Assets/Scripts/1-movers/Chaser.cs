using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [Tooltip("Enemy Chaser speed rotation - degrees per secound")][SerializeField] float rotSpeed = 90f;
    [Tooltip("Enemy Chaser speed movement - meters per secound")] [SerializeField] float maxSpeed = 5f;
    Transform Player; //the Transform commponent of the Player

    // Update is called once per frame
    void Update()
    {
        /**
         * get the Transform commponent of the Player.
         **/
        if (Player==null){
            GameObject Go = GameObject.Find("PlayerSpaceship");
            if (Go != null){
                Player = Go.transform;
            }
        }
        if (Player == null) return;

        /**
         * get the direction of theplayer from the enemy position and face the enemy to this direction.
         **/
        Vector3 dir = Player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion desierdRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desierdRot, rotSpeed * Time.deltaTime);

        /**
         * make the enemy move forword in the Pleyer direction that he face to.
         **/
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(maxSpeed * Time.deltaTime, 0, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
}
