using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image _image;
    private bool _animation;
    [SerializeField] private float _speed;

    public static FadeOut Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void StartAnimation()
    {
        Time.timeScale = 1.0f;
        _image.gameObject.SetActive(true);
        _animation = true;
    }

    private void Update()
    {

        if (_animation)
        {
            if (_image.color.a < 1)
            {
                _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, _image.color.a + Time.deltaTime * _speed);
            }
            else
            {
                _animation = false;
                if (MenuManager.Instance != null)
                    MenuManager.Instance.StartGame();
                else
                    SceneManager.LoadScene("SceneLucasDarpeix");
            }
        }
    }
}
