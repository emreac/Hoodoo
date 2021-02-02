﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSphere : MonoBehaviour
{
    public NextLevelControl NextLevelControl;
    public GameOverPopUp GameOverPopUp;
    private CoinCounter coinCounter;

    public PlayerSprite PlayerSprite;

    public HealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth;

    public ParticleSystem collectEffect;
    public ParticleSystem clickEffect;

    public Text scoreTextNewLevel;
    public Text scoreText;
    public Text gameOverScoreText;
    private float score;
    private int scoreInt;
    public int scoreLast;
    
    public float movementSpeed;



    private void Start()
    {
        currentHealth = maxHealth;
        score = 0;
        healthBar.SetMaxHealth(maxHealth);
    }

  

    void Update()
    {
  
        score += Time.deltaTime;


        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);


        if (Input.GetMouseButtonDown(0))
        {
            clickEffectFun();
         

        }

      
        


    }
    void FixedUpdate()
    {
        scoreInt = (int)score;
        scoreLast = scoreInt * 10;
        scoreText.GetComponent<Text>().text = "Score: " + scoreLast;
        gameOverScoreText.GetComponent<Text>().text = "Score: " + scoreLast;
        scoreTextNewLevel.GetComponent<Text>().text = "You Have Reached " + scoreLast + " Points" ;

        if(scoreLast >= 100)
        {
            NextLevel();
            Destroy(this.gameObject);
            Destroy(PlayerSprite);



        }
       
 
        if (currentHealth <= 0)
        {
            GameOver();
            Destroy(this.gameObject);
            Destroy(PlayerSprite);
          
           
       //     GameOver();
          //  SceneManager.LoadScene("GameScene");
          
        }
        
    }


    public void GameOver()
    {
        GameOverPopUp.Setup(scoreLast);
    }
 
    public void NextLevel()
    {
        NextLevelControl.Setup(scoreLast);
    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Lantern")
        {
            takeRecover(2);
            healthBar.SetHealth(currentHealth);
            collectEffectFuntion();

        }
           

        if (other.tag == "Enemy")
        {
            takeDamege(20);
            healthBar.SetHealth(currentHealth);
        }
      
    }


    void NextLevelParticles()
    {

    }

    void takeDamege(int damage)
    {
        currentHealth -= damage;
    
    }
    void takeRecover(int recover)
    {
        currentHealth += recover;
    }

    void collectEffectFuntion()
    {
        collectEffect.Play();
    }

    void clickEffectFun()
    {
        clickEffect.Play();
    }
}
