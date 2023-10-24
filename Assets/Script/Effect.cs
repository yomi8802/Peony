using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    //
    void Start()
    {
        StartCoroutine("Self_Destruction");
    }

    IEnumerator Self_Destruction()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }
}
