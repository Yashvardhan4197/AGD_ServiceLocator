using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{ 
    public PlayerService playerService {  get; private set; }
    public SoundService soundService { get; private set; }
    public EventService eventService { get; private set; }
    public MapService mapService { get; private set; }
    public WaveService waveService { get; private set; }

    [SerializeField] private UIService uIService;
    public UIService UIService=> uIService;

    [SerializeField] public PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private MapScriptableObject mapScriptableObject;
    [SerializeField] private WaveScriptableObject waveScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;

  

    void Start()
    {
        eventService = new EventService();
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        playerService=new PlayerService(playerScriptableObject);
        mapService = new MapService(mapScriptableObject);
        waveService=new WaveService(waveScriptableObject);
        //eventService=new EventService();
        UIService.SubscribeToEvents();
    }

    void Update()
    {
        playerService.Update();
    }
}
