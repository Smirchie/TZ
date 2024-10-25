using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruckItemCounter : MonoBehaviour
{
    private int itemsInTruck = 0;
    [SerializeField] private int itemsToCollectAmount = 9;
    [SerializeField] private Image endGameScreen;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PickableItem"))
        {
            itemsInTruck += 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickableItem"))
        {
            itemsInTruck += 1;
            if (itemsInTruck >= itemsToCollectAmount)
            {
                endGameScreen.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
