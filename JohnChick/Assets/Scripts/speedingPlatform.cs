using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for the speeding platforms 
public class speedingPlatform : MonoBehaviour
{
    public Vector3 direction;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        direction.Normalize();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(direction * speed); //add force in a direction
            
    }
}
