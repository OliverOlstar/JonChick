using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoppingMovement : MonoBehaviour
{
    [SerializeField] private bool tipDirection;
    [SerializeField] private float tipAmount = 20f;
    [SerializeField] private float tipSpeed = 40f;
    [SerializeField] private float returnTipSpeed = 50f;
    [SerializeField] private Vector3 targetTip;

    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float rayCastDistance = 1f;
    private Rigidbody _rb;

    public float speed = 1;

    void Start()
    {
        tipDirection = (Random.value > 0.5f);
        _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (speed <= 0.1f)
        {
            if (transform.rotation.eulerAngles.z >= 180)
            {
                targetTip = new Vector3(0, 0, 0.01f);
            }
            else
            {
                targetTip = new Vector3(0, 0, -0.01f);
            }
        }
        else if (tipDirection == true)
        {
            targetTip = new Vector3(0, 0, speed * tipAmount);
        }
        else if (tipDirection == false)
        {
            targetTip = new Vector3(0, 0, speed * tipAmount * -1);
        }
        
        Tipping();
        Hopping();
    }

    void Tipping()
    {
        if (speed == 0)
        {
            if (transform.rotation.eulerAngles.z >= 359f || transform.rotation.eulerAngles.z <= 1f)
            {
                //Dont Tip if not moving
            }
            else
            {
                transform.Rotate(targetTip, returnTipSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.Rotate(targetTip, tipSpeed * Time.deltaTime);
        }

        if (tipDirection)
        {
            if (transform.rotation.eulerAngles.z > targetTip.z && transform.rotation.eulerAngles.z < 180f)
            {
                tipDirection = !tipDirection;
            }
        }
        else
        {
            if (transform.rotation.eulerAngles.z - 360 < targetTip.z && transform.rotation.eulerAngles.z >= 180f)
            {
                tipDirection = !tipDirection;
            }
        }
    }

    void Hopping()
    {
        if (speed > 0.1f)
        {
            if (Physics.Raycast(transform.position, Vector3.down, rayCastDistance))
            {
                _rb.velocity = Vector3.up * jumpHeight * (speed/2 + 0.5f);
                Debug.Log("Called");
            }
        }
    }
}
