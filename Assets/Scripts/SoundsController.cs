using UnityEngine;
using UnityEngine.UI;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private Sprite[] sprites;

    private bool isSoundOn = true;

    void Start()
    {
        // PlayerPrefs üzerinden kaydedilmiş ses tercihini kontrol et
        isSoundOn = PlayerPrefs.GetInt("IsSoundOn", 1) == 1;

        // Ses durumuna göre ses kaynaklarını güncelle
        SetSoundState(isSoundOn);




    }
    public void SoundToggle()
    {
       
            isSoundOn =!isSoundOn;
            SetSoundState(isSoundOn);
        
    }


    private void SetSoundState(bool state)
    {
        isSoundOn = state;

        // Ses durumuna göre ses kaynaklarını aç veya kapat
        foreach (var audioSource in audioSources)
        {
            audioSource.mute = !isSoundOn;
        }

        // PlayerPrefs üzerinde ses tercihini kaydet
        PlayerPrefs.SetInt("IsSoundOn", isSoundOn ? 1 : 0);
        PlayerPrefs.Save();

     
    }
}
