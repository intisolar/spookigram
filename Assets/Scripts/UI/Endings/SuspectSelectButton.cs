using UnityEngine;
using UnityEngine.UI;

public class SuspectSelectButton : MonoBehaviour
{
    [SerializeField] private SuspectProfile suspect;
    [SerializeField]
    private Button thisButton;
    private void Awake()
    {
        thisButton.onClick.AddListener(FinishGameWithSelected);
    }
    private void FinishGameWithSelected()
    {
        GameManager.Instance.FinishGame(IsTheCriminal());
    }
    public bool IsTheCriminal()
    {
        return suspect.IsCriminal;
    }
}
