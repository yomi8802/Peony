using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectAction : MonoBehaviour
{
    public GameManager gameManager;
    public AudioManager audioManager;
    public TextMeshProUGUI FirstText;
    public TextMeshProUGUI SecondText;
    public TextMeshProUGUI ThirdText;
    
    int Selected = 0;

    void Update()
    {
        //フェード中無効
        if(gameManager.Fading || !gameManager.Starting)
        {
            return;
        }

        //左右矢印で選択
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Selected++;
            audioManager.SelectSound();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Selected--;
            audioManager.SelectSound();
        }

        //0,2に限定してSelectnumに設定
        Selected = Mathf.Clamp(Selected, 0, 2);
        gameManager.SelectNum = Selected;

        //色を白に初期化
        FirstText.color = Color.white;
        SecondText.color = Color.white;
        ThirdText.color = Color.white;

        //選択しているテキストを青に変色
        switch(gameManager.SelectNum)
        {
            case 0:
                FirstText.color = Color.blue;
                break;
            case 1:
                SecondText.color = Color.blue;
                break;
            case 2:
                ThirdText.color = Color.blue;
                break;
        }
    }

    //選択されなかったテキストを非表示
    public void SelectedText(int num)
    {
        switch(num)
        {
            case 0:
                SecondText.gameObject.SetActive(false);
                ThirdText.gameObject.SetActive(false);
                break;
            case 1:
                FirstText.gameObject.SetActive(false);
                ThirdText.gameObject.SetActive(false);
                break;
            case 2:
                FirstText.gameObject.SetActive(false);
                SecondText.gameObject.SetActive(false);
                break;

        }
    }

    //テキスト表示
    public void ActiveText()
    {
        FirstText.gameObject.SetActive(true);
        SecondText.gameObject.SetActive(true);
        ThirdText.gameObject.SetActive(true);
    }

    //テキスト非表示
    public void PassiveText()
    {
        FirstText.gameObject.SetActive(false);
        SecondText.gameObject.SetActive(false);
        ThirdText.gameObject.SetActive(false);
    }
}
