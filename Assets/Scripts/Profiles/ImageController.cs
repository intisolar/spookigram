using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Image> GetAllChildrenImages()
    {
        Transform transform = gameObject.transform;
        List<Image> images = new List<Image>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.TryGetComponent(out Image img))
            {
                images.Add(img);
            }
        }
        return images;
    }
}
