using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 10f;
    [Tooltip("In m")] [SerializeField] float xRange = 6.5f;
    [Tooltip("In m")] [SerializeField] float yRange = 4f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -25f;

    [Header("Control-throw Based")]
    [SerializeField] float positionYawFactor = 3f;

    [SerializeField] float controlRollFactor = -25f;

    float xThrow, yThrow;

    private bool isControlsEnabled = true;
    // Update is called once per frame
    void Update()
    {
        if (isControlsEnabled)
        {
            HorizontalMovement();
            VerticalMovement();
            ProcessRotation();
        }
    }

    void OnPlayerDeath()
    {
        isControlsEnabled = false;
    }

    void HorizontalMovement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Speed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }
    void VerticalMovement()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Speed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }
    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueToControlThrow = 0f;
        float yaw = yawDueToPosition+yawDueToControlThrow;

        float rollDueToPosition = 0;
        float rollDueToControlThrow = xThrow*controlRollFactor;
        float roll = rollDueToPosition+rollDueToControlThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
