using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FlowerText : MonoBehaviour
{
    int result = 0;
    int temp = 0;
    public Flowers flowers;
    public AudioManager audioManager;
    public TextMeshProUGUI Text;
    float frame;
    void Start()
    {
        DOTween.To(() => result, (x) => result = x, flowers.Flower + 1, 3).SetEase(Ease.OutExpo);
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = result + "牡丹";
        if(temp != result && result > 1)
        {
            if(frame == 0)
            {
                flowers.Flowering(true);
                frame = Time.frameCount;
            }
            else if(frame + 10f >= Time.frameCount)
            {
                flowers.Flowering(false);
            }
            else
            {
                flowers.Flowering(true);
                frame = Time.frameCount;
            }
            temp = result;
        }
    }
}
