using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesAnimSpeed : MonoBehaviour
{
    private Animator anim;
    private float animSpeed = 1;
    public float animNewSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (animNewSpeed != 1)
        {
            ChangeAnimSpeed(animNewSpeed);
        }
        else
        {
            anim.SetFloat("Speed", animSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Herhangi bir güncelleme i?lemi varsa ekle
    }

    void ChangeAnimSpeed(float newSpeed)
    {
        anim.SetFloat("Speed", newSpeed);
    }
}
