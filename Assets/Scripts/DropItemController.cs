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
    [SerializeField] private int maxDropCount = 3; // Toplam d��me say�s�
    [SerializeField] private float despawnTime = 4f; // D��en itemin yok olma s�resi

    private int currentDropCount = 0; // �u ana kadar d��en item say�s�
    private bool dropEnabled = true; // D��menin etkin olup olmad���n� takip eder

    private List<DropData> availableDropData = new List<DropData>(); // Rastgele d��ebilecek itemleri tutar

    [SerializeField] private GameObject item;

    private void Start()
    {
        // Ba�lang��ta rastgele d��ebilecek itemleri belirle
        foreach (DropData dropData in dropDataArray)
        {
            availableDropData.Add(dropData);
        }
    }

    public void DropItems(Vector2 position)
    {

        if (!dropEnabled || currentDropCount >= maxDropCount)
        {
            return; 
        }

        if (availableDropData.Count == 0)
        {
            return; 
        }

        int randomIndex = Random.Range(0, availableDropData.Count); 
        DropData selectedDropData = availableDropData[randomIndex]; 

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
        dropEnabled = enabled; 
    }

    public void IncreaseMaxDropCount(int amount)
    {
        maxDropCount += amount;
    }

    public void DecreaseMaxDropCount(int amount)
    {
        maxDropCount -= amount; 
        if (maxDropCount < 0)
        {
            maxDropCount = 0;
        }
    }
}
