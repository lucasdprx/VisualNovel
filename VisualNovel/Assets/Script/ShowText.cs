using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private int _index = 0;
    [SerializeField] private float _speedText;

    private List<Vector3> initPos = new();
    void Start()
    {
        textGlobal.text = objectText.text;
        textChoice1.text = objectText.nextText1.title;

        initPos.Add(Button1.transform.position);
        initPos.Add(Button2.transform.position);
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
            StartCoroutine(AnimationText(objectText.text));
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
            StartCoroutine(AnimationText(objectText.text));
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
            StartCoroutine(AnimationText(objectText.text));
        }
    }

    public void RefreshText()
    {
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
        }
        else if (objectText.nextText3 == null && objectText.nextText2 == null)
        {
            Button3.SetActive(false);
            Button2.SetActive(false);
        }
        else if (objectText.nextText3 == null)
        {
            Button3.SetActive(false);
            Button2.transform.position += new Vector3((Button1.transform.position.x - Button2.transform.position.x) / 2, 0, 0);
            Button1.transform.position += new Vector3((Button3.transform.position.x - Button1.transform.position.x) / 2, 0, 0);
        }
    }

    private void ResetPosButton()
    {
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);

        Button1.transform.position = initPos[0];
        Button2.transform.position = initPos[1];
    }
}
