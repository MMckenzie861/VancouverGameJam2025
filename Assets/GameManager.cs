using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private int playerHealth;
    public float healDelay;
    public float iFrameTime;
    private bool invulnerable;
    private GameObject player;
    public DisplayText display;
    private Coroutine healCoroutine;

    public void Start()
    {
        playerHealth = 3;

        player = GameObject.FindGameObjectWithTag("Player");

        invulnerable = false;
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

    public void Hit(int damage)
    {
        if(invulnerable)
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

        StartCoroutine(IFrames(iFrameTime));
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

    public IEnumerator IFrames(float seconds)
    {
        invulnerable = true;

        yield return new WaitForSeconds(seconds);

        invulnerable = false;
    }

    public void Lose()
    {
        player.SetActive(false);

        display.Display("You Lose");
    }

    public void Win()
    {

        display.Display("You Win");
    }
}
