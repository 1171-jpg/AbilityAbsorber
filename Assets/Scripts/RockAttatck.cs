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
    void Start()
    {
        abilityManager = player.GetComponent<AbilityManager>();
    }

    void RockAttack() 
    {
        Vector2 spawnPosition = transform.position; //get position
        GameObject newrock = Instantiate(RockPrefab, spawnPosition, Quaternion.identity);
        Destroy(newrock, duration);
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
