using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DRIVE : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] Color32 BoostedCar;
    [SerializeField] Color32 NoBoostedCarColor;
    [SerializeField] TextMeshProUGUI HealthText;
    public int health;
    SpriteRenderer spriteRenderer;
    bool check=false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        HealthText.text = ("Health= ") + health;
    }


        // Update is called once per frame
        void Update()
        {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            transform.Translate(0, moveAmount, 0);
             HealthText.text = ("Health= ") + health;
    }
       
    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.tag == "Boost")
        {
            Debug.Log("Boosted");
            //hasPackage = false;
            moveSpeed = 20;
            spriteRenderer.color = BoostedCar;
            Destroy(collision.gameObject, 0.5f);
            check = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OUCH");
        if (check == true)
        {
            Debug.Log("Boost Finished");
            moveSpeed = 10;
            spriteRenderer.color = NoBoostedCarColor;
        }
        check = false;
        
        if(health==0)
        {
            //Destroy(collision.gameObject, 0.5f);
            //Destroy(GameObject.FindWithTag("Player"));
            Debug.Log(" GAME OVER CAR DESTROYED");
        }
        else
        {
            health = health - 25;
            Debug.Log("Health Reduced");
        }

    }
}
