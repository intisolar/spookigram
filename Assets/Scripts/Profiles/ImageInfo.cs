using UnityEngine;

public class ImageInfo : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private string type;
    [SerializeField] private string picName;

    public int Id { get => id; set => id = value; }
    public string Type { get => type; set => type = value; }
    public string Name { get => picName; set => picName = value; }
}
