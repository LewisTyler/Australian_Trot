using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System;
using System.IO;
using Unity.Mathematics;
using System.Globalization;
using JetBrains.Annotations;

[CreateAssetMenu(fileName = "Assets/Scripts/PlayerData/HorseTypes/Profiles", menuName = "PlayerStateHolder/PlayerProfile", order = 1)]
public class PlayerData : ScriptableObject
{
    // Values used by the scriptable object
    [Serializable]
    public class Stats
    {
        public float Speed;
        public float Heart;
        public float Stamina;
        public float GaitSpeed;
        public float SpeedAbility;
        public string HorseType;
        public string PlayerName;
        public Image PlayerProfileImage;
    }
    public Stats playerStats;
}
// Default values 
[Serializable()]
public class Defaults
{
    [XmlAttribute("Speed")]
    public float Speed;
    [XmlAttribute("Heart")]
    public float Heart;
    [XmlAttribute("Stamina")]
    public float Stamina;
    [XmlAttribute("GaitSpeed")]
    public float GaitSpeed;
    [XmlAttribute("SpeedAbility")]
    public float SpeedAbility;

    public static Defaults defaultHorseStat = new Defaults();

    public Defaults()
    {
        Speed = 0.10f;
        Heart = 0.10f;
        Stamina = 0.10f;
        GaitSpeed = 0.10f;
        SpeedAbility = 0.10f;
    }
    // function to load the default values
    public static void LoadDefalutData(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Defaults));
        FileStream horseData = new FileStream(filePath, FileMode.Open);
        defaultHorseStat = serializer.Deserialize(horseData) as Defaults;
        horseData.Close();
    }
}

// Track data values
[Serializable()]
public class TrackData
{
    [XmlAttribute("Rows One")]
    public bool RowOne;
    [XmlAttribute("Rows Two")]
    public bool RowTwo;
    [XmlAttribute("Laps")]
    public int Laps;
    [XmlAttribute("Players")]
    public int Players;
    [XmlAttribute("GaitSpeed")]

    public static TrackData trackData= new TrackData();

    public TrackData() 
    {
        RowOne = RaceConfigurator.RowOneValue;
        RowTwo = RaceConfigurator.RowTwoValue;
        Laps = RaceConfigurator.LapCount;
        Players = RaceConfigurator.NumberOfPlayers;
    }

    // Saving values to the xml file
    public static void Save(string filePath, TrackData trackData)
    {
        SaveData(filePath, trackData);
    }

    // Saving the track data back to the file
    public static void SaveData(string filePath, TrackData trackData)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TrackData));
        FileStream trackInfo = new FileStream(filePath, FileMode.Truncate);
        serializer.Serialize(trackInfo, trackData);
    }

    // Load values
    public static void Load(string filePath)
    {
        LoadData(filePath);
    }
    // Loading the values for the track  back the file.
    public static void LoadData(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TrackData));
        FileStream trackInfo = new FileStream(filePath, FileMode.Open);
        trackData = serializer.Deserialize(trackInfo) as TrackData;
        trackInfo.Close();
    }
}
// Load the values to the player
[Serializable()]
public class HorseStats
{
    [XmlAttribute("Speed")]
    public float Speed;
    [XmlAttribute("Heart")]
    public float Heart;
    [XmlAttribute("Stamina")]
    public float Stamina;
    [XmlAttribute("GaitSpeed")]
    public float GaitSpeed;
    [XmlAttribute("SpeedAbility")]
    public float SpeedAbility;

    public static HorseStats horseStat = new HorseStats();

    public HorseStats()
    {
        Speed = LoadPlayerData.Speed;
        Heart = LoadPlayerData.Heart;
        Stamina = LoadPlayerData.Stamina;
        GaitSpeed = LoadPlayerData.Gate;
        SpeedAbility = LoadPlayerData.SpeedAbility;
    }

    //Saving the values of the player
    public static void Save(string filePath, HorseStats horse)
    {
        SaveData(filePath,horse);
    }
    // Load the values of the player
    public static void Load(string filePath)
    {
        LoadData(filePath);
    }
    // Saving the values of the player and writing it to the file.
    public static void SaveData(string filePath, HorseStats horse)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(HorseStats));
        FileStream horseData = new FileStream (filePath,FileMode.Truncate);
        serializer.Serialize(horseData, horse);
    }
    // Reading values back from the file and setting up the project
    public static void LoadData(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(HorseStats));
        FileStream horseData = new FileStream(filePath, FileMode.Open);
        horseStat = serializer.Deserialize(horseData) as HorseStats;
        horseData.Close();
    }
}
