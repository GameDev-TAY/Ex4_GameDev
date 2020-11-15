using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActivate : MonoBehaviour
{
    [SerializeField] GameObject Shield;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shield")
        {
            Renderer ShieldRend = Shield.GetComponent<Renderer>();
            StartCoroutine(FadeOutShield(ShieldRend));
        }
       
    }

    private IEnumerator FadeOutShield(Renderer ShieldR)
    {
        ShieldR.enabled = true;
        for (float i = 1f; i > 0f; i -= 0.01f)
        {
            Color c = ShieldR.material.color;
            c.a = i;
            ShieldR.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

    }
}
