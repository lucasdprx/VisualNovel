using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private GameObject _archiveWindow;
    [SerializeField] private Slider _sliderSFX;

    [SerializeField] private List<GameObject> _button = new();
    [SerializeField] private GameObject _title;

    [SerializeField] private Toggle _toggleFullScreen;

    public static MenuManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _toggleFullScreen.isOn = Screen.fullScreen;
    }
    public void StartGame()
    {
        PlayerPrefs.SetFloat("SFX", _sliderSFX.value);
        SceneManager.LoadScene("SceneLucasDarpeix");
    }
    public void Option()
    {
        AudioManager.Instance.PlaySong("Button");
        _settingsWindow.SetActive(true);
        DisableButton(false);
    }
    public void CloseOption()
    {
        AudioManager.Instance.PlaySong("Button");
        _settingsWindow.SetActive(false);
        DisableButton(true);
    }
    public void Archive()
    {
        AudioManager.Instance.PlaySong("Button");
        _archiveWindow.SetActive(true);
        DisableButton(false);
    }
    public void CloseArchive()
    {
        AudioManager.Instance.PlaySong("Button");
        _archiveWindow.SetActive(false);
        DisableButton(true);
    }
    public void Quit()
    {
        Application.Quit();
    }

    private void DisableButton(bool enable)
    {
        for (int i = 0; i < _button.Count; i++)
        {
            _button[i].SetActive(enable);
        }
        _title.SetActive(enable);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
