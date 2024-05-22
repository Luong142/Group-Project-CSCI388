using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatGPTpopUI : MonoBehaviour
{
    [SerializeField]
    CapsuleCollider capsuleCollider;

    [SerializeField]



    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("UI is on! (entered)");
        EnableUI();

    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("UI is not on (exited)");

    }

    private void EnableUI()
    {

    }

    private void DisableUI()
    {

    }
}
