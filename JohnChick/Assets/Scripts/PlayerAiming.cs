using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float forwardForce;

    [Header("Bullet")]
    [SerializeField] private float bulletsPerSec;
    [SerializeField] private float bulletLife;
    [SerializeField] private float bulletSize;

    void Start()
    {

    }
    
    void Update()
    {
        Rotation();

        if (Input.GetButtonDown("Fire1"))
        {
            StartShooting();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StopShooting();
        }
    }

    void Rotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }

    void StartShooting()
    {
        StartCoroutine("Shooting");
    }

    void StopShooting()
    {
        StopCoroutine("Shooting");
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = muzzle.position;
            bullet.transform.forward = muzzle.forward;
            bullet.transform.localScale *= bulletSize;
            bullet.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x * forwardForce, 0, transform.forward.z * forwardForce), ForceMode.Impulse);
            Destroy(bullet, bulletLife);

            yield return new WaitForSeconds(1f / bulletsPerSec);
        }
    }
}
