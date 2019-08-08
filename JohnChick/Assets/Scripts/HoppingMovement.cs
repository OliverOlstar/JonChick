using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppingMovement : MonoBehaviour
{
    [SerializeField] private bool tipDirection;
    [SerializeField] private float tipAmount;
    [SerializeField] private float tipSpeed;
    [SerializeField] private Vector3 targetTip;

    public float speed = 1;

    void Start()
    {
        tipDirection = (Random.value > 0.5f);
    }
    
    void Update()
    {
        if (speed < 0.1f)
        {
            targetTip = new Vector3(0, 0, 0);
        }
        else if (tipDirection == true)
        {
            targetTip = new Vector3(0, 0, speed * tipAmount);
        }
        else if (tipDirection == false)
        {
            targetTip = new Vector3(0, 0, speed * tipAmount * -1);
        }
        
        tipping();
    }

    void tipping()
    {
        transform.Rotate(targetTip, speed * tipSpeed * Time.deltaTime);

        Debug.Log(transform.rotation.eulerAngles.z - 360);

        if (tipDirection)
        {
            if (transform.rotation.eulerAngles.z >= targetTip.z && transform.rotation.eulerAngles.z < 180f)
            {
                tipDirection = !tipDirection;
            }
        }
        else
        {
            if (transform.rotation.eulerAngles.z - 360 <= targetTip.z && transform.rotation.eulerAngles.z > 180f)
            {
                tipDirection = !tipDirection;
            }
        }
    }
}
