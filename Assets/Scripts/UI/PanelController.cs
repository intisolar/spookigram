using UnityEngine;

public class PanelController : MonoBehaviour
{

    [SerializeField] protected GameObject nextPanel;
    [SerializeField] protected GameObject previousPanel;

    public void OnBackButtonClicked()
    {
        if (previousPanel != null)
        {
            UIManager.Instance.ShowPanel(previousPanel);
        }
    }

    public void OnNextButtonClicked()
    {
        if (nextPanel != null)
            UIManager.Instance.ShowPanel(nextPanel);
    }

    public GameObject GetPreviousPanel()
    {
        return previousPanel;
    }

    public virtual void ResetPanelInfo()
    {
        Debug.LogWarning("WARNING: This should be handled by the children.");
    }
}
