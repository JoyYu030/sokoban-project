using UnityEngine;

public class LightHueCycle : MonoBehaviour
{
    public float speed = 0.2f;

    private Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        float hue = Mathf.Repeat(Time.time * speed, 1f);
        Color color = Color.HSVToRGB(hue, 1f, 1f);

        myLight.color = color;
    }
}