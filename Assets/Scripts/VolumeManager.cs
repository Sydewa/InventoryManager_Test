using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [SerializeField]AudioMixer mixer;
    [SerializeField]string volumeParameter;
    [SerializeField]Slider volumeSlider;

    [SerializeField]Toggle muteToggle;
    [SerializeField]bool isMuted;

    //Esto es una funcion de unity, se llama cuando quitamos el modo play y cuando el objeto que tiene este script se desactiva.

    void Awake() 
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        muteToggle.onValueChanged.AddListener(Mute);
    }

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(volumeParameter, volumeSlider.maxValue);
        string muteValue = PlayerPrefs.GetString(volumeParameter +"Mute", "False");

        //Las mayusculas en false y true son importantes
        if(muteValue == "False")
        {
            isMuted = false;
        }
        else if(muteValue == "True")
        {
            isMuted = true;
        }

        muteToggle.isOn = !isMuted;
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, volumeSlider.value);
        PlayerPrefs.SetString(volumeParameter + "Mute", isMuted.ToString());
    }

    //Si esto lo dejamos en public luego podemos ir al slider y aplicarle un evento cuando el valor cambie, 
    //pero debemos seleccionar el dinamic float, o nos obligará a poner a mano el valor
    public void ChangeVolume(float value)
    {
        mixer.SetFloat(volumeParameter, value);
        muteToggle.isOn = volumeSlider.value > volumeSlider.minValue;
    }

    void Mute(bool soundEnabled)
    {
        if(soundEnabled)
        {
            float lastVolume = PlayerPrefs.GetFloat(volumeParameter, volumeSlider.maxValue);
            mixer.SetFloat(volumeParameter, lastVolume);
            isMuted = false;
        }
        else
        {
            PlayerPrefs.SetFloat(volumeParameter, volumeSlider.value);
            mixer.SetFloat(volumeParameter, volumeSlider.minValue);
            isMuted = true;
        }
    }
}
