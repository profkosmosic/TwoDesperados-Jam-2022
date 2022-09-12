using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStop : MonoBehaviour
{
    void Start() {
        if(MusicPlay.Music.gameObject != null) {
            MusicPlay.Music.gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
