using UnityEngine;

public class WalkSound : MonoBehaviour
{
    public AudioSource foodStepSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("W") || Input.GetKey("S") || Input.GetKey("A") || Input.GetKey("D"))
        {
            foodStepSound.enabled = true;
        }
        else
        {
            foodStepSound.enabled = false;
        }
    }
}
