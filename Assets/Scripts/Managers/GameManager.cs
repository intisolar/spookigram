using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int KeyClueCount { get => keyClueCount; private set => keyClueCount = value; }

    [SerializeField] private GameObject initPanel;
    [SerializeField] private ProfileObject playerProfile;
    [SerializeField] private int keyClueCount;
    [SerializeField] private List<string> clues = new();

    private void Awake()
    {
        StartSingleton();
    }
    void Start()
    {
        UIManager.Instance.ShowPanel(initPanel);
        AudioManager.instance.Play("Menu");
    }
    private void StartSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    public void SetPlayerName(string newPlayerName)
    {
        playerProfile.SetUserName(newPlayerName);
        AudioManager.instance.Stop("Menu");
        AudioManager.instance.Play("Background");
    }

    public string GetPlayerName()
    {
        return playerProfile.GetUserName();
    }

    public void SetPlayerPicture(int imageId)
    {
        playerProfile.AssignProfilePictureById(imageId);
    }

    public Sprite GetPlayerPicture()
    {
       return playerProfile.GetProfilePicture();
    }

    public Image GetPlayerPictureById(int picId)
    {
        return playerProfile.GetProfilePictureById(picId);
    }

    public void FinishGame(bool isCriminal)
    {
        if(isCriminal)
        {
            if(KeyClueCount >= 2)
            {
                TriggerGoodEnding();
            }
            else
            {
                TriggerBadEnding();
            }
        }
        else
        {
            TriggerVeryBadEnding();
        }
    }

    /// <summary>
    /// Nothing gets resolved
    /// </summary>
    public void TriggerTerribleEnding()
    {
        UIManager.Instance.DeactivateConfirmationPanel();
        UIManager.Instance.ShowPanelByName("TerribleEnding");      
    }

    /// <summary>
    /// The criminal remains free and the innocent is put to jail
    /// </summary>
    public void TriggerVeryBadEnding()
    {
        UIManager.Instance.ShowPanelByName("VeryBadEnding");
        Debug.Log("Final muy malo");

    }
    /// <summary>
    /// The criminal remains free for lack of proof, it does not commit another crime for now
    /// </summary>
    public void TriggerBadEnding()
    {

        UIManager.Instance.ShowPanelByName("BadEnding");
        Debug.Log("Final malo");

    }

    /// <summary>
    /// The criminal is put to jail. You figure what happened to the victim
    /// </summary>
    public void TriggerGoodEnding()
    {

        UIManager.Instance.ShowPanelByName("GoodEnding");
        Debug.Log("Final bueno");

    }

    public void Restart()
    {
        Debug.Log("RestartedGame for user" + playerProfile.GetUserName());
        ResetUserInfo();
        ResetPanelsInfo();

        UIManager.Instance.ShowPanel(initPanel);
        AudioManager.instance.Stop("Background");
        AudioManager.instance.Play("Menu");


    }

    private void ResetPanelsInfo()
    {
        var profileFeed = Object.FindFirstObjectByType<ProfileFeedPanelController>(FindObjectsInactive.Include);
        if (profileFeed != null)
        {
            profileFeed.ResetPanelInfo();
        }

        var profilePic = Object.FindFirstObjectByType<ProfilePicPanelController>(FindObjectsInactive.Include);
        if (profilePic != null)
        {
            profilePic.ResetPanelInfo();
        }

        var loginPanel = Object.FindFirstObjectByType<LoginPanelController>(FindObjectsInactive.Include);
        if (loginPanel != null)
        {
            loginPanel.ResetPanelInfo();
        }

        var notePadPanel = Object.FindFirstObjectByType<NotePadPanelController>(FindObjectsInactive.Include);
        if (notePadPanel != null)
        {
            notePadPanel.ResetPanelInfo();
        }
    }

    private void ResetUserInfo()
    {
        playerProfile.ResetPlayerInfo();
    }

    public void AddClue(string clueId, bool isKeyClue, string clueNote)
    {
        if (clues.Contains(clueId))
        {
            return;
        }

        clues.Add(clueId);
        //UIManager.Instance.
        AddClueToNotes(clueNote, clueId);
        if (isKeyClue)
        {
            KeyClueCount++;
        }
    }

    private void AddClueToNotes(string clueNote, string clueId)
    {
        var notePadPanel = Object.FindFirstObjectByType<NotePadPanelController>(FindObjectsInactive.Include);
        if (notePadPanel != null)
        {
            notePadPanel.CreateClueNote(clueNote, clueId);
        }
    }
}
