using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilsModule;

public class GameManager : Singleton<GameManager>
{
    public Transform player;
    public List<LeverInteract> levers = new List<LeverInteract>();
    public ExitDoorScript exitDoorScript;
    int nbLeverActivated = 0;

    public void LeverActivated()
    {
        nbLeverActivated++;
        exitDoorScript.ActivateLights(nbLeverActivated);
        if(nbLeverActivated >= levers.Count)
        {
            exitDoorScript.OpenDoor();
        }
    }
    public void NextLevel()
    {

    }
}
