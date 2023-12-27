using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInTransition : MonoBehaviour
{
    public float fadeInDuration = 2.0f;
    private CanvasGroup canvasGroup;

    public void StartFadeIn (float fadeTimer) => StartCoroutine (FadeIn (fadeTimer));

    void Start () {
        canvasGroup = GetComponent<CanvasGroup> ();

        if (canvasGroup == null) {
            canvasGroup = gameObject.AddComponent<CanvasGroup> ();
        }

        StartFadeIn (fadeInDuration);
    }

    IEnumerator FadeIn (float fadeTimer = 2f) {
        if (canvasGroup == null) yield break;
        float elapsedTime = 0f;

        while (elapsedTime < fadeTimer) {
            canvasGroup.alpha = 1 - (elapsedTime / fadeTimer);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0;
    }
}
