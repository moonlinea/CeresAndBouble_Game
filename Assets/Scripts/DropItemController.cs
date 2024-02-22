using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



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
    private int levelIndex;

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

          
            Destroy(newItem, despawnTime);
            currentDropCount++;
        }

        
    }

 
}
