using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateControl : MonoBehaviour
{
    public GameObject Sphere;
    public GameObject Light;
    public bool HasMemory;
    bool isActive;
    bool isInactive;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HeavyObject")
        {
            isActive = true;
            startTime = Time.time;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!HasMemory)
            if (other.gameObject.tag == "HeavyObject")
            {
                isActive = false;
                startTime = Time.time;
            }
    }

    public float speed = 1.0f;
    public Color startColor;
    public Color endColor;
    float startTime;

    void Update()
    {
        if (isActive)
        {
            float t = (Time.time - startTime) * speed;
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(startColor, endColor, t));
            Light.GetComponent<Light>().color = Color.Lerp(startColor, endColor, t);
        }
        if (!isActive)
        {
            float t = (Time.time - startTime) * speed;
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(endColor, startColor, t));
            Light.GetComponent<Light>().color = Color.Lerp(endColor, startColor, t);
        }
    }
    }