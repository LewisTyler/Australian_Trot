using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class RaceConfigurator : MonoBehaviour
{
    private string trackDataPath = @"C:\TrotApplication\System\UserSettings\Track_Data.xml";

    [SerializeField] private Toggle RowOneToggle;
    [SerializeField] private Toggle RowTwoToggle;
    [SerializeField] private TMP_Text NumberOfLaps;
    [SerializeField] private TMP_Text Players;
    [SerializeField] private GameObject RowTwoGameObject;
    [SerializeField] private int PlayerCount;

    private int laps;
    public static int LapCount;
    public static bool RowOneValue;
    public static bool RowTwoValue;
    public static int NumberOfPlayers;

    void Start()
    {
        if (!File.Exists(trackDataPath)) // I am checking to see if the trackDataPath does not exist
        {
            File.Create(trackDataPath);// I then create the file.

            // I set the track data to default values.
            TrackData.trackData.Laps = LapCount;
            TrackData.trackData.RowOne = RowOneValue;
            TrackData.trackData.RowTwo = RowTwoValue;
            TrackData.trackData.Players = NumberOfPlayers;
        }

        if (File.Exists(trackDataPath)) // if the file exists 
        {
            TrackData.Load(trackDataPath);// Load the default data
        }
        // I am using Unity Events to listen for when the row toggles have have been clicked.
        RowOneToggle.onValueChanged.AddListener(EnableRowOne);
        RowTwoToggle.onValueChanged.AddListener (EnableRowTwo);
        TrackInfo();
    }

    // I am turning on row on send back a bool value. 
    private void EnableRowOne(bool RowOne)
    {
        if(RowOneToggle.isOn)
        {
            RowOneValue = true;
            RowTwoValue = false;
            RowTwoToggle.isOn = false;
            RowTwoGameObject.SetActive(false);
            TrackData.trackData.RowOne = true;
            TrackData.trackData.RowTwo = false;
        }
    }

    // I am turning on the second row
    private void EnableRowTwo(bool RowTwo)
    {
        if (RowTwoToggle.isOn)
        {
            RowTwoValue = true;
            RowOneValue = false;
            RowOneToggle.isOn = false;
            RowTwoGameObject.SetActive(true);
            TrackData.trackData.RowOne = false;
            TrackData.trackData.RowTwo = true;
        }
    }

    // Reading back the values from the XML file and setting up the race.
     void TrackInfo()
    {
        if (TrackData.trackData.RowOne == true)
        {
            EnableRowOne(RowOneValue);
        }
        if (TrackData.trackData.RowTwo == true)
        {
            EnableRowTwo(RowTwoValue);
        }

        NumberOfLaps.text = TrackData.trackData.Laps.ToString();
        Players.text = TrackData.trackData.Players.ToString();
    }

}
