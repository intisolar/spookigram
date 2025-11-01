using TMPro;
using UnityEngine;

public class ChatBubble: MonoBehaviour
{
    [SerializeField] private TMP_Text textTMP;
    public void SetText(string text) { if (textTMP) textTMP.text = text; }
}
