using System.Collections.Generic;
using ControllerModule.Controllers;
using UnityEngine;
using UnityEngine.UI;
using UtilsModule;

public class GameManager : Singleton<GameManager>
{
    protected override bool DestroyOnLoad => true;

    public Controller player;
    public MazeGenerator mazeGenerator;
    public GameOver gameOver;
    private void Start()
    {
        difficulty = 0;
        this.NextLevel();
    }

    public void PlayerDeath()
    {
        gameOver.isDead = true;
        player.enabled = false;
    }

    #region Next Level

    [SerializeField]
    private Enemy[] enemiesToSpawn;

    private static int difficulty;

    public void NextLevel()
    {
        // Generate maze
        mazeGenerator.BuildMaze(10, 10);

        // Activate enemies
        foreach (var item in enemiesToSpawn)
        {
            item.IncreaseDifficulty(difficulty);
            item.target = player.transform;
            item.gameObject.SetActive(true);
        }
    }

    public void NextLevelSequence()
    {
        // Fondu au noir
        // Désactiver le joueur
        player.enabled = false;

        difficulty++;
    }

    #endregion

    #region Levers

    public ExitDoorScript exitDoorScript;
    public List<LeverInteract> levers = new List<LeverInteract>();
    public Image[] lightsUI;
    public Sprite OnLight;
    public Sprite OffLight;
    int nbLeverActivated = 0;
    public void LeverActivated()
    {
        nbLeverActivated++;
        exitDoorScript.ActivateLights(nbLeverActivated);

        for (int i = 0; i < nbLeverActivated; i++)
            lightsUI[i].sprite = OnLight;

        if (nbLeverActivated >= levers.Count)
            exitDoorScript.OpenDoor();
    }

    #endregion
}
