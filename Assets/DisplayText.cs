using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TMP_Text displayText;

    public void Display(string text)
    {
        displayText.text = text;
    }
}
