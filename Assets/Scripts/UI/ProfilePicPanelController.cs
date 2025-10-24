using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ProfilePicPanelController : PanelController
{
    [SerializeField] private List<Button> picButtons;
    [SerializeField] private Button continueButton;
    [SerializeField] private TMP_Text userNameTMP;
    private string userName = null;
    private int selectedIndex = -1;

    private void OnEnable()
    {
        if (userName == null)
        {
            string playerName = GameManager.Instance.GetPlayerName();
            userName = string.IsNullOrEmpty(playerName) ? "mapache_anonimo" : playerName;
        }
        Debug.Log($"[ProfileFeedPanel] userName: {userName}");
        if (string.IsNullOrEmpty(userNameTMP.text))
        {
            userNameTMP.text = $"Bienvenido/a {userName}";
        }

        for (int i = 0; i < picButtons.Count; i++)
        {
            int index = i; // Necesario para la lambda
            picButtons[i].onClick.AddListener(() => OnPicSelected(index));
        }

        continueButton.onClick.AddListener(OnContinueButtonClicked);
    }

    private void OnDisable()
    {
        continueButton.onClick.RemoveListener(OnContinueButtonClicked);
    }

    public void OnContinueButtonClicked()
    {
        if (selectedIndex == -1)
        {
            Debug.Log("No profile picture selected");
            return;
        }

        GameManager.Instance.SetPlayerPicture(selectedIndex);

        OnNextButtonClicked();
    }

    private void OnPicSelected(int index)
    {
        selectedIndex = index;
        Debug.Log("selected pic " + selectedIndex);

        for (int i = 0; i < picButtons.Count; i++)
        {
            Transform highlight = picButtons[i].transform.Find("Highlight");
            if (highlight != null)
                highlight.gameObject.SetActive(i == index);
        }
    }

    public override void ResetPanelInfo()
    {
        ResetUserInfo();
        selectedIndex = -1;
    }

    private void ResetUserInfo()
    {
        userName = null;
        userNameTMP.text = null;
    }

    public void RefreshUserInfo()
    {
        string playerName = GameManager.Instance.GetPlayerName();
        userName = string.IsNullOrEmpty(playerName) ? "mapache_anonimo" : playerName;
        userNameTMP.text = $"Bienvenido/a {userName}";
        Debug.Log($"[ProfileFeedPanel] Refrescado con: {userName}");
    }
}
