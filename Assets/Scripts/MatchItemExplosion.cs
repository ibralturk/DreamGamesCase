using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MatchItemExplosion : MonoBehaviour
{
    [SerializeField] SpriteRenderer tntSprite;
    [SerializeField] SpriteRenderer tntShadowSprite;
    [SerializeField] ParticleSystem tntVfx;
    [SerializeField] Transform bomb;

    private void Start()
    {
        StartCoroutine(OnClick());
    }

    IEnumerator OnClick()
    {

        yield return new WaitForSeconds(.65f);
        var main = tntVfx.main;
        main.prewarm = true;
        tntVfx.Play();

        tntSprite.enabled = false;
        tntShadowSprite.enabled = false;
       
        bomb.DOScale(Vector3.one * 3, .2f);
        yield return new WaitForSeconds(.25f);
        FindAnyObjectByType<CameraShake>().Shake();

    }
}
