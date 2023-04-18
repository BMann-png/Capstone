using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject[] Rooms;
    
    public void OnRoomChange(int room)
    {
        foreach (GameObject g in Rooms)
        {
            g.SetActive(false);
        }
        Rooms[room].SetActive(true);
    }

}
