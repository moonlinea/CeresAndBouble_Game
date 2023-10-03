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
            return; // D��me etkin de�ilse veya istenen toplam d��me say�s�na ula��ld�ysa i�lemi sonland�r
        }

        if (availableDropData.Count == 0)
        {
            return; // Rastgele d��ebilecek item kalmad�ysa i�lemi sonland�r
        }

        int randomIndex = Random.Range(0, availableDropData.Count); // Rastgele bir index se�
        DropData selectedDropData = availableDropData[randomIndex]; // Se�ilen drop verisini al

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
        dropEnabled = enabled; // D��menin etkinli�ini ayarla
    }

    public void IncreaseMaxDropCount(int amount)
    {
        maxDropCount += amount; // Toplam d��me say�s�n� artt�r
    }

    public void DecreaseMaxDropCount(int amount)
    {
        maxDropCount -= amount; // Toplam d��me say�s�n� azalt
        if (maxDropCount < 0)
        {
            maxDropCount = 0; // Toplam d��me say�s� negatif olamaz
        }
    }
}
