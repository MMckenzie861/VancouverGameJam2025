using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float playerHealth;
    public float bossHealth;
    public float healDelay;
    public float iFrameTime;
    private bool playerInvulnerable;
    private bool bossInvulnerable;
    private GameObject player;
    private GameObject boss;
    public DisplayText display;
    private Coroutine healCoroutine;
    private int oneHp = 3;
    private int twoHp = 3;
    private int threeHp = 3;
    private CircleHitDetection circleManager;
    public HealthBar healthBar;
    private float maxBossHealth;

    public void Start()
    {
        playerHealth = 3;
        bossHealth = 3;
        maxBossHealth = 3;

        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");

        playerInvulnerable = false;
        bossInvulnerable = false;

        circleManager = player.GetComponent<CircleHitDetection>();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Hit(1);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Win();
        }
    }

    public void IndividualHit(int index, int damage) {
        if(playerInvulnerable)
        {
            return;
        }
        
        if (index == 1) {
            oneHp -= damage;
            circleManager.UpdateHpVisual(index, oneHp);
        }
        if (index == 2) {
            twoHp -= damage;
            circleManager.UpdateHpVisual(index, twoHp);
        }
        if (index == 3) {
            threeHp -= damage;
            circleManager.UpdateHpVisual(index, threeHp);
        }
        display.Display("one: " + oneHp.ToString() + " two: " + twoHp.ToString() + " three: " + threeHp.ToString());



        if(oneHp <= 0 || twoHp <= 0 || threeHp <= 0)
        {
            Lose();
        }

        if (healCoroutine != null)
        {
            StopCoroutine(healCoroutine);
        }

        healCoroutine = StartCoroutine(PartialHeal());

        StartCoroutine(IFrames(iFrameTime, player));
    }

    public void Hit(float damage)
    {
        if(playerInvulnerable)
        {
            return;
        }

        playerHealth -= damage;

        display.Display(playerHealth.ToString());

        if(playerHealth <= 0)
        {
            Lose();
        }

        if (healCoroutine != null)
        {
            StopCoroutine(healCoroutine);
        }

        healCoroutine = StartCoroutine(Heal());

        StartCoroutine(IFrames(iFrameTime, player));
    }

    public void BossHit(float damage)
    {
        Debug.Log("Hit Boss");

        if(bossInvulnerable)
        {
            return;
        }

        bossHealth -= damage;
        healthBar.UpdateHealthBar(bossHealth, maxBossHealth);

        if(bossHealth <= 0)
        {
            boss.SetActive(false);

            Win();
        }

        StartCoroutine(IFrames(iFrameTime, boss));
    }
    
    public IEnumerator Heal()
    {
        while (playerHealth < 3)
        {
            yield return new WaitForSeconds(healDelay);
            playerHealth++;

            display.Display(playerHealth.ToString());
        }

        healCoroutine = null;
    }

    public IEnumerator PartialHeal()
    {
        while (oneHp < 3 || twoHp < 3 || threeHp < 3)
        {
            yield return new WaitForSeconds(healDelay);
                if (oneHp < 3)
                {
                    oneHp++;
                }
                
                if (twoHp < 3)
                {
                    twoHp++;
                }
                
                if (threeHp < 3)
                {
                    threeHp++;
                }

            display.Display("one: " + oneHp.ToString() + " two: " + twoHp.ToString() + " three: " + threeHp.ToString());
            circleManager.UpdateHpVisual(1, oneHp);
            circleManager.UpdateHpVisual(2, twoHp);
            circleManager.UpdateHpVisual(3, threeHp);
        }

        healCoroutine = null;
    }

    public IEnumerator IFrames(float seconds, GameObject obj)
    {
        if (obj.tag == "Player")
        {
            playerInvulnerable = true;
        }
        else if (obj.tag == "Boss")
        {
            bossInvulnerable = true;
        }

        yield return new WaitForSeconds(seconds);

        if (obj.tag == "Player")
        {
            playerInvulnerable = false;
        }
        else if (obj.tag == "Boss")
        {
            bossInvulnerable = false;
        }
    }

    public void Lose()
    {
        player.SetActive(false);

        display.Display("You Lose");

        SceneManager.LoadScene("TitleScreen");
    }

    public void Win()
    {
        display.Display("You Win");

        SceneManager.LoadScene("TitleScreen");
    }
}
