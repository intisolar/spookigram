using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private List<GameObject> panels;
    [SerializeField] private GameObject confirmationPanel;
    [SerializeField] private GameObject notificationPanel;
    public static UIManager Instance { get; private set; }

    private GameObject currentPanel;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ShowPanel(GameObject targetPanel)
    {

        // Desactiva todos
        foreach (var panel in panels)
            panel.SetActive(false);

        // Activa solo el indicado
        targetPanel.SetActive(true);
        currentPanel = targetPanel;
        AudioManager.instance.Play("Click");

        //var profileFeedController = targetPanel.GetComponent<ProfileFeedPanelController>();
        //if (profileFeedController != null)
        //{
        //    profileFeedController.RefreshUserInfo(); 
        //}
    }

    public void ShowPanelByName(string panelName)
    {
        foreach (var panel in panels)
        {
            bool isTarget = panel.name == panelName;
            panel.SetActive(isTarget);

            if (isTarget)
                currentPanel = panel;
        }
    }

    public GameObject GetCurrentPanel() => currentPanel;

    public void ActivateConfirmationPanel(string message)
    {
        confirmationPanel.SetActive(true);
        confirmationPanel.GetComponent<ConfirmationPanelController>().SetTMPMessage(message);

    }

    public void DeactivateConfirmationPanel()
    {
        confirmationPanel.SetActive(false);
    }
}
