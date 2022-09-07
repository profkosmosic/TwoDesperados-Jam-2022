using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController player;
    AudioSource footStep;
    [SerializeField]float speed = 10f;
    [SerializeField]float gravity = -9.81f;
    [SerializeField]float jumpHeight = 3f;
    [SerializeField]Transform groundCheck;
    [SerializeField]float groundDistance = 0.4f;
    [SerializeField]LayerMask groundmask;
    Vector3 velocity;
    bool isGrounded;

    void Start() {
        player = gameObject.GetComponent<CharacterController>();
        footStep = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);
        
        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
            if(isGrounded && !footStep.isPlaying) {
                footStep.volume = Random.Range(0.3f, 0.4f);
                footStep.pitch = Random.Range(0.8f, 1f);
                footStep.Play();
            }
            if(!isGrounded) footStep.Stop();
            if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) footStep.Stop();
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        player.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        player.Move(velocity * Time.deltaTime);
    }
}
