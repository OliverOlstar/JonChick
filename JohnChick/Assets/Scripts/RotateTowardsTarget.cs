using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotateLerpSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotateLerpSpeed * Time.deltaTime);
    }
}
