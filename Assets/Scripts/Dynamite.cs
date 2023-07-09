using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("FireAbility")) {
            print("exploding dynamite");
            // create circle dynamite explosion radius
            Vector2 spawnPosition = transform.position;
            GameObject newfire = Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);
            Destroy(newfire, 2f);
        }
    }
}