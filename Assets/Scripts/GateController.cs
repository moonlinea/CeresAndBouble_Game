using System;
using Unity.VisualScripting;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private Animator[] gateAnimation;
    private GameObject asteroids;
    [SerializeField] private GameObject[] inActiveAsteroid;
    public AudioSource gateSounds;
    private bool isGateSoundOn;
    private int currentGateIndex = 0;
    private GameObject[] asteroid;

    private void Start()
    {
        asteroid = GameObject.FindGameObjectsWithTag("Asteroid");

        currentGateIndex = 0;
    }

    private void Update()
    {
      
        asteroids = GameObject.FindGameObjectWithTag("Ball");

        if (asteroids == null)
        {
            OpenGate(currentGateIndex);
        }
        
    }
  
    public void OpenGate(int gateIndex)
    {
        if (gateIndex < gateAnimation.Length && gateIndex < inActiveAsteroid.Length && asteroid.Length == 0)
        {
           

                gateAnimation[gateIndex].SetBool("GateOpen", true);
            isGateSoundOn = PlayerPrefs.GetInt("IsSoundOn", 1) == 1;
            if (isGateSoundOn) gateSounds.Play();
            if (inActiveAsteroid[gateIndex] != null)
            {

                inActiveAsteroid[gateIndex].SetActive(true);
                currentGateIndex++;

            }
        }
        else if (asteroid.Length>0)
        {
          
            for (int i = 0; i < gateAnimation.Length; i++)
            {
                gateAnimation[i].SetBool("GateOpen", true);
            }
            foreach (GameObject ball in asteroid)
            {
                if(ball.tag!=null)
                ball.tag = "Ball";
            }
        }

    }
}