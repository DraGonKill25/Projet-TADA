using Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealGlobalpretre : MonoBehaviour
{
    public GameObject Player;
    private bool special = true;
    private float timer2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action_2"))))
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            foreach(GameObject player in players)
            {
                ViePerso stats = player.GetComponent<ViePerso>();
                stats.pV += (int)(Player.GetComponent<PlayerStats>().Attributes[1].amount * 0.01) + Player.GetComponent<PlayerStats>().item.Damage;
            }
        }

        if(Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action_3"))) && special)
        {
            special = false;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            foreach(GameObject player in players)
            {
                ViePerso stats = player.GetComponent<ViePerso>();
                stats.pV = stats.SaveMaxHP;
            }
        }
        else if (!special)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 15f)
            {
                special = true;
                timer2 = 0;
            }
        }
    }
}
