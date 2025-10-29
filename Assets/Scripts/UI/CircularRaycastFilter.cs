using UnityEngine;
using UnityEngine.UI;

public class CircularRaycastFilter : MonoBehaviour, ICanvasRaycastFilter
{
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        var rt = (RectTransform)transform;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, sp, eventCamera, out var local))
            return false;

        var r = rt.rect;
        float nx = (local.x - r.center.x) / (r.width * 0.5f);
        float ny = (local.y - r.center.y) / (r.height * 0.5f);
        return nx * nx + ny * ny <= 1f; // dentro del círculo
    }
}