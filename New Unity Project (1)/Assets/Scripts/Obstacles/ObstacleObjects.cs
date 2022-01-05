using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObstacleObjects : MonoBehaviour
{
    Tween tween;
    [SerializeField] float tweenTime = 4f;
    [SerializeField] float targetValue = -10.45f;
    private int infinityLoop = -1;
    private void Start()
    {
        Crate.KillTweening += Crate_KillTweening;
        tween = transform.DOMoveX(targetValue, tweenTime, false).SetLoops(infinityLoop, LoopType.Yoyo).SetEase(Ease.Linear).OnStepComplete(
           delegate
           {

              //Vector3 localScale = transform.localScale;
              //localScale.x = -localScale.x;
              //transform.localScale = localScale;
              //transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 1.68f, 81.4f), 10 * Time.deltaTime);

          });

    }

    private void Crate_KillTweening()
    {
        tween.Kill();
    }

    private void OnDestroy()
    {
        Crate.KillTweening -= Crate_KillTweening;
    }
}
