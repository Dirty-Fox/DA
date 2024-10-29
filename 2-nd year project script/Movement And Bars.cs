using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{  
    //Camera
    float horX, horY;// - Dima - я так понял это не камера а мувмент, но я не тыкал, ты знаешь ты если надо поменяешь 
   

    //Movement
    public float originalMovSpeed = 5f;
    public float movSpeed = 5f;
    public float sprintSpeed = 10f;
    public Rigidbody rb;

    //Jumping
    public float jumpForce = 10f;
    public bool midAir = false;

    //Stamina
    public Image staminaBar;
    public float stamina, maxStamina;
    public float runCost;
    bool running = false;
    public float chargeRate;
    private Coroutine recharge;

    //Hunger
    public Image hungerBar;
    public float hunger;
    public float maxHunger;
    public float passiveHungerReduction;

    //Health
    public Image healthBar;
    public float health;
    public float maxHealth;
    public float hpLoss;

    //Thirst
    public Image thirstBar;
    public float thirst;
    public float maxThirst;
    public float thirstLoss;


    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //Mouse Control
        if (MenuManager.menuActive == false)
        {
            horX = Input.GetAxis("Vertical");
            horY = Input.GetAxis("Horizontal");
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(0, mouseX, 0);
        }

        //Jumping
        if (Input.GetKeyDown("space") && midAir == false)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            midAir = true;
            running = false;
        }
        

        //Shifting
        if (Input.GetKeyDown("left shift") && midAir == false)
        {
            running = true;
        }
        if (Input.GetKeyUp("left shift"))
        {
            running = false;
        }



        if (running)//=true
        {
            movSpeed = sprintSpeed;
            stamina -= runCost * Time.deltaTime;

            if (stamina < 0)
            {
                stamina = 0;
                movSpeed = originalMovSpeed;
                running = false;
            }

            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(RechargeStamina());

        }
        else
        {
            movSpeed = originalMovSpeed;
        }

        //0 hunger = HP loss
        if (hunger == 0) 
        {

            health -= hpLoss * Time.deltaTime ;

        }

        //UI display section
        healthBar.fillAmount = health / maxHealth;
        hungerBar.fillAmount = hunger / maxHunger;
        staminaBar.fillAmount = stamina / maxStamina;
        thirstBar.fillAmount = thirst / maxThirst;
    }

    void FixedUpdate()
    {
        //rb.velocity = ((transform.forward horY) +(transform.right * horX)) *
        //movSpeed * Time.fixedDeltaTime + new Vector3(0, rb.velocity.y, 0);
        //rb.AddRelativeForce(direction movSpeed * Time.deltaTime, ForceMode.Force);
        //rb.MovePosition(transform.position + (direction * movSpeed * Time.deltaTime));

        //Moving scripts

        rb.MovePosition(transform.position + ((transform.forward * horY) + (transform.right * -horX)) * movSpeed * Time.fixedDeltaTime);

    }

    void OnCollisionEnter(Collision other)
    {

        midAir = false;

    }



    //Custom methods



    private IEnumerator RechargeStamina() //Delay on stamina regen and hunger cost for it
    {

        yield return new WaitForSeconds(3f);

        while (stamina < maxStamina)//While stamina is not full && !running
        {
            stamina += chargeRate; //Stamina regens

            //Since stamina  regens, other attributes drains
            hunger -= passiveHungerReduction; //Hunger drains
            thirst -= thirstLoss;//Thirst drains

            if (stamina > maxStamina) stamina = maxStamina; // To prevent stamina to go goofy numbers
            yield return new WaitForSeconds(.3f);
        }
    }
}
