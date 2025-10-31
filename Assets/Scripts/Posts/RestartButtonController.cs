using UnityEngine;
using UnityEngine.UI;

public class RestartButtonController : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartGame);

    }

    private void RestartGame()
    {
        GameManager.Instance.Restart();
    }
}
