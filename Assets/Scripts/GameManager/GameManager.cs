using System.Collections.Generic;
using ControllerModule.Controllers;
using UnityEngine;
using UtilsModule;

public class GameManager : Singleton<GameManager>
{
    public Controller player;
    public MazeGenerator mazeGenerator;

    private void Start()
    {
        this.NextLevel();
    }


    public void NextLevel()
    {
        // Generate maze
        mazeGenerator.BuildMaze();

        // Place player
        
    }

    public void NextLevelSequence()
    {
        // Fondu au noir
        // Désactiver le joueur
        player.enabled = false;
    }

    #region Levers

    public ExitDoorScript exitDoorScript;
    public List<LeverInteract> levers = new List<LeverInteract>();
    int nbLeverActivated = 0;
    public void LeverActivated()
    {
        nbLeverActivated++;
        exitDoorScript.ActivateLights(nbLeverActivated);
        if (nbLeverActivated >= levers.Count)
        {
            exitDoorScript.OpenDoor();
        }
    }

    #endregion
}
