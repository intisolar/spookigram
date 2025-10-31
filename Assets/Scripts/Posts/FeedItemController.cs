using UnityEngine;
using UnityEngine.UI;

public class FeedItemController : MonoBehaviour
{
    [SerializeField] private Button zoom;
    [SerializeField] private GameObject nextPanel;

    private void Start()
    {
        zoom.onClick.AddListener(ZoomIn);
    }

    private void ZoomIn()
    {
        if (nextPanel != null)
            UIManager.Instance.ShowPanel(nextPanel);
    }
}
