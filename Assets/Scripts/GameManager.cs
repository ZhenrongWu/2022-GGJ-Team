using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private Button     _btnRestart;

    [Header("Audio")] [SerializeField] private AudioSource _audioSourceBGM;
    [SerializeField]                   private AudioSource _audioSourceSFX;
    [SerializeField]                   private AudioClip   _audioClipSelected, _audioClipClick;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        _btnRestart.onClick.AddListener(OnClickRestartButton);
    }

    private void OnClickRestartButton()
    {
        _audioSourceSFX.clip = _audioClipClick;
        _audioSourceSFX.Play();

        StartCoroutine(nameof(IE_Transition));
    }

    private IEnumerator IE_Transition()
    {
        yield return new WaitForSecondsRealtime(.5f);
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

    public void GameOver()
    {
        _menu.SetActive(true);
        _audioSourceBGM.Pause();

        Time.timeScale = 0;
    }
}