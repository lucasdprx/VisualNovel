using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndImage : MonoBehaviour
{
    [SerializeField] private List<Image> _imageEnd = new();

    private void Start()
    {
        SetImageEnd();
    }

    public void SetImageEnd()
    {
        for (int i = 0; i < _imageEnd.Count; i++)
        {
            if (PlayerPrefs.GetInt("Fin " + (i + 1).ToString()) == 1)
            {
                _imageEnd[i].color = Color.white;
            }
            else
            {
                _imageEnd[i].color = Color.black;
            }
        }
    }

    public void ResetEnd()
    {
        for (int i = 0; i < _imageEnd.Count; i++)
        {
            PlayerPrefs.SetInt("Fin " + (i + 1).ToString(), 0);
        }
        SetImageEnd();
    }
}
