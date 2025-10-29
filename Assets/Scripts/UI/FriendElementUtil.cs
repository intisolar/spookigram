using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FriendElementUtil : MonoBehaviour
{
    [SerializeField] private Image avatarImage;
    [SerializeField] private TMP_Text userNameTMP;
    [SerializeField] private TMP_Text lastMessageSent;

    // Llamalo apenas instancies el item
    public void BindFriend(string userName, Sprite avatarSprite)
    {
        if (userNameTMP != null)
        {
            Debug.Log("Setting friend usernam" + userName);
            userNameTMP.text = userName ?? "usuario_desconocido";
        }

        if (avatarImage != null)
        {
            avatarImage.sprite = avatarSprite;
            avatarImage.enabled = (avatarSprite != null); // si no hay, lo oculto
        }
    }

    public void BindMessage(string userName, string lastMessage, Sprite avatarSprite)
    {
        if (lastMessage != null)
        {
            Debug.Log("Setting last message" + lastMessage);
            lastMessageSent.text = lastMessage ?? "Empieza una conversación con " + userName;
        }

        if (avatarImage != null)
        {
            avatarImage.sprite = avatarSprite;
            avatarImage.enabled = (avatarSprite != null); // si no hay, lo oculto
        }
    }
}
