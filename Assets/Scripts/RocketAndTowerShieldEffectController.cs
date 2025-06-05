using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAndTowerShieldEffectController : MonoBehaviour
{
    [SerializeField] private Transform rocket1;
    [SerializeField] private Transform rocket2;
    [SerializeField] private Transform rocket1Trail;
    [SerializeField] private Transform rocket2Trail;

    [SerializeField] private Vector3 rocket1Target;
    [SerializeField] private Vector3 rocket2Target;
    [SerializeField] private float rocket1Duration;
    [SerializeField] private float rocket2Duration;

    [SerializeField] List<GameObject> line1;
    [SerializeField] List<GameObject> line2;

    [SerializeField] GameObject towerShield1;
    [SerializeField] GameObject towerShield2;

    [SerializeField] ParticleSystem tower1Explosion;
    [SerializeField] ParticleSystem tower2Explosion;
    void Start()
    {
        StartCoroutine(GameAction());
    }

    void Update()
    {

    }



    IEnumerator GameAction()
    {
        yield return new WaitForSeconds(1f);
        rocket1.DOMove(rocket1Target, rocket1Duration).SetEase(Ease.Linear)
        .OnUpdate(() =>
        {
            rocket1Trail.position = rocket1.position + Vector3.down * .25f;
        })
        .OnComplete(() =>
        {
            StartCoroutine(GameShieldAction1());
        });
        foreach (GameObject block in line1)
        {
            var ps = block.GetComponentInChildren<ParticleSystem>();
            var psm = ps.main;
            psm.prewarm = true;
            ps.Play();
            yield return new WaitForSeconds(0.1f);
            block.GetComponent<SpriteRenderer>().enabled = false;

        }


     

        rocket2.DOMove(rocket2Target, rocket2Duration).SetEase(Ease.Linear)
        .OnUpdate(() =>
        {
            rocket2Trail.position = rocket2.position + Vector3.down * .25f;
        })
        .OnComplete(() =>
        {
            StartCoroutine(GameShieldAction2());
        });
        foreach (GameObject block in line2)
        {
            var ps = block.GetComponentInChildren<ParticleSystem>();
            var psm = ps.main;
            psm.prewarm = true;
            ps.Play();
            yield return new WaitForSeconds(0.1f);
            block.GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    IEnumerator GameShieldAction1()
    {
        var mat = towerShield1.GetComponent<Renderer>().material;
        rocket1.gameObject.SetActive(false);
        tower1Explosion.Play();
        towerShield1.SetActive(true);

        float val1 = 25;
        DOTween.To(() => val1, x => val1 = x, 2.5f, .5f)
        .OnUpdate(() =>
        {
            mat.SetFloat("_FresnelPower", val1);
        });

        float val2 = 0;
        Color startCol = mat.GetColor("_FresnelColor");
        DOTween.To(() => val2, x => val2 = x, 5f, .5f)
        .OnUpdate(() =>
        {
            mat.SetColor("_FresnelColor", startCol * val2);
        });
        float val3 = 0;
        DOTween.To(() => val3, x => val3 = x, 5, .5f).SetEase(Ease.OutSine)
        .OnUpdate(() =>
        {
            mat.SetFloat("_VertexFrequency", val3);
        }).OnComplete(() =>
        {
            DOTween.To(() => val3, x => val3 = x, 0f, .2f).SetEase(Ease.InOutSine)
                   .OnUpdate(() =>
                   {
                       mat.SetFloat("_VertexFrequency", val3);
                   });
        });
        yield return new WaitForSeconds(0.1f);

    }

    IEnumerator GameShieldAction2()
    {
        var mat = towerShield2.GetComponent<Renderer>().material;
        rocket2.gameObject.SetActive(false);
        tower2Explosion.Play();
        towerShield2.SetActive(true);

        float val1 = 25;
        DOTween.To(() => val1, x => val1 = x, 2.5f, .5f)
        .OnUpdate(() =>
        {
            mat.SetFloat("_FresnelPower", val1);
        });

        float val2 = 0;
        Color startCol = mat.GetColor("_FresnelColor");
        DOTween.To(() => val2, x => val2 = x, 5f, .5f)
        .OnUpdate(() =>
        {
            mat.SetColor("_FresnelColor", startCol * val2);
        });
        float val3 = 0;
        DOTween.To(() => val3, x => val3 = x, 5, .5f).SetEase(Ease.OutSine)
        .OnUpdate(() =>
        {
            mat.SetFloat("_VertexFrequency", val3);
        }).OnComplete(() =>
        {
            DOTween.To(() => val3, x => val3 = x, 0f, .2f).SetEase(Ease.InOutSine)
                   .OnUpdate(() =>
                   {
                       mat.SetFloat("_VertexFrequency", val3);
                   });
        });
        yield return new WaitForSeconds(0.1f);

    }
}
