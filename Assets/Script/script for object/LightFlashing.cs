using UnityEngine;

public class LightFlashing : MonoBehaviour
{
    public Light flashingLight;
    public float flashInterval = 0.5f; // in seconds

    private float timeSinceLastFlash = 0f;
    private bool lightOn = true;

    void Update()
    {
        // Update the time since the last flash
        timeSinceLastFlash += Time.deltaTime;

        // If enough time has passed, toggle the light
        if (timeSinceLastFlash >= flashInterval)
        {
            timeSinceLastFlash = 0f;
            lightOn = !lightOn;
            flashingLight.enabled = lightOn;
        }
    }
}
