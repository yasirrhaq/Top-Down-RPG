using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed;

    public Animator anim;

    public List<Image> heart;
    public int maxPlayerHealth = 5;
    public int startingPlayerHealth = 3;
    public int currentPlayerHealth;

    public GameObject sword;
    public float thrustPower;
    public bool canMove;
    public bool canAttack;

    void Start()
    {
        anim = GetComponent<Animator>();
        maxPlayerHealth = heart.Count;
        currentPlayerHealth = startingPlayerHealth;
        displayHealth();
        canMove = true;
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.P)&& currentPlayerHealth >0)
        {
            currentPlayerHealth--;
            DamageTaken();
        }
        if (Input.GetKeyDown(KeyCode.O) && currentPlayerHealth < maxPlayerHealth)
        {
            currentPlayerHealth++;
        }
        displayHealth();

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void displayHealth()
    {

        for (int i = 0; i < currentPlayerHealth; i++)
        {
            heart[i].gameObject.SetActive(true);
        }
    }

    void DamageTaken()
    {
        for (int i = 0; i < heart.Count; i++)
        {
            heart[i].gameObject.SetActive(false);
        }
    }

    void Attack()
    {

        if (canAttack)
        {
            canAttack = false;
            canMove = false;
            GameObject newSword = Instantiate(sword, transform.position, sword.transform.rotation);
            if (currentPlayerHealth == maxPlayerHealth)
            {
                newSword.GetComponent<Sword>().special = true;
                canMove = true;
                thrustPower = 300;
            }
            else
            {
                thrustPower = 250;
                newSword.GetComponent<Sword>().special = false;
            }
            #region sword rotation
            int swordDir = anim.GetInteger("dir");
            anim.SetInteger("attackDir", swordDir);
            if (swordDir == 0)
            {
                newSword.transform.Rotate(0, 0, 0);
                newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.up * thrustPower);
            }
            else if (swordDir == 1)
            {
                newSword.transform.Rotate(0, 0, 180);
                newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.down * thrustPower);

            }
            else if (swordDir == 2)
            {
                newSword.transform.Rotate(0, -0, 90);
                newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.left * thrustPower);

            }
            else if (swordDir == 3)
            {
                newSword.transform.Rotate(0, 0, -90);
                newSword.GetComponent<Rigidbody2D>().AddForce(Vector2.right * thrustPower);
            }
        }
        #endregion
    }

    void Movement()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, movementSpeed * Time.deltaTime, 0);
                anim.SetInteger("dir", 0);
                anim.speed = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, -movementSpeed * Time.deltaTime, 0);
                anim.SetInteger("dir", 1);
                anim.speed = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-movementSpeed * Time.deltaTime, 0, 0);
                anim.SetInteger("dir", 2);
                anim.speed = 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(movementSpeed * Time.deltaTime, 0, 0);
                anim.SetInteger("dir", 3);
                anim.speed = 1;
            }
            else
            {
                anim.speed = 0;
            }
        }
    }
}