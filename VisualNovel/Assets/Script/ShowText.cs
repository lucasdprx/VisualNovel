using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    public TextMeshProUGUI textGlobal;
    public TextMeshProUGUI textChoice1;
    public TextMeshProUGUI textChoice2;
    public TextMeshProUGUI textChoice3;
    public ScriptableObjectText objectText;
    void Start()
    {
        textGlobal.text = objectText.text;
        textChoice1.text = objectText.nextText1.title;
    }

    public void NextText1()
    {
        if (objectText.nextText1 != null)
        {
            objectText = objectText.nextText1;
            textGlobal.text = objectText.text;
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
    }

    public void NextText2()
    {
        if (objectText.nextText2 != null)
        {
            objectText = objectText.nextText2;
            textGlobal.text = objectText.text;
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
    }

    public void NextText3()
    {
        if (objectText.nextText3 != null)
        {
            objectText = objectText.nextText3;
            textGlobal.text = objectText.text;
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
    }
}
