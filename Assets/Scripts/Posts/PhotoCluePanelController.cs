using UnityEngine;
using UnityEngine.UI;

public class PhotoCluePanelController : PanelController
{
    [SerializeField] public GameObject clue;
    [SerializeField] private string clueId;
    [SerializeField] private Button sendClueButton;
    [SerializeField] private bool isKeyClue;
    [SerializeField] private string clueNote;

    public string ClueId { get => clueId; private set => clueId = value; }

    private void Awake()
    {
        ClueId = clue.name;
        sendClueButton.onClick.AddListener(AddClue);
    }

    private void AddClue()
    {
        GameManager.Instance.AddClue(clueId, isKeyClue, clueNote);
    }
}
