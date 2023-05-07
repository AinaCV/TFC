using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;
    public float runSpeed = 10f;
    public float gravityforce = 50f;
    public int health;
    public int maxHealth = 10;
    public float stamina;
    public float maxStamina = 10;
    public float recoverStaminaMaxTime = 5;
    public float recoverStamina;
    //Animator anim;
    [Header("Bools")]
    //public bool attack;
    public bool isRegenerating = false;
    public bool isRunning = false;
    public bool isWalking = false;


    public static Player Instance; //tiene que ser static para la health y stamina bar

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        health = maxHealth;
        stamina = maxStamina;
    }

    void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        if (stamina < maxStamina && isRegenerating)
        {
            stamina += Time.deltaTime;
        }

        if (stamina > maxStamina)
        {
            stamina = maxStamina;
            isRegenerating = false;
        }

        if (stamina < 0)
        {
            stamina = 0;
        }

        if (Input.GetKey("left shift"))
        {
            isRunning = true;
            isRegenerating = false;
        }
        else
        {
            isRegenerating = true;
            isRunning = false;

        }

        Move();
        //Stamina();
        //Attack();
        //Death();
    }

    void Move()
    {
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool backwardPressed = Input.GetKey("s");
        bool rightPressed = Input.GetKey("d");
        bool runPressed = Input.GetKey("left shift");

        if (runPressed && (forwardPressed || backwardPressed || rightPressed || leftPressed))
        {
            isRunning = true;
            isWalking = false;
        }
        else if (forwardPressed || backwardPressed || rightPressed || leftPressed)
        {
            isWalking = true;
            isRunning = false;
        }
        else
        {
            isWalking = false;
            isRunning = false;
        }

        if (isWalking)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 movement = transform.right * x + transform.forward * z + transform.up * -gravityforce;
            movement *= Time.deltaTime * speed;
            movement.y /= speed;
            controller.Move(movement);
        }

        else if (isRunning)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 movement = transform.right * x + transform.forward * z + transform.up * -gravityforce;
            movement *= Time.deltaTime * runSpeed;
            movement.y /= runSpeed;
            controller.Move(movement);
        }
    }

    //void Stamina()
    //{
    //    if (isRunning)
    //    {
    //        stamina -= Time.deltaTime;
    //    }

    //    if (stamina <= 0)
    //    {
    //        isRunning = false;
    //    }

    //    if (isRunning == false)
    //    {
    //        recoverStamina += Time.deltaTime;
    //        if (recoverStamina >= recoverStaminaMaxTime)
    //        {
    //            isRegenerating = true;
    //            recoverStamina = 0;
    //        }
    //    }
    //}

    //public void Attack() //que solo ataque si no hay menus por enmedio
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        attack = true;
    //    }
    //    else
    //    {
    //        attack = false;
    //    }
    //}

    //private void Death()
    //{
    //    if (health <= 0)
    //    {
    //        SceneManager.LoadScene("Menu");
    //        StartCoroutine(NewGameCoroutine());
    //    }
    //}

    //IEnumerator NewGameCoroutine()
    //{
    //    yield return new WaitForSeconds(2.0f);
    //}
}
