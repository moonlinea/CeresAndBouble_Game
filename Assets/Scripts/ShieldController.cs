using System.Collections;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private GameObject playerObject;
    private bool isActive = false;
    private Coroutine deactivationCoroutine; // Coroutine referansı
    private float defaultDeactivationTime = 1.5f; // Varsayılan pasif hale getirme süresi


    private void Start()
    {
        shieldObject.SetActive(isActive);
    }

    // Shield'i belirli bir süre aktif hale getirir ve sonra pasif yapar
    public void ActivateForDuration(float duration)
    {
        if (!isActive)
        {
            isActive = true;
            shieldObject.SetActive(true);
            TagAndLayerChanger.ChangeTagAndLayer(playerObject, "PlayerShield", "PlayerShield");
            deactivationCoroutine = StartCoroutine(Deactivate(duration));
        }
    }

    // Shield'i belirli bir süre bekledikten sonra pasif hale getiren yardımcı fonksiyon
    private IEnumerator Deactivate(float duration)
    {
        yield return new WaitForSeconds(duration);
        shieldObject.SetActive(false);
        isActive = false;
       
        TagAndLayerChanger.ChangeTagAndLayer(playerObject, "Player", "Player");
    }

    // Shield'i hemen pasif hale getirir veya belirli bir süre sonra pasif yapar
    public void Deactivate(float? delay = null)
    {
        if (deactivationCoroutine != null)
        {
            StopCoroutine(deactivationCoroutine); // Önceki Coroutine'u durdur
        }

        float deactivationTime = delay ?? defaultDeactivationTime; // Eğer delay null ise varsayılan süreyi kullan

        if (deactivationTime <= 0f)
        {
            shieldObject.SetActive(false); // Hemen pasif hale getir
            isActive = false;
           
            TagAndLayerChanger.ChangeTagAndLayer(playerObject, "Player", "Player");

        }
        else
        {
            deactivationCoroutine = StartCoroutine(Deactivate(deactivationTime)); // Belirtilen süre sonra pasif yap
        }
    }
}

public static class TagAndLayerChanger
{
   
    public static void ChangeTagAndLayer(GameObject targetObject, string newTag, string newLayer)
    {
        Debug.LogWarning("layer değişti");
        if (targetObject != null)
        {
            targetObject.tag = newTag;
            targetObject.layer = LayerMask.NameToLayer(newLayer);
        }
        else
        {
            Debug.LogWarning("Hedef obje null olduğu için tag ve layer değiştirilemedi.");
        }
    }
}
