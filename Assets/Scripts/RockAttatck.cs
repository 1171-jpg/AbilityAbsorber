using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttatck : MonoBehaviour
{
    public float duration = 0.5f;
    public GameObject player;
    private AbilityManager abilityManager;
    public GameObject RockPrefab;
    public float playerAttackRadius;
    public float RockAttackRadius;
    string debugText = "";
    void Start()
    {
        abilityManager = player.GetComponent<AbilityManager>();
    }

    void OnGUI()
    {
        GUI.contentColor = Color.red;
        GUI.Label(new Rect(20, 20, 250, 250), debugText);
    }

    void RockAttack() 
    {
        Vector2 spawnPosition = transform.position; //get position
        GameObject newrock = Instantiate(RockPrefab, spawnPosition, Quaternion.identity);
        Destroy(newrock, duration);
        Vector2 rockposition = transform.position;
        Vector2 playerposition = player.transform.position;
        float distance = Vector3.Distance(rockposition, playerposition);
        if (distance <= RockAttackRadius)
        {
            debugText = "Game Over";
            Debug.Log(debugText);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && abilityManager.getSelectedAbility() == "fire")
        {
            Vector2 rockposition = transform.position;
            Vector2 playerposition = player.transform.position;
            float distance = Vector3.Distance(rockposition, playerposition);

            Debug.Log(distance);
            if (distance <= playerAttackRadius)
            {
                // wait for 3 seconds.
                // create circle rock attack.
                Invoke("RockAttack", 1f);

            }
 

        }
    }
}
