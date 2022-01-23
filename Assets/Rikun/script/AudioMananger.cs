using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMananger : MonoBehaviour
{

    [SerializeField]
    private AudioSource background, selected, clicked;

    public void playSelectedSound()
    {
        selected.Play();
    }

    public void playclickedSound()
    {
        clicked.Play();
    }

    public void mute(bool state)
    {
        background.enabled = !state;
        selected.enabled = !state;
        clicked.enabled = !state;
    }
}
