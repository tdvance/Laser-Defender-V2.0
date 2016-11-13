using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenu : MonoBehaviour {
    public static float sfxVolume = 0.5f;
    public static float musicVolume = 0.25f;

    public GameObject musicVolumeSlider;
    public GameObject sfxVolumeSlider;

    string musicKey = "Music Volume";
    string sfxKey = "SFX Volume";


    // Use this for initialization
    void Start() {
        if (PlayerPrefs.HasKey(musicKey)) {
            musicVolume = PlayerPrefs.GetFloat(musicKey);
        }
        if (musicVolumeSlider) {
            musicVolumeSlider.GetComponent<Slider>().value = musicVolume;
        }
        FlexibleMusicManager.instance.volume = musicVolume;
        if (PlayerPrefs.HasKey(sfxKey)) {
            sfxVolume = PlayerPrefs.GetFloat(sfxKey);
        }
        if (sfxVolumeSlider) {
            sfxVolumeSlider.GetComponent<Slider>().value = sfxVolume;
        }
    }

    public void UpdateMusic() {
        musicVolume = musicVolumeSlider.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat(musicKey, musicVolume);
        FlexibleMusicManager.instance.volume = musicVolume;
    }

    public void UpdateSFX() {
        sfxVolume = sfxVolumeSlider.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat(sfxKey, sfxVolume);
    }

}
