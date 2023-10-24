using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    public RectTransform FadeObject;
    public Transform Canvas;

    //フェードアウト
    public void DoFadeOut()
    {
        FadeObject.DOMove(Canvas.TransformPoint(new Vector3(0, 0, 0)), 2f).SetEase(Ease.OutExpo);
    }

    //フェードイン
    public void DoFadeIn()
    {
        FadeObject.DOMove(Canvas.TransformPoint(new Vector3(0, 1080f, 0)), 2f).SetEase(Ease.InExpo);
    }
}
