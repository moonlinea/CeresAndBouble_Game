using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
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
        PlayObstaclesAnim();
    }

    // Update is called once per frame
    void Update()
    {
        // Herhangi bir güncelleme işlemi varsa ekle
    }

    void PlayObstaclesAnim()
    {
        if (anim != null)
        {
            if (animNewSpeed != 1)
            {
                ChangeAnimSpeed(animNewSpeed);
            }
            else
            {
                anim.SetFloat("Speed", animSpeed);
            }
        }
    }

    void ChangeAnimSpeed(float newSpeed)
    {
        anim.SetFloat("Speed", newSpeed);
    }

    public void StopAnim()
    {
        if (anim != null)
        {
            anim.speed = 0;
        }
        else
        {
            Debug.LogError("Animator component is not assigned.");
        }
    }
}

[CustomEditor(typeof(ObstaclesAnimSpeed))]
public class ObstaclesAnimSpeedEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Animasyonu Durdur"))
        {
            foreach (Object obj in targets)
            {
                ObstaclesAnimSpeed script = (ObstaclesAnimSpeed)obj;
                script.StopAnim();
            }
        }
    }
}

