using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2.0f;

    void Update()
    {
        Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowMotion()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
