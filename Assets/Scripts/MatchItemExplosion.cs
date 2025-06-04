using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MatchItemExplosion : MonoBehaviour
{
    [SerializeField] SpriteRenderer tntSprite;
    [SerializeField] SpriteRenderer tntShadowSprite;
    [SerializeField] ParticleSystem tntVfx;
    [SerializeField] float timeing;
    [SerializeField] List<SpriteRenderer> explosionEffects;


    private void Start()
    {
        StartCoroutine(OnClick());
    }


    IEnumerator OnClick()
    {
        yield return new WaitForSeconds(1);


        yield return new WaitForSeconds(1);
        tntVfx.Play();
        tntSprite.enabled = false;
        tntShadowSprite.enabled = false;

        yield return new WaitForSeconds(timeing);

        foreach (var effect in explosionEffects)
        {
            effect.enabled = false;
            if (effect.GetComponentInChildren<ParticleSystem>())
            {
                effect.GetComponentInChildren<ParticleSystem>().Play();
            }
        }
    }
}
