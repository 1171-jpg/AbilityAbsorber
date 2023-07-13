using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluePuddle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Explosion") || other.gameObject.CompareTag("FireAbility")) {
            if (gameObject.name != "GlueBottle") { //if self is bottle, don't remove bottle
                print("glue removed by fire/explosion");
                Destroy(this.gameObject);
            }
        }
        
    }
}
