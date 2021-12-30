using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grandma : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 targetPos;
    public float Yincrement;

    public float YSpeed;
    public float maxHeight;
    public float minHeight;

    public int health;
    public bool jumping = false;
    public bool smashing = false;
    private float DistanceRN;
    private float jumpingtime = 3;
    private float smashingtime = 2;

    public float DistanceTravelled;
    public float XSpeed;
    public float MaxSpeed;
    private int CurrentLane = 2;
    public bool slowed = false;
    public bool SlowedState = false;
    public int hit;
    public float SpeedDecrease;
    private float SpeedPlaceholder = 0;
    private int NewDistance;

    public Text healthDisplay;
    public Text scoreDisplay;
    public Animator animator;

    void Start()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsSmashing", false);
        hit = 0;
        DistanceTravelled = 0;
        targetPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        healthDisplay.text = "Health: " + health.ToString();
        NewDistance = (int)DistanceTravelled / 2;
        scoreDisplay.text = "Score: " + NewDistance.ToString();

        transform.position = Vector2.MoveTowards(transform.position, targetPos, YSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight && health > 0)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            CurrentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight && health > 0)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            CurrentLane++;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false && smashing == false && health > 0)
        {
            jumping = true;
            DistanceRN = DistanceTravelled;
            animator.SetBool("IsJumping", true);
        }
        else if (Input.GetKeyDown(KeyCode.S) && jumping == false && smashing == false && health > 0)
        {
            smashing = true;
            DistanceRN = DistanceTravelled;
            animator.SetBool("IsSmashing", true);
        }
        if (DistanceTravelled >= DistanceRN + jumpingtime && jumping == true)
        {
            jumping = false;
            animator.SetBool("IsJumping", false);
        }
        if (DistanceTravelled >= DistanceRN + smashingtime && smashing == true)
        {
            smashing = false;
            animator.SetBool("IsSmashing", false);
        }
        if (slowed == true && SlowedState == true)
        {
            hit = 2;
            health--;
            XSpeed = XSpeed - SpeedDecrease;
            slowed = false;
        }
        else if (slowed == true)
        {
            hit = 1;
            SpeedPlaceholder = XSpeed;
            XSpeed = XSpeed - SpeedDecrease;
            SlowedState = true;
            slowed = false;
        }
        if (XSpeed < SpeedPlaceholder - 2)
        {
            XSpeed = SpeedPlaceholder - 2;
        }
        if (XSpeed >= SpeedPlaceholder)
        {
            hit = 0;
            SlowedState = false;
        }
        if (SlowedState == true)
        {
            XSpeed = XSpeed + (float)0.25 * Time.deltaTime * SpeedDecrease;
        }
        else
        {
            XSpeed = Mathf.Pow((float)1.2, (float)0.2 * (Time.timeSinceLevelLoad) - 10) + 5;
            if (XSpeed > MaxSpeed)
            {
                XSpeed = MaxSpeed;

            }
        }
        if (health == 0)
        {
            XSpeed = 0;
            animator.SetBool("IsDead", true);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsSmashing", false);
        }
        else
        {
            animator.SetBool("IsDead", false);
        }
        DistanceTravelled = DistanceTravelled + XSpeed * Time.deltaTime;
        if (CurrentLane == 1)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "lane1";
        }
        if (CurrentLane == 2)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "lane2";
        }
        if (CurrentLane == 3)
        {
            GetComponent<SpriteRenderer>().sortingLayerName = "lane3";
        }
    }
}
