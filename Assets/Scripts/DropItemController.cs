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
    [SerializeField] private int maxDropCount = 3; // Toplam düþme sayýsý
    [SerializeField] private float despawnTime = 4f; // Düþen itemin yok olma süresi

    private int currentDropCount = 0; // Þu ana kadar düþen item sayýsý
    private bool dropEnabled = true; // Düþmenin etkin olup olmadýðýný takip eder

    private List<DropData> availableDropData = new List<DropData>(); // Rastgele düþebilecek itemleri tutar

    [SerializeField] private GameObject item;

    private void Start()
    {
        // Baþlangýçta rastgele düþebilecek itemleri belirle
        foreach (DropData dropData in dropDataArray)
        {
            availableDropData.Add(dropData);
        }
    }

    public void DropItems(Vector2 position)
    {
        if (!dropEnabled || currentDropCount >= maxDropCount)
        {
            return; // Düþme etkin deðilse veya istenen toplam düþme sayýsýna ulaþýldýysa iþlemi sonlandýr
        }

        if (availableDropData.Count == 0)
        {
            return; // Rastgele düþebilecek item kalmadýysa iþlemi sonlandýr
        }

        int randomIndex = Random.Range(0, availableDropData.Count); // Rastgele bir index seç
        DropData selectedDropData = availableDropData[randomIndex]; // Seçilen drop verisini al

        float randomValue = Random.Range(0f, 1f);
        if (randomValue <= selectedDropData.dropChance)
        {
            GameObject item = Instantiate(selectedDropData.itemPrefab, position, Quaternion.identity);

            Destroy(item,despawnTime);
            currentDropCount++;
        }
    }

 
    public void SetDropEnabled(bool enabled)
    {
        dropEnabled = enabled; // Düþmenin etkinliðini ayarla
    }

    public void IncreaseMaxDropCount(int amount)
    {
        maxDropCount += amount; // Toplam düþme sayýsýný arttýr
    }

    public void DecreaseMaxDropCount(int amount)
    {
        maxDropCount -= amount; // Toplam düþme sayýsýný azalt
        if (maxDropCount < 0)
        {
            maxDropCount = 0; // Toplam düþme sayýsý negatif olamaz
        }
    }
}
