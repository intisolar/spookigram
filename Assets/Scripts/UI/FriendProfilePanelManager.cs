using UnityEngine;

public class FriendProfilePanelManager : MonoBehaviour
{
    public static FriendProfilePanelManager Instance { get; private set; }
    [SerializeField] private GameObject sergioPanelFeed;
    [SerializeField] private GameObject andresPanelFeed;
    [SerializeField] private GameObject gustavoPanelFeed;

    [SerializeField] private ProfileObject sergioProfileObject;
    [SerializeField] private ProfileObject andresProfileObject;
    [SerializeField] private ProfileObject gustavoProfileObject;

    private void Awake()
    {
        StartSingleton();
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

    public void OpenFriendProfile(int id)
    {

        if (id == sergioProfileObject.Id)
        {
            UIManager.Instance.ShowPanel(sergioPanelFeed);
        }
        else if (id == andresProfileObject.Id)
        {
            UIManager.Instance.ShowPanel(andresPanelFeed);
        }
        else if (id == gustavoProfileObject.Id)
        {
            UIManager.Instance.ShowPanel(gustavoPanelFeed);
        }
        else
        {
            Debug.LogWarning("unknown ID in FriendProfilePanelManager.OpenFriendProfile.");
        }
       

    }
}
