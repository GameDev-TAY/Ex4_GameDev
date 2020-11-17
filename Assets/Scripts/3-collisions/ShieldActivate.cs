using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This Class make the Shild of the player active and fade it out in 5 secound.
 **/
public class ShieldActivate : MonoBehaviour
{
    [Tooltip("The Shield object")] [SerializeField] GameObject Shield;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shield") //verify that the shield was trigged
        {
            Renderer ShieldRend = Shield.GetComponent<Renderer>();
            StartCoroutine(FadeOutShield(ShieldRend)); //send the render component to the fade out function.
        }
       
    }

    private IEnumerator FadeOutShield(Renderer ShieldR)
    {
        ShieldR.enabled = true; //active the shieldand makrit vissable
        for (float i = 1f; i > 0f; i -= 0.01f) //100 times for fade efect
        {
            Color c = ShieldR.material.color;
            c.a = i;
            ShieldR.material.color = c;//fadeit out
            yield return new WaitForSeconds(0.05f); // wait for 0.05 sec 100 times -> in total -  5 sec
        }

    }
}
