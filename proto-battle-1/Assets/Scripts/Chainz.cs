using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chainz : MonoBehaviour {
    //static Player.directionFacedModifier;
    public GameObject ChainZPrefab;
    public Transform ChainSpawn;
    private float directionFacedModifier = 1f;

    void Update() {
        
        if (Input.GetMouseButtonDown(0)) {
            print("click");
            Fire();
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        //print("hit");
        print(coll.gameObject.tag);
        // If the Collider2D component is enabled on the collided object
        if (coll.gameObject.tag == "mob") {
            // Disables the Collider2D component
            //..coll.collider.enabled = false;
            print(coll.gameObject.tag);
        }
    }


    void Fire() {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            ChainZPrefab,
            ChainSpawn.position,
            ChainSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(6 * directionFacedModifier, GetComponent<Rigidbody2D>().velocity.y); //bullet.transform.forward * 6;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
