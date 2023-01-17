using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveStats : MonoBehaviour
{
    [SerializeField] private Button saveButton;
    [SerializeField] private LapCount laps;
    private string filePath =  @"C:\RacewoodTrot\System\UserSettings\Horse_Data.xml";
    private string trackDataPath = @"C:\RacewoodTrot\System\UserSettings\Track_Data.xml";

    // Start is called before the first frame update
    void Start()
    {
        // Using Unity event to listen for the save button to be pressed.
        saveButton.onClick.AddListener(Save);
        saveButton.onClick.AddListener(SaveTrackInfo);
    }

    // Saving the values of the main player 
    private void Save()
    {
        GameObject mainPlayer = GameObject.Find("MainPlayer");
        HorseStats.Save(filePath, HorseStats.horseStat);
        LoadPlayerData load = mainPlayer.GetComponent<LoadPlayerData>();
        load.OnSaveData();// Calling the save function PlayerData.cs
    }
    // Save the values for the track. 
    private void SaveTrackInfo()
    {
        TrackData.trackData.Laps = laps.LapValue;
        TrackData.Save(trackDataPath, TrackData.trackData);
    }
}
