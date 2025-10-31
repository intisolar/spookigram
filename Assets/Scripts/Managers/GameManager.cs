using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject initPanel;
    [SerializeField] private ProfileObject playerProfile;
    [SerializeField] private int clues;

    private void Awake()
    {
        StartSingleton();
    }
    void Start()
    {
        UIManager.Instance.ShowPanel(initPanel);
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

    /// <summary>
    /// The criminal remains free and commits another crime
    /// </summary>
    public void TriggerTerribleEnding()
    {
        //post posts
        //4 posts - 2 saying they'll keep doing what they love - 2 more victims ?
        Debug.Log("Final terrible");
        Restart();
    }

    /// <summary>
    /// The criminal remains free and the innocent is put to jail
    /// </summary>
    public void TriggerVeryBadEnding()
    {
        //post posts
        //1 post from the one in jail claiming for justice - 2 more victims ?
        Debug.Log("Final muy malo");

    }
    /// <summary>
    /// The criminal remains free for lack of proof, it does not commit another crime for now
    /// </summary>
    public void TriggerBadEnding()
    {
        //post posts
        //1 post from the criminal saying justing has prevailed and they are preparing to sue
        Debug.Log("Final malo");

    }

    /// <summary>
    /// The criminal is put to jail. You figure what happened to the victim
    /// </summary>
    public void TriggerGoodEnding()
    {
        //post postsaqwspaper
        Debug.Log("Final bueno");

    }

    public void Restart()
    {
        ResetUserInfo();
        ResetPanelsInfo();

        UIManager.Instance.DeactivateConfirmationPanel();
        UIManager.Instance.ShowPanel(initPanel);


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
}
