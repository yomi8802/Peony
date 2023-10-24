using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource audioManager;
    [SerializeField] AudioSource Rain;

    public Slider slider;

    void Start()
    {
        slider.onValueChanged.AddListener(value => BGM.volume = value);
        slider.onValueChanged.AddListener(value => audioManager.volume = value);
        slider.onValueChanged.AddListener(value => Rain.volume = value);
    }
}
