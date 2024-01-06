using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DropItemController : MonoBehaviour
{
    [System.Serializable]
    public class DropData
    {
        public GameObject itemPrefab;   // Bu sınıf, düşen her bir öğe için prefab ve düşme şansı bilgilerini içerir.
        public float dropChance;
    }

    [SerializeField] private DropData[] dropDataArray;    // Düşebilecek öğelerin listesi ve düşme şansları
    [SerializeField] private int maxDropCount = 3;        // Maksimum düşme sayısı
    [SerializeField] private float despawnTime = 4f;
    private int levelIndex;// Oluşturulan öğelerin belirli bir süre sonra yok olma süresi

    private int currentDropCount = 0;    // Şu anda düşmüş olan öğe sayısı
    private bool dropEnabled = true;     // Düşme özelliğinin etkin olup olmadığı
    private List<DropData> availableDropData = new List<DropData>();    // Düşme için kullanılabilir öğelerin listesi

    private void Start()
    {
        // Başlangıçta, dropDataArray içindeki tüm öğeleri availableDropData listesine ekler
        foreach (DropData dropData in dropDataArray)
        {
            availableDropData.Add(dropData);
        }
        levelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void DropItems(Vector2 position)
    {


        // Düşme özelliği etkisizse veya maksimum düşme sayısına ulaşıldıysa işlemi sonlandır
        if (!dropEnabled || currentDropCount >= maxDropCount)
        {
            return;
        }


        // Rastgele bir öğe seç ve düşme şansından küçükse öğeyi oluştur
        int randomIndex = Random.Range(0, availableDropData.Count);
        DropData selectedDropData = availableDropData[randomIndex];

        float randomValue = Random.Range(0f, 1f);
        if (randomValue <= selectedDropData.dropChance)
        {
            // Seçilen öğeyi belirtilen konumda oluştur
            GameObject newItem = Instantiate(selectedDropData.itemPrefab, position, Quaternion.identity);

            // Oluşturulan öğenin belirtilen süre sonra yok olması için ayarları yap
            Destroy(newItem, despawnTime);
            currentDropCount++;
        }

        
    }

 
}
