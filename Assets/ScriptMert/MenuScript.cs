using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MuteAll()
    {
        _audioMixerGroup.audioMixer.SetFloat("General", -80f);
    }
    public void OpenAll()
    {
        _audioMixerGroup.audioMixer.SetFloat("General", -3f);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
