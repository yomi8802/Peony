using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTitle : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(this.gameObject);
        }
    }
}
