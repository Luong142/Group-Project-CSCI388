using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    [SerializeField]
    public GameObject musicDish;

    void Start()
    {
        musicDish = GetComponent<GameObject>();




    }

    // Update is called once per frame
    void Update()
    {

    }
}
