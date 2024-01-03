using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : MonoBehaviour
{
    [System.Serializable]
    public class DropData
    {
        public GameObject itemPrefab;   // Bu s?n?f, d�?en her bir �?e i�in prefab ve d�?me ?ans? bilgilerini i�erir.
        public float dropChance;
    }

    [SerializeField] private DropData[] dropDataArray;    // D�?ebilecek �?elerin listesi ve d�?me ?anslar?
    [SerializeField] private int maxDropCount = 3;        // Maksimum d�?me say?s?
    [SerializeField] private float despawnTime = 4f;     // Olu?turulan �?elerin belirli bir s�re sonra yok olma s�resi

    private int currentDropCount = 0;    // ?u anda d�?m�? olan �?e say?s?
    private bool dropEnabled = true;     // D�?me �zelli?inin etkin olup olmad???
    private List<DropData> availableDropData = new List<DropData>();    // D�?me i�in kullan?labilir �?elerin listesi

    private void Start()
    {
        // Ba?lang?�ta, dropDataArray i�indeki t�m �?eleri availableDropData listesine ekler
        foreach (DropData dropData in dropDataArray)
        {
            availableDropData.Add(dropData);
        }
    }

    public void DropItems(Vector2 position)
    {
        // D�?me �zelli?i etkisizse veya maksimum d�?me say?s?na ula??ld?ysa i?lemi sonland?r
        if (!dropEnabled || currentDropCount >= maxDropCount)
        {
            return;
        }

        // D�?ebilecek �?e kalmad???nda i?lemi sonland?r
        if (availableDropData.Count == 0)
        {
            return;
        }

        // Rastgele bir �?e se� ve d�?me ?ans?ndan k���kse �?eyi olu?tur
        int randomIndex = Random.Range(0, availableDropData.Count);
        DropData selectedDropData = availableDropData[randomIndex];

        float randomValue = Random.Range(0f, 1f);
        if (randomValue <= selectedDropData.dropChance)
        {
            // Se�ilen �?eyi belirtilen konumda olu?tur
            GameObject newItem = Instantiate(selectedDropData.itemPrefab, position, Quaternion.identity);

            // Olu?turulan �?enin belirtilen s�re sonra yok olmas? i�in ayarlar? yap
            Destroy(newItem, despawnTime);
            currentDropCount++;
        }
    }

 
}
