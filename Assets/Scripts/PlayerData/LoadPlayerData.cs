using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEditorInternal;

public class LoadPlayerData : MonoBehaviour
{
    [SerializeField] private PlayerData mainPlayerInfo;
    [SerializeField] private TMP_Text NameOfHorse;
    [SerializeField] private Image SpeedValue;
    [SerializeField] private Image HeartValue;
    [SerializeField] private Image StaminaValue;
    [SerializeField] private Image GateValue;
    [SerializeField] private Image SpeedAbilityValue;

    private string statsPath = @"C:\TrotApplication\System\UserSettings\Horse_Data.xml";// This is hard coded for now but will need to be flexible
    public static float Speed;
    public static float Heart;
    public static float Stamina;
    public static float Gate;
    public static float SpeedAbility;

    private float minLowRange;
    private float maxRange;

    private void Start()
    {
        minLowRange = 0.25f;// I am using this to set the minimum value so I only have to change it here and not everywhere else.
        maxRange = 0.85f;// The same as the above comment.

        try // I put eveything into a try catch so the application does not die completely
        {
            if (!File.Exists(statsPath)) // I check to see if statsPath does not exists in the C: drive
            {
                File.Create(statsPath); // If the file does not exist in statsPath then I create the file.

                if (File.Exists(statsPath)) // I then check again onece the file is created and then execute
                {
                    // Set all values to 50%
                    Speed = 0.50f;
                    Heart = 0.50f;
                    Stamina = 0.50f;
                    Gate = 0.50f;
                    SpeedAbility = 0.50f;

                    // I then set all the xml values to the 50% to set the default values.
                    HorseStats.horseStat.Speed = Speed;
                    HorseStats.horseStat.Heart = Heart;
                    HorseStats.horseStat.Stamina = Stamina;
                    HorseStats.horseStat.GaitSpeed = Gate;
                    HorseStats.horseStat.SpeedAbility = SpeedAbility;
                    LoadDefaultData();// I then load the default values.
                }
            }

            else if (File.Exists(statsPath))// I check to see if the file exists
            {
                HorseStats.Load(statsPath);// I then call Load to load the last saved data
                LoadLastSavedData(); // I then load the last saveed data
            }
        }
        catch
        {
            /**/
        }
    }

    // Loading default data. 
    void LoadDefaultData()
    {
        NameOfHorse.text = mainPlayerInfo.playerStats.PlayerName;
        SpeedValue.fillAmount = Speed;
        HeartValue.fillAmount = Heart;
        StaminaValue.fillAmount = Stamina;
        GateValue.fillAmount = Gate;
        SpeedAbilityValue.fillAmount = SpeedAbility;
    }

    // Load the last saved data
    void LoadLastSavedData()
    {
        NameOfHorse.text = mainPlayerInfo.playerStats.PlayerName; // I call the name of the player from the scriptable object

        try
        {
            Speed = Random.Range(minLowRange, maxRange);
            Heart = Random.Range(minLowRange, maxRange);
            Stamina = Random.Range(minLowRange, maxRange);
            Gate = Random.Range(minLowRange, maxRange);
            SpeedAbility = Random.Range(minLowRange, maxRange);

            SpeedValue.fillAmount = Speed;
            HeartValue.fillAmount = Heart;
            StaminaValue.fillAmount = Stamina;
            GateValue.fillAmount = Gate;
            SpeedAbilityValue.fillAmount = SpeedAbility;
        }
        catch { /**/}
    }

    // I am saving the data
    public void OnSaveData()
    {
        HorseStats.horseStat.Speed = Speed;
        HorseStats.horseStat.Heart = Heart;
        HorseStats.horseStat.Stamina = Stamina;
        HorseStats.horseStat.GaitSpeed = Gate;
        HorseStats.horseStat.SpeedAbility = SpeedAbility;
    }
}
