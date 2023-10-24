using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI DayText;  //日付表示テキスト
    public Camera MainCamera;
    public TextMeshProUGUI FlowerText;  //花本数表示テキスト
    public TextMeshProUGUI ExplanationText;
    public Flowers flowers;
    public SelectAction selectAction;
    public Fade fade;
    public Navigation navigation;
    public RainyDay rainyDay;
    public AudioManager audioManager;
    [SerializeField] int Day;  //日数
    public int SelectNum;
    public bool Fading = false;
    public bool Starting = false;
    bool Processing = false;
    bool isEnd = false;
    bool rainy = false;

    void Update()
    {
        //進行
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //ゲーム開始前
            if (!Starting)
            {
                StartCoroutine("Beginning");
            }
            //ゲーム開始後
            else
            {
                StartCoroutine("Next");
            }
            if (isEnd)
            {
                StartCoroutine("ReStart");
            }
        }
    }

    //ゲーム開始処理
    IEnumerator Beginning()
    {
        if (!Processing)  //重複処理対策
        {
            audioManager.DecisionSound();
            Processing = true;
            navigation.BeggingText();  //開始テキスト表示
            yield return new WaitForSeconds(5);
            navigation.ResetText();  //テキスト非表示
            MainCamera.transform.DOMove(new Vector3(0, 0, -10), 1).SetEase(Ease.OutQuart);  //ゲーム画面移動
            yield return new WaitForSeconds(2);
            Day = 1;
            DayText.text = "1日目";
            selectAction.ActiveText();  //選択肢表示
            navigation.DailyText();  //ナビ表示
            Starting = true;
        }
    }

    //日付進行処理
    IEnumerator Next()
    {
        //最終日まで
        if (Day < 8 && !Fading)
        {
            audioManager.DecisionSound();
            Fading = true;  //重複処理対策
            selectAction.SelectedText(SelectNum);
            navigation.ResetText();  //ナビ非表示
            yield return new WaitForSeconds(1);

            flowers.ActiveEffect(SelectNum);  //エフェクト表示
            audioManager.ActionSound(SelectNum);
            yield return new WaitForSeconds(2);

            fade.DoFadeOut();  //フェードアウト
            flowers.PassiveEffect(SelectNum);  //エフェクト非表示
            yield return new WaitForSeconds(2);

            if (rainy)
            {
                flowers.GrowSpeed *= 2;
            }

            flowers.Action(SelectNum);  //成長計算

            if (rainy)
            {
                flowers.GrowSpeed = 10;
                rainyDay.SunnyCat();
                rainy = false;
            }

            Day++;
            DayText.text = Day + "日目";  //日付進行
            selectAction.PassiveText();  //選択肢非表示
            yield return new WaitForSeconds(1);

            if (Day != 8 && Random.Range(1, 10) <= 2)
            {
                rainy = true;
                rainyDay.RainCat();
            }

            fade.DoFadeIn();  //フェードイン
            yield return new WaitForSeconds(2);

            if (Day == 8)
            {
                FlowerText.gameObject.SetActive(true); //リザルト表示
                Invoke("Finish", 3.0f);

            }
            else if (rainy)
            {
                selectAction.ActiveText();
                navigation.RainyText();
            }
            else
            {
                selectAction.ActiveText();
                navigation.DailyText();  //ナビ表示
            }
            Fading = false;
        }
    }

    IEnumerator ReStart()
    {
        audioManager.DecisionSound();
        fade.DoFadeOut();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Finish()
    {
        ExplanationText.text = "zでタイトルに戻る";
        audioManager.ResultSound();
        isEnd = true;
    }
}
