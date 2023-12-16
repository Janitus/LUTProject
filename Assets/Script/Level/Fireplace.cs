using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Fireplace : MonoBehaviour
{
    public Light2D fireLight;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    public float minFlickerDuration = 0.1f;
    public float maxFlickerDuration = 0.5f;

    private float targetIntensity;
    private float flickerDuration;
    private float flickerTimer;

    private void Start () {
        fireLight = GetComponent<Light2D> ();
        SetNewFlickerTarget ();
    }

    private void Update () {
        flickerTimer += Time.deltaTime;
        fireLight.intensity = Mathf.Lerp (fireLight.intensity, targetIntensity, flickerTimer / flickerDuration);
        if (flickerTimer >= flickerDuration) {
            SetNewFlickerTarget ();
        }
    }

    private void SetNewFlickerTarget () {
        targetIntensity = Random.Range (minIntensity, maxIntensity);
        flickerDuration = Random.Range (minFlickerDuration, maxFlickerDuration);
        flickerTimer = 0f;
    }
}
