using ServiceLocator.Player;
using ServiceLocator.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{ 
    public PlayerService playerService {  get; private set; }
    [SerializeField] public PlayerScriptableObject playerScriptableObject;

    void Start()
    {
        playerService=new PlayerService(playerScriptableObject);
    }

    void Update()
    {
        playerService.Update();
    }
}
