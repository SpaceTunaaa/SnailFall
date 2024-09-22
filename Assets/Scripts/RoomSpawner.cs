using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> rooms = new List<GameObject>();
    [SerializeField] int numberOfRooms;
    [SerializeField] float roomHeight;
    [SerializeField] GameObject roomBottom;
    [SerializeField] GameObject roomTop;

    private void Start()
    {
        Instantiate(roomTop, Vector2.zero, Quaternion.identity);
        for (int i = 1; i+1 <= numberOfRooms + 1; i++)
        {
            Instantiate(rooms[Random.Range(0, rooms.Count)], new Vector2(0, roomHeight * -i), Quaternion.identity);
        }
        Instantiate(roomBottom, new Vector2(0, roomHeight * -numberOfRooms -roomHeight/2), Quaternion.identity);
    }
}
