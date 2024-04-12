using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private GameObject _archiveWindow;

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
        SceneManager.LoadScene("SceneLucasDarpeix");
    }
    public void Option()
    {
        _settingsWindow.SetActive(true);
        DisableButton(false);
    }
    public void CloseOption()
    {
        _settingsWindow.SetActive(false);
        DisableButton(true);
    }
    public void Archive()
    {
        _archiveWindow.SetActive(true);
        DisableButton(false);
    }
    public void CloseArchive()
    {
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
