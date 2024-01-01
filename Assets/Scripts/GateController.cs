using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    private Animator gateAnimation;
    private GameObject asteroids;
    [SerializeField] private GameObject inActiveAsteroid;
    private AudioSource gateSounds;

    private void Start()
    {
        gateAnimation = GetComponent<Animator>();
        gateAnimation.SetBool("GateOpen", false);
    }

    private void Update()
    {
        asteroids = GameObject.FindGameObjectWithTag("Ball");

        if (asteroids == null)
        {
            OpenGate();
        }
        //else 
        //{
        //    CloseGate();
        //}
    }

    private void OpenGate()
    {
        gateAnimation.SetBool("GateOpen", true);
        if (inActiveAsteroid != null)
        {
            inActiveAsteroid.SetActive(true);
        }
    }

  
}
