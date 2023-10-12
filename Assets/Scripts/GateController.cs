using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    private Animator _gateAnimation;
 
    private void Awake()
    {
        _gateAnimation = GetComponent<Animator>();
        _gateAnimation.SetBool("GateOpen", false);
        
    }
   


}
