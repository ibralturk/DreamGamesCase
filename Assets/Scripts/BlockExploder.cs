using System.Collections;
using UnityEngine;

public class BlockExploder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("*Triggered*");
        if (collision.CompareTag("Bomb"))
        {
            Debug.Log("Triggered");
            StartCoroutine(WaitAndExplode());
        }
    }

    IEnumerator WaitAndExplode()
    {
        GetComponentInChildren<ParticleSystem>().Play();
        yield return new WaitForSeconds(.2f);
        GetComponent<SpriteRenderer>().enabled = false;

    }
}
