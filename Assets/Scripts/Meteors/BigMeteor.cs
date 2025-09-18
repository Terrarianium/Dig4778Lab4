using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



/*public class BigMeteor : MonoBehaviour
{
    private int hitCount = 0;

    public static event Action<bool> BigMeteorAlive;

    // Start is called before the first frame update
    void Start()
    {
        BigMeteorAlive?.Invoke(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 0.5f);

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }

        if (hitCount >= 5)
        {
            BigMeteorAlive?.Invoke(false);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
        }
        else if (whatIHit.tag == "Laser")
        {
            hitCount++;
            Destroy(whatIHit.gameObject);
        }
    }
}*/

public class BigMeteor : MeteorBase
{
    private int hitCount = 0;
    public static event Action<bool> BigMeteorAlive;
    private CinemachineImpulseSource impulseSource;

    protected override float moveSpeed => 0.5f;

    private void Start()
    {
        BigMeteorAlive?.Invoke(true);
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    protected override void HandleLaserHit(Collider2D laser)
    {
        hitCount++;
        Destroy(laser.gameObject);
    }

    protected override void CustomUpdate()
    {
        if (hitCount >= 5)
        {
            BigMeteorAlive?.Invoke(false);
            impulseSource.GenerateImpulse();
            DestroyMeteor();
        }
    }
}

