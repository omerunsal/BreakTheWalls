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

    public LineRenderer line;

    private Ray ray;
    private RaycastHit hit;
    private Camera cam;

    private Vector3 ballInitialPos;

    public Transform ballCenter;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
        isShoot = false;
        
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isLevelStarted)
        {
             ray = cam.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit, 100))
            {
                line.enabled = isShoot == false ? true : false;

                line.SetPosition(0, Vector3.zero);
                line.SetPosition(1, -hit.point);
            }
            else
            {
                line.enabled = false;
            }
        }
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        line.enabled = false;
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
    }


    private void Shoot(Vector3 Force)
    {
        forceMultiplier = 0.125f;
        if (isShoot)
        {
            return;
        }

        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier, ForceMode.Impulse);
        isShoot = true;
    }
}