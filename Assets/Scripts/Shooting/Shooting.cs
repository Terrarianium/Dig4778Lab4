using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class Shooting :  MonoBehaviour
{
    public GameObject laserPrefab;

    private InputReader input;

    private bool canShoot = true;

    private void Start()
    {
        input = InputReader.Instance;
    }

    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (input.ShootTrigger && canShoot)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canShoot = false;
            StartCoroutine("Cooldown");
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
