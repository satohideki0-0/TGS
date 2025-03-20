using System;
using UnityEngine;

public class EndEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        die();
    }
    void die()
    {
        gameObject.SetActive(false);
        RushEventManager.Instance.EndEvent(0);
    }
}
