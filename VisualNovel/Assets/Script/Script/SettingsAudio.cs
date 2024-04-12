using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsAudio : MonoBehaviour
{
    public AudioMixer _audioMixer;
    public Slider _SFXSound;

    private void Start()
    {
        if (PlayerPrefs.GetInt("SaveSFX") == 1)
        {
            _SFXSound.value = PlayerPrefs.GetFloat("SFX");
        }
        _audioMixer.SetFloat("SFX", _SFXSound.value);
    }
    public void SetVolumeSound(float volume)
    {
        _audioMixer.SetFloat("SFX", volume);
    }
}