using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Flowers : MonoBehaviour
{
    public int Flower = 1; //開花数
    List<int> Condition = new();

    public int GrowSpeed = 15; //成長速度
    public int AddGrowSpeed = 10; //水あげ
    public int Obstacle = 8; //障害
    public int RemoveObstacle = 8; //草取り
    public int seed = 5; //種蒔き

    //牡丹プレハブ
    public GameObject PeonyObj;
    public GameObject PeonyObj_pink;
    public GameObject PeonyObj_purple;

    //アクション毎のエフェクト
    public GameObject Water;
    public GameObject Grass;
    public GameObject Seed;

    public Transform parent;

    GameObject Peony_temp;
    int color;
    int pos_x;
    int pos_y;

    void Start()
    {
        Condition.Add(0); //最初の一輪を追加
    }

    public void Action(int SelectNum)
    {
        //種を蒔く選択時、抽選回数をseedだけ追加
        if (SelectNum == 2)
        {
            for (int i = 0; i < Flower * 5 + seed; i++)
            {
                if (Random.Range(1, 3) == 1) //50%で発芽
                {
                    Condition.Add(0);
                }
            }
        }
        else
        {
            for (int i = 0; i < Flower * 5; i++)
            {
                if (Random.Range(1, 3) == 1)
                {
                    Condition.Add(0);
                }
            }
        }

        //成長判定
        for (int i = 0; i < Condition.Count; i++)
        {
            //水をあげる選択時、GrowSpeedを増加
            if (SelectNum == 0)
            {
                Condition[i] += (GrowSpeed + AddGrowSpeed) * Random.Range(1, 11) - Obstacle * Random.Range(1, 11);
            }
            //草取りをする選択時、Obstacleを削除
            else if (SelectNum == 1)
            {
                Condition[i] += GrowSpeed * Random.Range(1, 11);
            }
            else
            {
                Condition[i] += GrowSpeed * Random.Range(1, 11) - Obstacle * Random.Range(1, 11);
            }
        }

        //Conditionが100以上で開花
        Flower = Condition.Count(num => num >= 100);

        //Conditionがマイナスで枯れる
        Condition.RemoveAll(num => num < 0);

        for (int i = 0; i < Condition.Count; i++)
        {
            Debug.Log(Condition[i]);
        }
        Debug.Log(Flower);
    }

    //各アクションのエフェクト表示
    public void ActiveEffect(int SelectNum)
    {
        switch (SelectNum)
        {
            case 0:
                Water.SetActive(true);
                break;
            case 1:
                Grass.SetActive(true);
                break;
            case 2:
                Seed.SetActive(true);
                break;
        }
    }

    //各アクションのエフェクト非表示
    public void PassiveEffect(int SelectNum)
    {
        switch (SelectNum)
        {
            case 0:
                Water.SetActive(false);
                break;
            case 1:
                Grass.SetActive(false);
                break;
            case 2:
                Seed.SetActive(false);
                break;
        }
    }

    //リザルト表示
    public void Flowering(bool Sound)
    {
        color = Random.Range(1, 4);
        pos_x = Random.Range(0,1000) - 500;
        pos_y = Random.Range(0,300) - 300;
        
        switch(color)
        {
            case 1:
                Peony_temp = Instantiate(PeonyObj, parent);
                break;
            case 2:
                Peony_temp = Instantiate(PeonyObj_pink, parent);
                break;
            case 3:
                Peony_temp = Instantiate(PeonyObj_purple, parent);
                break;
        }
        Peony_temp.transform.position = parent.TransformPoint(new Vector3(pos_x, pos_y, 0));
        
        if(!Sound)
        {
            Peony_temp.GetComponent<AudioSource>().enabled = false;
        }
    }
}
