using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float Cosine;
    [SerializeField] float Delay;
    float pinpongValue; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //For UP and Down with delay 
        Cosine = Mathf.Cos(Time.time + Delay /5);
        Vector3 newPosition = transform.position;
        newPosition.y = Cosine;
        transform.position = newPosition;
        
        //For rotation
        Quaternion newRotation = transform.rotation;
        newRotation.x = Cosine /5;
        newRotation.y = Cosine /5;
        transform.rotation = newRotation ;
        pinpongValue = Mathf.PingPong((Time.time + Delay) * 0.1f, 1);

        Renderer rend = GetComponent<Renderer>();
        rend.material.color = Color.HSVToRGB(pinpongValue, 1, 1);
    }
}
