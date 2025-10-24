using TMPro;
using UnityEngine;

public class ConfirmationPanelController : MonoBehaviour
{
    [SerializeField] private TMP_Text messageTMP;

    private void OnEnable()
    {
        
    }

    public void SetTMPMessage(string message)
    {
        if (messageTMP != null)
        {
            messageTMP.text = message;
        }
    }

}
