using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _btnStart;

    [Header("Audio")] [SerializeField] private AudioSource _audioSourceSFX;
    [SerializeField]                   private AudioClip   _audioClipSelected, _audioClipClick;

    private void Start()
    {
        _btnStart.onClick.AddListener(OnClickStartButton);
    }

    private void OnClickStartButton()
    {
        _audioSourceSFX.clip = _audioClipClick;
        _audioSourceSFX.Play();

        Invoke(nameof(Transition), .5f);
    }

    private void Transition()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Pointer Enter
    /// </summary>
    public void PlayAudioClipSelected()
    {
        _audioSourceSFX.clip = _audioClipSelected;
        _audioSourceSFX.Play();
    }
}