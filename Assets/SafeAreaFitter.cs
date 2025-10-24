using UnityEngine;

[ExecuteAlways]
public class SafeAreaFitter : MonoBehaviour
{
    RectTransform _rt;
    Rect _lastSafe;

    void OnEnable()
    {
        _rt = GetComponent<RectTransform>();
        Apply();
    }

    void Update()
    {
        if (Application.isEditor) Apply(); // actualizar en editor al cambiar device sim
    }

    void Apply()
    {
        var safe = Screen.safeArea;
        if (safe == _lastSafe) return;
        _lastSafe = safe;

        Vector2 anchorMin = safe.position;
        Vector2 anchorMax = safe.position + safe.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        _rt.anchorMin = anchorMin;
        _rt.anchorMax = anchorMax;
        _rt.offsetMin = Vector2.zero;
        _rt.offsetMax = Vector2.zero;
    }
}
