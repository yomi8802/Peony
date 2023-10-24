using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloweringVolume : MonoBehaviour
{
    GameObject slider;
    void Start()
    {
        slider = GameObject.Find("Slider");
        this.GetComponent<AudioSource>().volume = slider.GetComponent<Slider>().value;
    }
}
