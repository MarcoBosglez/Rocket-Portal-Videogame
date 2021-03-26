using UnityEngine;
using UnityEngine.UI;

public class fpsCounter: MonoBehaviour
{
    [Header("FPS Data")]
    private float hudRefreshRate = 1f;
    private float timer;
    public Text fpsText;

    public void Update()
    {
        if (Time.unscaledTime > timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = "FPS: " + fps;
            timer = Time.unscaledTime + hudRefreshRate;
        }
    }

}
