using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    private Animator _gateAnimation;
    private GameObject _asteroids;
    [SerializeField] private GameObject _inActiveAsteroid;

    

    private void Start()
    {
        _gateAnimation = GetComponent<Animator>();
        _gateAnimation.SetBool("GateOpen", false);

      

        

    }
   
    private void Update()
    {
        _asteroids = GameObject.FindGameObjectWithTag("Ball");

        if (_asteroids == null)
        {
            _gateAnimation.SetBool("GateOpen", true);
            if (_inActiveAsteroid != null) { _inActiveAsteroid.SetActive(true); }
            
        }
        //else 
        //{
        //    _gateAnimation.SetBool("GateOpen", false);
           
        //}
    }





}

