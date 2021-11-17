using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class ExtensionMethod
{
    public static void SetButtonText(this Button button, string text)
    {
        button.GetComponent<TextMeshPro>().text = text;
    }
    public static void SetText(this TextMeshProUGUI textMeshProUGUI, string text)
    {
        textMeshProUGUI.text = text;
    }
}
