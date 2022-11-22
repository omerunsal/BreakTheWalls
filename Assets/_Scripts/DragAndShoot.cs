using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;
    private float forceMultiplier;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos-mouseReleasePos);
    }
    

    private void Shoot(Vector3 Force)
    {
        forceMultiplier = 0.25f;
        if (isShoot)
        {
            return;
        }
        rb.AddForce(new Vector3(Force.x,Force.y,Force.y) * forceMultiplier, ForceMode.Impulse);
        isShoot = true;
    }
}
