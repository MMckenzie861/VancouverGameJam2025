using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

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

    public void Start()
    {
        playerHealth = 3;
        bossHealth = 20;

        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");

        playerInvulnerable = false;
        bossInvulnerable = false;
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
        if(bossInvulnerable)
        {
            return;
        }

        bossHealth -= damage;

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
        Time.timeScale = 0.0f;

        player.SetActive(false);

        display.Display("You Lose");
    }

    public void Win()
    {
        Time.timeScale = 0.0f;

        display.Display("You Win");
    }
}
