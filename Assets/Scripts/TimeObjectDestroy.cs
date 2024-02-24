using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObjectDestroy : MonoBehaviour
{
    [SerializeField] public float destroyDelay = 3f; // Yok olma s�resi

    private void Start()
    {
        // Belirlenen s�re sonunda Destroy metoduyla objeyi yok eder
        Destroy(gameObject, destroyDelay);
    }


}
