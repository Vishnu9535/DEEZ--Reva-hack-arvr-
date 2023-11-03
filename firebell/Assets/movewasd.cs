using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 50.0f; // Adjust the speed as needed
     public AudioSource alarmSound; // Reference to the AudioSource for the alarm sound

    private bool isAlarmRinging = false;
     void Start()
    {
        alarmSound = GetComponent<AudioSource>(); // Assign the AudioSource component from the GameObject
    }
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (XRSettings.enabled)
        {
            InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            if (device.isValid)
            {
                device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 inputAxis);
                // Allow movement in X and Z axes in AR/VR
                moveDirection = new Vector3(inputAxis.x, 0, inputAxis.y);
            }
        }
        else
        {
            // Desktop Input (WASD keys)
            // Allow movement in X and Z axes using A/D and W/S keys
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }

        // Allow vertical (Y-axis) movement using Space and Shift keys
        if (Input.GetKey(KeyCode.Space))
        {
            moveDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection += Vector3.down;
        }

        // Move the player based on the input
        transform.Translate(moveDirection * speed * Time.deltaTime);
          if (Input.GetKeyDown(KeyCode.L))
        {
            if (!isAlarmRinging)
            {
                Debug.Log("test");
                // Start the alarm sound
                alarmSound.Play();
                isAlarmRinging = true;
            }
            else
            {
                // Stop the alarm sound
                alarmSound.Stop();
                isAlarmRinging = false;
            }
        }
    }
}