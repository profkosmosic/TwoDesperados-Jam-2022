using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSway : MonoBehaviour
{
    [SerializeField]float swayAmount;
    [SerializeField]float maxSwayAmount;
    [SerializeField]float smoothAmount;
    Vector3 startPos;

    void Start() {
        startPos = transform.localPosition;
    }

    void Update() {
        float movementX = -Input.GetAxis ("Mouse X") * swayAmount;
        float movementY = -Input.GetAxis ("Mouse Y") * swayAmount;
        movementX = Mathf.Clamp(movementX, -maxSwayAmount, maxSwayAmount);
        movementY = Mathf.Clamp(movementY, -maxSwayAmount, maxSwayAmount);

        Vector3 finalPos = new Vector3(movementX, movementY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPos + startPos, Time.deltaTime * smoothAmount);
    }
}
