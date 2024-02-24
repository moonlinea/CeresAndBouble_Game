using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObjectDestroy : MonoBehaviour
{
    [SerializeField] public float destroyDelay = 3f; // Yok olma süresi

    private void Start()
    {
        // Belirlenen süre sonunda Destroy metoduyla objeyi yok eder
        Destroy(gameObject, destroyDelay);
    }


}
