using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : MonoBehaviour
{
    [System.Serializable]
    public class DropData
    {
        public GameObject itemPrefab;
        public float dropChance;
    }

    [SerializeField] private DropData[] dropDataArray;
    [SerializeField] private int maxDropCount = 3;
    [SerializeField] private float despawnTime = 4f;

    private int currentDropCount = 0;
    private bool dropEnabled = true;
    private List<DropData> availableDropData = new List<DropData>();



    private void Start()
    {

        foreach (DropData dropData in dropDataArray)
        {
            availableDropData.Add(dropData);
        }

    }





    public void DropItems(Vector2 position)
    {
        // Dü?menin etkisiz oldu?u veya maksimum dü?me say?s?na ula??ld???nda i?lemi sonland?r
        if (!dropEnabled || currentDropCount >= maxDropCount)
        {
            return;
        }

        // Dü?ebilecek item kalmad???nda i?lemi sonland?r
        if (availableDropData.Count == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, availableDropData.Count);
        DropData selectedDropData = availableDropData[randomIndex];

        // Rastgele bir de?er olu?tur ve dü?me ?ans?ndan küçükse itemi olu?tur
        float randomValue = Random.Range(0f, 1f);
        if (randomValue <= selectedDropData.dropChance)
        {
            GameObject newItem = Instantiate(selectedDropData.itemPrefab, position, Quaternion.identity);

            // Itemin belirtilen süre sonra yok olmas? için ayarlar? yap
            Destroy(newItem, despawnTime);
            currentDropCount++;
        }
    }

    // Dü?me özelli?ini etkinle?tir veya devre d??? b?rak
    public void SetDropEnabled(bool enabled)
    {
        dropEnabled = enabled;
    }

    // Maksimum dü?me say?s?n? artt?r
    public void IncreaseMaxDropCount(int amount)
    {
        maxDropCount += amount;
    }

    // Maksimum dü?me say?s?n? azalt, 0'dan küçük olmamas?na dikkat et
    public void DecreaseMaxDropCount(int amount)
    {
        maxDropCount -= amount;
        if (maxDropCount < 0)
        {
            maxDropCount = 0;
        }
    }




}
