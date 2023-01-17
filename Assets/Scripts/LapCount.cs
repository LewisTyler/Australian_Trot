using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapCount : MonoBehaviour
{
    public int LapValue;
    [SerializeField] private TMP_Text LapText;
    [SerializeField] private Button IncrementButton;
    [SerializeField] private Button DecrementButton;

    void Start()
    {
        // I am using the Unity event systems to list for the click event 
        IncrementButton.onClick.AddListener(IncrementLap);
        DecrementButton.onClick.AddListener(DecrementLap);
    }

    // Here I am incrementing the number laps based on when the player clicks the plus button.
    public void IncrementLap()
    {
        if(LapText != null) // I am checking to see if the number of laps is never null 
        {                   // Then I check to see if the LapValue is less than or equal to 9
            if(LapValue <= 9) // If the condition is met then the I will start incrementing the LapValue
            {
                ++LapValue;
                TrackData.trackData.Laps = LapValue; // I make sure I set the Laps value in the xml class which can be found in PlayData.cs.
                LapText.text = LapValue.ToString();// I can Parse the int value of LapValue to a string and pass it to LapText.text
            }
            else
            {
                LapValue = 9;// I set the max amount of laps to 9.
            }

        }
    }

    // Here I am reducing the amount of laps the player clicks using the minus button.
    // I then do the same steps again.
    public void DecrementLap()
    {
        if(LapText != null) 
        {
            if(LapValue >= 2)
            {
                --LapValue;
                TrackData.trackData.Laps = LapValue;
                LapText.text = LapValue.ToString();
            }
            else
            {
                LapValue = 2;
            }
        }
    }
}
