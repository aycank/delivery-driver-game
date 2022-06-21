using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 redPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 bluePackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    public GameObject redPackage;
    public GameObject bluePackage;
    //[Header("Destroy Delay (Seconds)")] public float destroyDelay = 0.5f; 
    bool hasRedPackage;
    bool hasBluePackage;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collision Detected");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Red Package" && !hasRedPackage && !hasBluePackage)
        {
            Debug.Log("Red Package Acquired");
            hasRedPackage = true;
            other.gameObject.SetActive(false);
            spriteRenderer.color = redPackageColor;
            //Destroy(other.gameObject, destroyDelay);
        }
        
        if (other.tag == "Red Customer" && hasRedPackage)
        {
            Debug.Log("Red Package Delivered to Customer. A New Red Package has Respawned");
            hasRedPackage = false;
            redPackage.gameObject.SetActive(true);
            spriteRenderer.color = noPackageColor;
        }
        if (other.tag == "Blue Package" && !hasRedPackage && !hasBluePackage)
        {
            Debug.Log("Blue Package Acquired");
            hasBluePackage = true;
            other.gameObject.SetActive(false);
            spriteRenderer.color = bluePackageColor;
            //Destroy(other.gameObject, destroyDelay);
        }
        
        if (other.tag == "Blue Customer" && hasBluePackage)
        {
            Debug.Log("Blue Package Delivered to Customer. A New Blue Package has Respawned");
            hasBluePackage = false;
            bluePackage.gameObject.SetActive(true);
            spriteRenderer.color = noPackageColor;
        }
    }
}
