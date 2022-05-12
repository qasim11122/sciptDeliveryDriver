using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool hasPackage;
    [SerializeField] Color32  hasPackagecolor;
    [SerializeField] Color32  noPackagecolor;
    SpriteRenderer spriteRenderer;
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OUCH");
    }*/
    void Start()
    {
        spriteRenderer=GetComponent <SpriteRenderer> ();
    }

    private void  OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Package" && !hasPackage)
        {
            Debug.Log("package picked up");
            hasPackage=true;
            Destroy(collision.gameObject,0.5f);
            spriteRenderer.color=hasPackagecolor;
            
        
        }
        if(collision.tag=="Customers" && hasPackage)
        {
             Debug.Log("Customer recieved package");
             hasPackage=false;
           spriteRenderer.color=noPackagecolor;
        }
       
    }
}