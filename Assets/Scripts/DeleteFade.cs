using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFade : MonoBehaviour
{
    void Start() {
        Destroy(gameObject, 1f);
    }
}
