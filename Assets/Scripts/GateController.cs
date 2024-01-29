using System;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private Animator[] gateAnimation;
    private GameObject asteroids;
    [SerializeField] private GameObject[] inActiveAsteroid;
    public AudioSource gateSounds;
    private bool isGateSoundOn;
    private int currentGateIndex = 0;

    private void Start()
    {
        currentGateIndex = 0;
    }

    private void Update()
    {
        asteroids = GameObject.FindGameObjectWithTag("Ball");

        if (asteroids == null)
        {
            Debug.Log("Asteroids Kalmadı kapı ve asteroids Aç");
            OpenGate(currentGateIndex);
        }
    }

    public void OpenGate(int gateIndex)
    {

        Debug.Log("Asteroids Kalmadı kapı ve asteroids Açılıyor");
        if (gateIndex < gateAnimation.Length && gateIndex < inActiveAsteroid.Length)
        {

            Debug.Log("Current İndex: "+currentGateIndex);
            gateAnimation[gateIndex].SetBool("GateOpen", true);
            isGateSoundOn = PlayerPrefs.GetInt("IsSoundOn", 1) == 1;
            if (isGateSoundOn) gateSounds.Play();
            if (inActiveAsteroid[gateIndex] != null)
            {

                Debug.Log("Açıldı");
                inActiveAsteroid[gateIndex].SetActive(true);
                currentGateIndex++;

            }
        }
    }
}