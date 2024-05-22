using UnityEngine;
using System.Collections;

/// <summary>
/// Set the rotation of an object
/// </summary>
public class RotateObject : MonoBehaviour
{
    [Tooltip("The value at which the speed is applied")]
    [Range(0, 1)] public float sensitivity = 1.0f;

    [Tooltip("The max speed of the rotation")]
    public float maxSpeed = 100.0f;

    private float currentSpeed = 0.0f;
    private bool isRotating = false;

    public void SetIsRotating(bool value)
    {
        if (value)
        {
            StartCoroutine(GraduallyIncreaseSpeed());
        }
        else
        {
            StartCoroutine(GraduallyDecreaseSpeed());
        }
    }

    private IEnumerator GraduallyIncreaseSpeed()
    {
        // this will increase the speed gradually, the speed is not really fast.
        isRotating = true;
        while (currentSpeed < maxSpeed)
        {
            currentSpeed += maxSpeed * Time.deltaTime;
            yield return null;
        }
        currentSpeed = maxSpeed;
    }

    private IEnumerator GraduallyDecreaseSpeed()
    {
        // this will decrease the speed gradually, the speed is okish.
        while (currentSpeed > 0)
        {
            currentSpeed -= maxSpeed * Time.deltaTime;
            yield return null;
        }
        currentSpeed = 0;
        isRotating = false;
    }

    public void ToggleRotate()
    {
        if (isRotating)
        {
            StartCoroutine(GraduallyDecreaseSpeed());
        }
        else
        {
            StartCoroutine(GraduallyIncreaseSpeed());
        }
    }

    public void SetSpeed(float value)
    {
        sensitivity = Mathf.Clamp(value, 0, 1);
        maxSpeed = sensitivity * 100.0f;
        if (maxSpeed == 0.0f)
        {
            StartCoroutine(GraduallyDecreaseSpeed());
        }
        else if (!isRotating)
        {
            StartCoroutine(GraduallyIncreaseSpeed());
        }
    }

    private void Update()
    {
        if (isRotating)
            Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(transform.up, currentSpeed * Time.deltaTime);
    }
}