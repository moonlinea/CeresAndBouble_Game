using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    public GameObject rightObject;
    public GameObject leftObject;

    public float moveSpeed = 5f;

    void Start()
    {
        // Sağ ve sol objeleri başlangıçta gizle
        rightObject.SetActive(false);
        leftObject.SetActive(false);

        // Sağ ve sol butonlara tıklama olaylarını atayın
        Button rightButton = GameObject.Find("RightArrow").GetComponent<Button>();
        rightButton.onClick.AddListener(MoveRight);

        Button leftButton = GameObject.Find("LeftArrow").GetComponent<Button>();
        leftButton.onClick.AddListener(MoveLeft);
    }

    // Sağ butona tıklandığında çağrılacak fonksiyon
    void MoveRight()
    {
        MoveGameObject(rightObject, new Vector3(100f, 0f, 0f)); // Sağa kaydır
        leftObject.SetActive(true); // Sol objeyi göster
    }

    // Sol butona tıklandığında çağrılacak fonksiyon
    void MoveLeft()
    {
        MoveGameObject(leftObject, new Vector3(-100f, 0f, 0f)); // Sola kaydır
        rightObject.SetActive(true); // Sağ objeyi göster
    }

    // Objeyi belirli bir yöne hareket ettiren fonksiyon
    void MoveGameObject(GameObject obj, Vector3 offset)
    {
        obj.transform.position += offset * moveSpeed * Time.deltaTime;
    }
}
