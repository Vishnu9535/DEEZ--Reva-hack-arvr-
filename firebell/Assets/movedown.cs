using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f; // Adjust the speed as needed
    Rigidbody rb;
    bool isMoving = false;
    float movementDuration = 1.0f; // The duration of downward movement in seconds
    float timer = 0.0f;
    AudioSource audioSource; // Reference to the AudioSource component

   void Start()

 {
    rb = GetComponent<Rigidbody>();
    audioSource = GetComponent<AudioSource>(); // Get the AudioSource component on this GameObject
  }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !isMoving)
        {
            StartMoving();
        }

        if (isMoving)
        {
            timer += Time.deltaTime;

            if (timer >= movementDuration)
            {
                StopMoving();
            }
        }
    }

    void StartMoving()
    {
        isMoving = true;
        Vector3 downwardMovement = new Vector3(0f, -moveSpeed, 0f);
        rb.velocity = downwardMovement;
    }

    void StopMoving()
    {
        isMoving = false;
        timer = 0.0f;
        rb.velocity = Vector3.zero;

        // Play the audio clip when the object stops moving
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
