using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesAnimSpeed : MonoBehaviour
{
    private Animator Anim;
    private float AnimSpeed=1;
    public float AnimNewSpeed=1;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();

        if (AnimNewSpeed != 1)
        {
            ChangeAnimSpeed(AnimNewSpeed);
        }
        else
        {
            Anim.SetFloat("Speed", AnimSpeed);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void ChangeAnimSpeed(float newSpeed)
    {
        Anim.SetFloat("Speed", newSpeed);
    }
}
