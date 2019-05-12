using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float timer = 0.1f;
    public float specialTimer = 1f;
    public bool special;
    public GameObject swordParticle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer>0)
        {
            timer -= Time.deltaTime;    
        }
        else if (timer <= 0 && !special)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetInteger("attackDir", 5);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMove = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
            Destroy(gameObject);
        }

        if (specialTimer>0)
        {
            specialTimer -= Time.deltaTime;
        }
        else if (specialTimer <= 0 && special)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canAttack = true;
            Debug.Log("SPESIAL");
            swordParticle = Instantiate(swordParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
