using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    private Animator _gateAnimation;
    [SerializeField] private int _asteroid;
    private void Awake()
    {
       
        _asteroid= LayerMask.GetMask("GateOpenBall");
        _gateAnimation = GetComponent<Animator>();
        _gateAnimation.SetBool("GateOpen", false);
        
    }


    // Update is called once per frame
    void Update()
    {
        if (_asteroid == 0) OpenGate();
        else _gateAnimation.SetBool("GateOpen", false);
    }
    void OpenGate()
    {
        _gateAnimation.SetBool("GateOpen", true);
    }


}
