using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int playerHealth;
    private GameObject player;
    public DisplayText display;
    private Coroutine healCoroutine;

    public void Start()
    {
        playerHealth = 3;

        player = GameObject.FindGameObjectWithTag("Player");
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
    }

    public IEnumerator Heal()
    {
        while (playerHealth < 3)
        {
            yield return new WaitForSeconds(3);
            playerHealth++;

            display.Display(playerHealth.ToString());
        }

        healCoroutine = null;
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
