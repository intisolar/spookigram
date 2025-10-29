using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatPanelController : PanelController
{
    [SerializeField]
    private string resourcesPath;
    [SerializeField] 
    private TMP_Text textTMP;
    [SerializeField]
    private string friendUserName;
    [SerializeField] private Image portraitLeft;
    [SerializeField] private Image portraitRight;
    public string ResourcesPath { get => resourcesPath; set => resourcesPath = value; }
    public string UserName { get => friendUserName; set => friendUserName = value; }

    public void SetPortraitLeft(Sprite s) { if (portraitLeft) portraitLeft.sprite = s; }
    public void SetPortraitRight(Sprite s) { if (portraitRight) portraitRight.sprite = s; }

    public void SetText(string text) { if (textTMP) textTMP.text = text; }


}
