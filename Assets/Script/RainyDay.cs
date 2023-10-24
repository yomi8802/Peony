using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainyDay : MonoBehaviour
{
    [SerializeField] GameObject Cat_Obj;
    [SerializeField] GameObject Cat_Rain_Obj;
    [SerializeField] GameObject Rain;
    [SerializeField] GameObject Gray;

    public void RainCat()
    {
        Cat_Obj.SetActive(false);
        Cat_Rain_Obj.SetActive(true);
        Rain.SetActive(true);
        Gray.SetActive(true);
    }

    public void SunnyCat()
    {
        Cat_Obj.SetActive(true);
        Cat_Rain_Obj.SetActive(false);
        Rain.SetActive(false);
        Gray.SetActive(false);
    }
}
