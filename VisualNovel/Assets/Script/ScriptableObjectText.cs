using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TextScriptableObject", order = 1)]
public class ScriptableObjectText : ScriptableObject
{
    [TextArea (10,30)]
    public string text;
    public string title;
    public ScriptableObjectText nextText1;
    public ScriptableObjectText nextText2;
    public ScriptableObjectText nextText3;
}
