using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public TextMeshProUGUI textGlobal;
    public TextMeshProUGUI textChoice1;
    public TextMeshProUGUI textChoice2;
    public TextMeshProUGUI textChoice3;
    public ScriptableObjectText objectText;

    [SerializeField] private GameObject Button1;
    [SerializeField] private GameObject Button2;
    [SerializeField] private GameObject Button3;
    [SerializeField] private GameObject ButtonEnd;

    private int _index = 0;
    [SerializeField] private float _speedText;

    private List<Vector3> initPos = new();

    [SerializeField] private Image _backGround;
    void Start()
    {
        _backGround.sprite = objectText.backGround;
        StartCoroutine(SetSize(objectText.text));
        textChoice1.text = objectText.nextText1.title;

        initPos.Add(Button1.transform.position);
        initPos.Add(Button2.transform.position);
        ShowButton();
    }

    IEnumerator SetSize(string objectText)
    {
        float size = 0.0f;
        textGlobal.enableAutoSizing = true;
        textGlobal.text = objectText;
        yield return new WaitForNextFrameUnit();
        size = textGlobal.fontSize;
        textGlobal.enableAutoSizing = false;
        textGlobal.fontSize = size;
        textGlobal.text = "";
        StartCoroutine(AnimationText(objectText));
    }


    IEnumerator AnimationText(string objectText)
    {
        
        yield return new WaitForSeconds(_speedText);
        if (textGlobal.text != objectText)
        {
            textGlobal.text += objectText[_index];
            _index++;
            StartCoroutine(AnimationText(objectText));
        }
    }

    public void NextText1()
    {
        if (objectText.nextText1 != null)
        {
            StopAllCoroutines();
            _index = 0;
            textGlobal.text = "";
            objectText = objectText.nextText1;
            RefreshText();
            ShowButton();
            StartCoroutine(SetSize(objectText.text));
        }
    }

    public void NextText2()
    {
        if (objectText.nextText2 != null)
        {
            StopAllCoroutines();
            _index = 0;
            textGlobal.text = "";
            objectText = objectText.nextText2;
            RefreshText();
            ShowButton();
            StartCoroutine(SetSize(objectText.text));
        }
    }

    public void NextText3()
    {
        if (objectText.nextText3 != null)
        {
            StopAllCoroutines();
            _index = 0;
            textGlobal.text = "";
            objectText = objectText.nextText3;
            RefreshText();
            ShowButton();
            StartCoroutine(SetSize(objectText.text));
        }
    }

    public void RefreshText()
    {
        _backGround.sprite = objectText.backGround;
        if (objectText.nextText1 != null)
            textChoice1.text = objectText.nextText1.title;
        else
            textChoice1.text = "";
        if (objectText.nextText2 != null)
            textChoice2.text = objectText.nextText2.title;
        else
            textChoice2.text = "";
        if (objectText.nextText3 != null)
            textChoice3.text = objectText.nextText3.title;
        else
            textChoice3.text = "";
    }
    private void ShowButton()
    {
        ResetPosButton();
        if (objectText.nextText3 == null && objectText.nextText2 == null && objectText.nextText1 == null)
        {
            Button1.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);
            PlayerPrefs.SetInt("Fin " + objectText.end.ToString(), 1);
            ButtonEnd.SetActive(true);        }
        else if (objectText.nextText3 == null && objectText.nextText2 == null)
        {
            Button3.SetActive(false);
            Button2.SetActive(false);
        }
        else if (objectText.nextText3 == null)
        {
            Button3.SetActive(false);
        }
    }

    private void ResetPosButton()
    {
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
