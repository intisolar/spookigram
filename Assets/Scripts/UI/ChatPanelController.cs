using System.Collections.Generic;
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
    [Header("Prefab & Parent")]
    [SerializeField] private ChatBubble messageLeftPrefab;
    [SerializeField] private ChatBubble messageRightPrefab;
    [SerializeField] private Transform contentParent;
    [SerializeField] private ClueNoteButtonController clueNoteButton;
    private List<string> cluesGot = new();
    public string ResourcesPath { get => resourcesPath; set => resourcesPath = value; }
    public string UserName { get => friendUserName; set => friendUserName = value; }

    public void SetPortraitLeft(Sprite s) { if (portraitLeft) portraitLeft.sprite = s; }
    public void SetPortraitRight(Sprite s) { if (portraitRight) portraitRight.sprite = s; }

    public void SetText(string text) { if (textTMP) textTMP.text = text; }

    public void SetTitlePanel()
    {
        textTMP.text = "Conversación con " + friendUserName;
    }

    private void OnDisable()
    {
        ResetPanelInfo();
    }

    public void LoadDialogue()
    {
        TextAsset json = Resources.Load<TextAsset>(resourcesPath);
        if (!json)
        {
            Debug.LogWarning($"No se encontró {resourcesPath}.json en Resources.");
            return;
        }

        Dialogue dialogue = JsonUtility.FromJson<Dialogue>(json.text);
        if (dialogue == null || dialogue.lines == null || dialogue.lines.Length == 0)
            Debug.LogError("JSON inválido o sin líneas.");
        CreateBubbles(dialogue);
    }

    private void CreateBubbles(Dialogue dialogue)
    {
        DialogueLine[] lines = dialogue.lines;

        foreach (var line in lines)
        {
            if (line.speaker == dialogue.layout.L)
            {
                var leftPrefab = Instantiate(messageLeftPrefab, contentParent);
                leftPrefab.SetText(line.text);
            }
            else if (line.speaker == dialogue.layout.R)
            {
                var rightPrefab = Instantiate(messageRightPrefab, contentParent);
                rightPrefab.SetText(line.text);
            }
            else
            {
                Debug.LogWarning("wrong speaker name or mapping.");
            }
        }
        CreateClueButton(dialogue.clue, dialogue.id);
    }

    private void CreateClueButton(string clue, string id)
    {
       if ( cluesGot.Contains(id)) return;
        var item = Instantiate(clueNoteButton, contentParent);
        item.Id = id;
        item.ClueNote = clue;

    }

    public override void ResetPanelInfo()
    {
        ClearPreFabChatBubblesFromParent();
        ResourcesPath = "";
        cluesGot.Clear();
    }

    private void ClearPreFabChatBubblesFromParent()
    {
        for (int i = contentParent.childCount - 1; i >= 0; i--)
            Destroy(contentParent.GetChild(i).gameObject);
    }
}
