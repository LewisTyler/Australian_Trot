using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RemovePlayer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Button RemovePlayerButton;
    [SerializeField] private GameObject RemoveButton;
    [SerializeField] private DrapDropScript currentSelection;

    private void Start()
    {
        // Using Unity events to listen for any click events
        RemovePlayerButton.onClick.AddListener(OnRemovePlayer);
    }

    // Setting the object back to is pervious place.
    public void OnRemovePlayer()
    {
        // I am looking for parent of the located in the DragDropScript and I look for the name. 
        GameObject FirstParent = GameObject.Find(currentSelection.parentBeforeDrag.transform.name);

        transform.SetParent(FirstParent.transform);// I then set the of tranform back to the parent.
        transform.SetSiblingIndex(currentSelection._siblingIndex);// I also set the transform back to its original index before it was moved.
        RemoveButton.SetActive(false);// I then hide the remove button.
    }

    // I am using IPointer for check to see if I have clicked on the object.
    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.parent != currentSelection.parentBeforeDrag)// If parent of the transform is not equal to the first parent that is assigned on start.
        {
            Debug.Log("Clicked");
            if (Input.GetMouseButtonUp(1))// I look to see if the left mouse button is pressed
            {
                RemoveButton.SetActive(true);// Set the remove button to true.
            }
            if (Input.GetMouseButtonUp(0))// Left mouse button is pressed
            {
                RemoveButton.SetActive(false); // Set the remove button to false.
            }
        }
    }
}
