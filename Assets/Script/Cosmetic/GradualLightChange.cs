using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GradualLightChange : MonoBehaviour
{
    public Color targetColor = Color.red;
    public float targetIntensity = 1f;
    public float duration = 5f;

    private void Start () {
        if (GlobalLight.instance == null) return;
        StartCoroutine (ChangeLightProperties ());
    }

    private IEnumerator ChangeLightProperties () {
        Light2D light2D = GlobalLight.instance;
        float timeElapsed = 0f;
        Color initialColor = light2D.color;
        float initialIntensity = light2D.intensity;

        while (timeElapsed < duration) {
            light2D.color = Color.Lerp (initialColor, targetColor, timeElapsed / duration);
            light2D.intensity = Mathf.Lerp (initialIntensity, targetIntensity, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        light2D.color = targetColor;
        light2D.intensity = targetIntensity;
    }
}
