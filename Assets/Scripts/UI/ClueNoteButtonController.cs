using UnityEngine;

public class ClueNoteButtonController : MonoBehaviour
{
    private string id;
    private string clueNote;

    public string Id { get => id; set => id = value; }
    public string ClueNote { get => clueNote; set => clueNote = value; }

    public void AddClueToNotes()
    {
        var notePadPanel = Object.FindFirstObjectByType<NotePadPanelController>(FindObjectsInactive.Include);
        if (notePadPanel != null)
        {
            notePadPanel.CreateClueNote(ClueNote, Id, true);
        }
    }


}
