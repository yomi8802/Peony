using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Navigation : MonoBehaviour
{
    public TextMeshProUGUI NaviText;

    //開始時テキスト
    public void BeggingText() 
    {
        NaviText.text = "牡丹だ！　一週間お世話していっぱい増やそう！";
    }

    //各日テキスト
    public void DailyText()
    {
        NaviText.text = "きょうはなにをしよう？";
    }

    //テキスト非表示
    public void ResetText()
    {
        NaviText.text = "";
    }

    public void RainyText()
    {
        NaviText.text = "雨だ！";
    }
}
