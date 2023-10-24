using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip Select;
    [SerializeField] AudioClip Decision;
    [SerializeField] AudioClip Result;
    [SerializeField] AudioClip Water;
    [SerializeField] AudioClip Grass;
    [SerializeField] AudioClip Seed;

    public void SelectSound()
    {
        audioSource.PlayOneShot(Select);
    }

    public void DecisionSound()
    {
        audioSource.PlayOneShot(Decision);
    }

    public void ResultSound()
    {
        audioSource.PlayOneShot(Result);
    }

    public void ActionSound(int num)
    {
        switch (num)
        {
            case 0:
                audioSource.PlayOneShot(Water);
                break;
            case 1:
                audioSource.PlayOneShot(Grass);
                break;
            case 2:
                audioSource.PlayOneShot(Seed);
                break;
        }
    }
}
