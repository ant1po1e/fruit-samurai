using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minCuttingVelocity = .001f;
    bool isCutting = false;

    Vector2 prevPos;

    Rigidbody2D rb;
    CircleCollider2D circleCollider;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPos;

        float velocity = (newPos - prevPos).magnitude / Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        prevPos = newPos;

    }

    void StartCutting()
    {
        isCutting = true;
        prevPos = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        circleCollider.enabled = false;
    }

    ////// 30:10
}
