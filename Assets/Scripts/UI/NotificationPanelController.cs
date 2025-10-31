using System.Collections;
using UnityEngine;

public class NotificationPanelController : MonoBehaviour
{

    [SerializeField] float delay = 5f;
    [SerializeField] bool ignoreTimeScale = false;
    Coroutine _co;

    void OnEnable()
    {
        _co = StartCoroutine(ignoreTimeScale ? DisableRealtime() : DisableScaled());
    }

    void OnDisable()
    {
        if (_co != null) StopCoroutine(_co);
    }

    IEnumerator DisableScaled()
    {
        yield return new WaitForSeconds(delay);      // afectado por Time.timeScale
        gameObject.SetActive(false);
    }

    IEnumerator DisableRealtime()
    {
        yield return new WaitForSecondsRealtime(delay); // NO afectado por timeScale
        gameObject.SetActive(false);
    }
}
