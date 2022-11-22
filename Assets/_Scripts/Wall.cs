using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public ParticleSystem blueConfetti;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            gameObject.SetActive(false);
            Instantiate(blueConfetti, transform.position, quaternion.identity);
            GameManager.instance.DestroyedWallCount++;
            if (GameManager.instance.DestroyedWallCount == GameManager.instance.TotalWallForLevel)
            {
                GameManager.instance.LevelComplete();
            }
        }
    }
}
