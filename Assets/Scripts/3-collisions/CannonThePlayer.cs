using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonThePlayer : MonoBehaviour
{
    [Tooltip("The number of seconds that the Cannon remains active")] [SerializeField] float duration;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")// verify that the collider is the player
        {
            Debug.Log("Cannon triggered by player");
            var ShooterComponent = other.GetComponent<LaserShooter>();
            if (ShooterComponent.enabled) //check if the current status is cannon active.
            {
                ShooterComponent.StartCoroutine(CannonTemporarily(other)); //active the cannon. 
                Destroy(gameObject); // destroy the cannon object.
            }
        }
    }
     
    private IEnumerator CannonTemporarily(Collider2D Player)
    {
        //active the cannon
        Player.GetComponent<LaserShooter>().enabled = false;
        Player.GetComponent<BigLaserShooter>().enabled = true;
        for (float i = duration; i > 0; i--)
        {
            Debug.Log("Cannon: " + i + " seconds remaining!");
            Player.GetComponent<BigLaserShooter>().enabled = true; // if the player will take another Shield it will work for new duration sec counter
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Cannon gone!");
        //disable the cannon
        Player.GetComponent<BigLaserShooter>().enabled = false;
        Player.GetComponent<LaserShooter>().enabled = true;
    }
    
}
