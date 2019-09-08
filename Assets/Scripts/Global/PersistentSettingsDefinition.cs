﻿using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Persistent Settings", menuName = "Persistent Settings")]
public class PersistentSettingsDefinition : ScriptableObject
{
    /** Setting storage keys */
    private static readonly string Key_VolumeLevel_General = "VOL_GENERAL";
    private static readonly string Key_VolumeLevel_Music = "VOL_MUSIC";
    private static readonly string Key_Initialized = "INITIALIZED";

    private UnityEvent OnValueChange = new UnityEvent();

    public float VolumeLevel_General {
        get { return volumeLevel_General; }
        set {
            volumeLevel_General = Mathf.Clamp01(value);
            Debug.Log("VolumeLevel_General " + volumeLevel_General);
            OnValueChange.Invoke();
        }
    }

    public float VolumeLevel_Music {
        get { return volumeLevel_Music; }
        set {
            volumeLevel_Music = Mathf.Clamp01(value);
            Debug.Log("VolumeLevel_Music " + volumeLevel_Music);
            OnValueChange.Invoke();
        }
    }

    public float DifficultyScale {
        get { return difficultyScale; }
        set {
            difficultyScale = Mathf.Clamp(value, 0, 10);
            Debug.Log("DifficultyScale " + difficultyScale);
            OnValueChange.Invoke();
        }
    }

    [SerializeField] private float volumeLevel_General = 1.0f;
    [SerializeField] private float volumeLevel_Music = 1.0f;
    [SerializeField] private float difficultyScale = 1.0f;

    public void SubscribeToValueChanges(UnityAction action) {
        OnValueChange.AddListener(action);
    }

    public void UnsubscribeFromValueChanges(UnityAction action) {
        OnValueChange.RemoveListener(action);
    } 

    public void StorePlayerPrefs() {
        Debug.Log("Storing Persistent Settings");
        PlayerPrefs.SetInt(Key_Initialized, 1);
        PlayerPrefs.SetFloat(Key_VolumeLevel_General, VolumeLevel_General);
        PlayerPrefs.SetFloat(Key_VolumeLevel_Music, VolumeLevel_Music);
    }

    public void LoadPlayerPrefs() {
        if (PlayerPrefs.HasKey("INITIALIZED") == false) StorePlayerPrefs();

        Debug.Log("Loading Persistent Settings");
        VolumeLevel_General = PlayerPrefs.GetFloat(Key_VolumeLevel_General);
        VolumeLevel_Music = PlayerPrefs.GetFloat(Key_VolumeLevel_Music);

        OnValueChange.Invoke();
    }
}