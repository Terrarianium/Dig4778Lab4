using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    // Variables
    private CinemachineFreeLook freeLookCamera;
    private GameObject player;

    public float normalZoom;
    public float bigMeteorZoom;

    // Set camera variable
    void Start()
    {
        freeLookCamera = GameObject.Find("FreeLook Camera").GetComponent<CinemachineFreeLook>();
        StartCoroutine("AssignCamera");
    }

    private void OnEnable()
    {
        BigMeteor.BigMeteorAlive += ControlZoom;
    }

    private void OnDisable()
    {
        BigMeteor.BigMeteorAlive -= ControlZoom;
    }

    private IEnumerator AssignCamera()
    {
        while (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            yield return null;
        }

        freeLookCamera.Follow = player.transform;
    }

    private void ControlZoom(bool bigMeteor)
    {
        if (bigMeteor)
        {
            freeLookCamera.m_Orbits[1].m_Radius = Mathf.Lerp(normalZoom, bigMeteorZoom, 5f);
        }
        else
        {
            freeLookCamera.m_Orbits[1].m_Radius = Mathf.Lerp(bigMeteorZoom, normalZoom, 5f);
        }
    }
}
