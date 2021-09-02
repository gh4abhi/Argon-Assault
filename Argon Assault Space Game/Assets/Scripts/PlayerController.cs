using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 5.5f;
    [Tooltip("In m")] [SerializeField] float yRange = 3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        VerticalMovement();
    }

    void HorizontalMovement()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Speed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }
    void VerticalMovement()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Speed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }
}
