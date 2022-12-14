using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    
    [SerializeField] public List<GameObject> rooms;
    [SerializeField] public GameObject endRoom;
    
    [SerializeField] public int roomsSpawnLimit;
    public int roomsSpawned;
    
    public bool pause;

    private void Start()
    {
        pause = false;
        DisplayCoins();
    }

    public void DisplayCoins()
    {
        if (!coinsText.IsUnityNull())
        {
            coinsText.text = DataHolder.coins.GetCoins().ToString();
        }
    }
    
    public static void Begin()
    {
        Timer.Begin();
    }
    
    public void Pause()
    {
        pause = true;
        Timer.Pause();
    }
    
    public void Unpause()
    {
        pause = false;
        Timer.Unpause();
    }

    public void End()
    {
        Timer.End(pause);
    }
}
