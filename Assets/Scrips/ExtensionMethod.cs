using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class ExtensionMethod
{
    public static void SetButtonText(this GameObject button, string text)
    {
        if (button.transform.GetChild(0).TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI tmpText))
        {
            tmpText.SetText(text);
        }
    }
    public static string GetButtonText(this GameObject button)
    {
        if (button.transform.GetChild(0).TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI tmpText))
        {
            return tmpText.GetText();
        }
        else
        {
            return "";
        }
    }
    public static void SetText(this TextMeshProUGUI textMeshProUGUI, string text)
    {
        textMeshProUGUI.text = text;
    }
    public static string GetText(this TextMeshProUGUI textMeshProUGUI)
    {
        return textMeshProUGUI.text;
    }
}
