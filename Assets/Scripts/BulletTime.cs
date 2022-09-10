using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;

public class BulletTime : MonoBehaviour
{
    [SerializeField]PostProcessVolume volume;
    [SerializeField]AudioMixer mixer;
    [SerializeField]AudioSource slowmoIn;
    [SerializeField]AudioSource slowmoOut;
    [SerializeField]AudioSource heartbeat;
    bool isSlow = false;
    Grain g;
    Bloom b;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isSlow) {
            SlowMotionOn();
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift) && isSlow) {
            SlowMotionOff();
        }
    }

    void SlowMotionOn() {
        slowmoIn.Play();
        slowmoOut.Stop();
        heartbeat.Play();
        Time.timeScale = 0.3f;
        mixer.SetFloat("pitch", 0.5f);
        isSlow = true;
        volume.profile.TryGetSettings(out g);
        volume.profile.TryGetSettings(out b);
        g.intensity.value = 1f;
        b.intensity.value = 10f;
    }

    void SlowMotionOff() {
        slowmoOut.Play();
        slowmoIn.Stop();
        heartbeat.Stop();
        Time.timeScale = 1f;
        mixer.SetFloat("pitch", 1f);
        isSlow = false;
        volume.profile.TryGetSettings(out g);
        volume.profile.TryGetSettings(out b);
        g.intensity.value = 0.25f;
        b.intensity.value = 3f;
    }
}
