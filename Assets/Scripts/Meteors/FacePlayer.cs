using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class FacePlayer : MonoBehaviour
{
    // Variables
    private GameObject player;
    private Vector3 playerPosition;

    // Set player
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Get angle between enemy and player then rotate
    void Update()
    {
        Vector3 directionDifferent = player.transform.position - transform.position;
        float signedAngle = Vector3.SignedAngle(transform.up, directionDifferent, Vector3.forward);
        Vector3 rotation = new Vector3(0, 0, signedAngle + 90);

        transform.Rotate(rotation * Time.deltaTime * 10);
    }
}
