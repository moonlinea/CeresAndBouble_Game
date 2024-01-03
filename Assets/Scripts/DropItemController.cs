using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : MonoBehaviour
{
    [System.Serializable]
    public class DropData
    {
        public GameObject itemPrefab;   // Bu s?n?f, dü?en her bir ö?e için prefab ve dü?me ?ans? bilgilerini içerir.
        public float dropChance;
    }

    [SerializeField] private DropData[] dropDataArray;    // Dü?ebilecek ö?elerin listesi ve dü?me ?anslar?
    [SerializeField] private int maxDropCount = 3;        // Maksimum dü?me say?s?
    [SerializeField] private float despawnTime = 4f;     // Olu?turulan ö?elerin belirli bir süre sonra yok olma süresi

    private int currentDropCount = 0;    // ?u anda dü?mü? olan ö?e say?s?
    private bool dropEnabled = true;     // Dü?me özelli?inin etkin olup olmad???
    private List<DropData> availableDropData = new List<DropData>();    // Dü?me için kullan?labilir ö?elerin listesi

    private void Start()
    {
        // Ba?lang?çta, dropDataArray içindeki tüm ö?eleri availableDropData listesine ekler
        foreach (DropData dropData in dropDataArray)
        {
            availableDropData.Add(dropData);
        }
    }

    public void DropItems(Vector2 position)
    {
        // Dü?me özelli?i etkisizse veya maksimum dü?me say?s?na ula??ld?ysa i?lemi sonland?r
        if (!dropEnabled || currentDropCount >= maxDropCount)
        {
            return;
        }

        // Dü?ebilecek ö?e kalmad???nda i?lemi sonland?r
        if (availableDropData.Count == 0)
        {
            return;
        }

        // Rastgele bir ö?e seç ve dü?me ?ans?ndan küçükse ö?eyi olu?tur
        int randomIndex = Random.Range(0, availableDropData.Count);
        DropData selectedDropData = availableDropData[randomIndex];

        float randomValue = Random.Range(0f, 1f);
        if (randomValue <= selectedDropData.dropChance)
        {
            // Seçilen ö?eyi belirtilen konumda olu?tur
            GameObject newItem = Instantiate(selectedDropData.itemPrefab, position, Quaternion.identity);

            // Olu?turulan ö?enin belirtilen süre sonra yok olmas? için ayarlar? yap
            Destroy(newItem, despawnTime);
            currentDropCount++;
        }
    }

 
}
