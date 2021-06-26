using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Windows;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RoundsManager : MonoBehaviour
{

    [SerializeField] private List<AnimalSprite> animalSprits;
    [SerializeField] private List<AnimalSprite> toplay;
    [SerializeField] int round;
    [SerializeField] GameObject[] imageHolders;
    [SerializeField] GameObject[] starsPanels;
    [SerializeField] GameObject playAgainPanel;
    [SerializeField] Timer timer;
    [SerializeField] Text coinText;
    public AttemptsCounter attemptsCounter;
    public int attempts;
    public int correctAnswers;
    public int coins;
    public int starCount;
    // Start is called before the first frame update
    void Start()
    {
        round = 0;
        coins = 0;
        toplay = new List<AnimalSprite>();
        for (int i = 0; i < 30; i++)
        {
            var spirit = animalSprits[Random.Range(0, animalSprits.Count)];
            toplay.Add(spirit);
            animalSprits.Remove(spirit);

        }
        getNumberOfStars();
        setRound();
    }
    public void collectCoin()
    {
        coins += (starCount == 3) ? 100 : (starCount == 2) ? 60 : (starCount == 1) ? 30 : 10;
        
    }
    public void getNumberOfStars()
    {
        starCount = (attemptsCounter.attempts == 1) ? 3 : (attemptsCounter.attempts < 4) ? 2 : (attemptsCounter.attempts < 6) ? 1 : 0;
    }
    public void setRound()
    {

        
        if (toplay.Count >= 3)
        {

            timer.enabled = true;
            timer.setTimer(60);
            initImage(); 
            
            
            correctAnswers = 0;
            round++;
        }
        else
        {
            //no more rounds
            //TODO:add end menu
        }
    }

     public void checkEndRound()
    {
        if (correctAnswers == 3)
        {
            updateCoinsGUI();
            
            timer.enabled = false;
            if (toplay.Count == 0)
            {
                playAgainPanel.SetActive(true);
            }
            else
            {
                starsPanels[starCount].SetActive(true);
            }
         
        }
    }
   
    public void initImage()
    {
        for (int i = 0; i < 3; i++)
        {
            imageHolders[i].GetComponent<SpriteRenderer>().sprite = toplay[i].animalSprit;
            var imgData = imageHolders[i].GetComponent<ImageData>();
            imgData.nameImage = toplay[i].animalName;
            imgData.init();

        }
        int aux = 3;
        for (int i = 3; i < 6; i++)
        {
            int rand = Random.Range(0, aux);

            var imgData = imageHolders[i].GetComponent<ImageData>();

            imgData.nameImage = toplay[rand].animalName;
            imgData.init();
            toplay.RemoveAt(rand);
            aux--;
        }
    }
    public void updateCoinsGUI()
    {
        collectCoin();
        coinText.text = coins.ToString();
    }
    
    
}
