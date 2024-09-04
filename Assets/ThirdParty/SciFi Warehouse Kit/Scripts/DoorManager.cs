using System;
using UnityEngine;

class DoorManager : MonoBehaviour
{
    [SerializeField]
    private LevelDoors[] levelDoors;

    private int currentIndex;

    public void GoToNext()
    {
        currentIndex++;

        if (currentIndex >= levelDoors.Length)
            currentIndex = 0;

        ToggleLevel();
    }

    public void ToggleLevel()
    {
        int prev = currentIndex - 1;

        if (prev < 0)
            prev = levelDoors.Length - 1;

        for (int i = 0; i < levelDoors[prev].doors.Length; i++)
        {
            var door = levelDoors[prev].doors[i];
            door.door.SetPosition(door.offPosition);
        }

        for (int i = 0; i < levelDoors[currentIndex].doors.Length; i++)
        {
            var door = levelDoors[currentIndex].doors[i];
            door.door.SetPosition(door.onPosition);
        }
    }

    [Serializable]
    public class LevelDoors
    {
        public LevelDoor[] doors;
    }

    [Serializable]
    public class LevelDoor
    {
        public DoorScript door;
        
        [Range(0, 1)]
        public float onPosition;

        [Range(0, 1)]
        public float offPosition;
    }
}