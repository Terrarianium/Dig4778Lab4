using UnityEngine;

public abstract class MeteorBase : MonoBehaviour
{
    protected virtual float moveSpeed => 2f;
    protected virtual float destroyYThreshold => -11f;

    protected virtual void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        if (transform.position.y < destroyYThreshold)
        {
            DestroyMeteor();
        }
        CustomUpdate();
    }
    protected virtual void CustomUpdate() { }
    protected virtual void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
            DestroyMeteor();
        }
        else if (whatIHit.CompareTag("Laser"))
        {
            HandleLaserHit(whatIHit);
        }
    }
    protected virtual void HandleLaserHit(Collider2D laser)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().meteorCount++;
        Destroy(laser.gameObject);
        DestroyMeteor();
    }

    protected virtual void DestroyMeteor()
    {
        Destroy(gameObject);
    }


}
