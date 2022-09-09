using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BulletTime : MonoBehaviour
{
    [SerializeField]PostProcessVolume volume;
    [SerializeField]AudioSource gunshot;
    [SerializeField]AudioSource damage;
    bool isSlow = false;
    Grain g;
    Bloom b;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isSlow) {
            Time.timeScale = 0.3f;
            gunshot.pitch = 0.5f;
            damage.pitch = 0.5f;
            isSlow = true;
            volume.profile.TryGetSettings(out g);
            volume.profile.TryGetSettings(out b);
            g.intensity.value = 1f;
            b.intensity.value = 10f;

        }
        else if(Input.GetKeyDown(KeyCode.LeftShift) && isSlow) {
            Time.timeScale = 1f;
            gunshot.pitch = 1f;
            damage.pitch = 1f;
            isSlow = false;
            volume.profile.TryGetSettings(out g);
            volume.profile.TryGetSettings(out b);
            g.intensity.value = 0.25f;
            b.intensity.value = 3f;
        }
    }
}
