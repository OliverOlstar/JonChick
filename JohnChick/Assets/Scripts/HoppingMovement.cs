using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppingMovement : MonoBehaviour
{
    [SerializeField] private bool tipDirection;
    [SerializeField] private float tipAmount;
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
        transform.Rotate(targetTip, speed * Time.deltaTime);

        Debug.Log(transform.rotation.eulerAngles);

        if (Vector3.Angle(transform.rotation.eulerAngles, targetTip) < 0.1f)
        {
            tipDirection = !tipDirection;
        }
    }
}
