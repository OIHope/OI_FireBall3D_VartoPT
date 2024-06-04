using TMPro;
using UnityEngine;

public class ActionSetText : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private TextMeshProUGUI textToChange;

    public void ChangeText()
    {
        textToChange.text = text;
    }
}
