using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsWindow;
    [SerializeField] private GameObject _archiveWindow;
    public void StartGame()
    {
        SceneManager.LoadScene("SceneLucasDarpeix");
    }
    public void Option()
    {
        _settingsWindow.SetActive(true);
    }
    public void CloseOption()
    {
        _settingsWindow.SetActive(false);
    }
    public void Archive()
    {
        _archiveWindow.SetActive(true);
    }
    public void CloseArchive()
    {
        _archiveWindow.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
