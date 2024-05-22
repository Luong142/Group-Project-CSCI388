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
    private Coroutine speedCoroutine;

    public void SetIsRotating(bool value)
    {
        // add in to make the fan run on normal speed
        if (speedCoroutine != null)
        {
            StopCoroutine(speedCoroutine);
        }

        if (value)
        {
            // control the speed if value is rotated then run it max speed
            speedCoroutine = StartCoroutine(GraduallyChangeSpeed(maxSpeed));
        }
        else
        {
            // else run gradually decrease the speed until 0.0f
            speedCoroutine = StartCoroutine(GraduallyChangeSpeed(0.0f));
        }
    }

    private IEnumerator GraduallyChangeSpeed(float targetSpeed)
    {
        float speedChangeRate = maxSpeed * Time.deltaTime;

        if (targetSpeed > currentSpeed)
        {
            // set to true if + the current with the speed change rate from (max speed)
            isRotating = true;
            while (currentSpeed < targetSpeed)
            {
                currentSpeed += speedChangeRate;
                currentSpeed = Mathf.Min(currentSpeed, targetSpeed);
                yield return null;
            }
        }
        else
        {
            while (currentSpeed > targetSpeed)
            {
                currentSpeed -= speedChangeRate;
                currentSpeed = Mathf.Max(currentSpeed, targetSpeed);
                yield return null;
            }

            // set to false if minus the current with the speed change rate.
            isRotating = false;
        }
    }

    public void ToggleRotate()
    {
        SetIsRotating(!isRotating);
    }

    public void SetSpeed(float value)
    {
        sensitivity = Mathf.Clamp(value, 0, 1);
        maxSpeed = sensitivity * 100.0f;

        if (speedCoroutine != null)
        {
            StopCoroutine(speedCoroutine);
        }

        if (maxSpeed == 0.0f)
        {
            speedCoroutine = StartCoroutine(GraduallyChangeSpeed(0.0f));
        }
        else
        {
            speedCoroutine = StartCoroutine(GraduallyChangeSpeed(maxSpeed));
        }
    }

    private void Update()
    {
        if (isRotating)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        transform.Rotate(transform.up, currentSpeed * Time.deltaTime);
    }
}