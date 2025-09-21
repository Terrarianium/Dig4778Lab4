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
    public float zoomRate;

    // Set camera variable
    void Start()
    {
        freeLookCamera = GameObject.Find("FreeLook Camera").GetComponent<CinemachineFreeLook>();
        StartCoroutine("AssignCamera");
    }

    private void OnEnable()
    {
       BigMeteor.BigMeteorAlive += BigMeteorActions;
    }

    private void OnDisable()
    {
        BigMeteor.BigMeteorAlive -= BigMeteorActions;
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

    private void BigMeteorActions(bool bigMeteor)
    {
        StartCoroutine(Zoom(bigMeteor));
        if (!bigMeteor)
        {
            StartCoroutine("ScreenShake");
        }
    }

    private IEnumerator Zoom(bool grow)
    {
        if (grow)
        {
            while (freeLookCamera.m_Orbits[1].m_Radius < bigMeteorZoom)
            {
                freeLookCamera.m_Orbits[1].m_Radius += Time.deltaTime * zoomRate;
                yield return null;
            }
        } else
        {
            while (freeLookCamera.m_Orbits[1].m_Radius > normalZoom)
            {
                freeLookCamera.m_Orbits[1].m_Radius -= Time.deltaTime * zoomRate;
                yield return null;
            }
        }
    }

    private IEnumerator ScreenShake()
    {
        float shakeTime = 1f;

        while (shakeTime > 0f)
        {
            freeLookCamera.m_Heading.m_Bias = Random.Range(-shakeTime * 5, shakeTime * 5);
            shakeTime -= Time.deltaTime;
            yield return null;
        }
    }
}
