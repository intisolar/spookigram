
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePadPanelController : PanelController
{
    [SerializeField] private ClueNoteData clueNote;
    [SerializeField] private Transform contentParent;
    [SerializeField] private Button finishButton;

    private string initialNote = " - RECORDATORIO: Voy a anotar mis pistas en este bloc de notas tan práctico, " +
        "la segunda mejor aplicación después de Spookigram.\r\n - Debería investigar el perfil de la víctima. " +
        "Seguramente dejó alguna pista en su última publicación.\r\n - ¿Quiénes son sus amigos más cercanos? Debería " +
        "conversar con algunos de ellos.";
    private List<string> noteIds = new();

    private void Awake()
    {
        finishButton.onClick.AddListener(ResolveCrime);
    }

    private void ResolveCrime()
    {

    }
    public void CreateClueNote(string note, string id)
    {
        if (noteIds.Contains(id))
        {
            return;
        }
        var notePrefab = Instantiate(clueNote, contentParent);
        notePrefab.SetText(note);
        noteIds.Add(id);
    }

    public override void ResetPanelInfo()
    {
        for (int i = contentParent.childCount - 1; i >= 0; i--)
            Destroy(contentParent.GetChild(i).gameObject);
        noteIds.Clear();
        CreateClueNote(initialNote, "initialNote");
    }
}
