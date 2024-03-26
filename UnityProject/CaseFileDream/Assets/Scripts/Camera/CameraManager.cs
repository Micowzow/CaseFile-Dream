using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;




public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    [SerializeField] private CinemachineVirtualCamera[] allVirtualCameras;

    [Header("Controls for lerping the Y Damping during player jump/fall")]
    [SerializeField] private float fallPanAmount = 0.25f;
    [SerializeField] private float fallPanTime = 0.35f;

    public float fallSpeedYDampingChangeThreshold = -15f;

    public bool IsLerpingYDamping {get; private set; }
    public bool LerpedFromPlayerFalling {get; set; }

    private Coroutine lerpYPanCoroutine;

    private CinemachineVirtualCamera currentCamera;
    private CinemachineFramingTransposer framingTransposer;

    private float normYPanAmount;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }

        for(int i = 0; i < allVirtualCameras.Length; i++)
        {
            //Set current active camera
            currentCamera = allVirtualCameras[i];

            //Set framing transposer
            framingTransposer = currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        }
        //Set the YDamping amount so it's based on the inspector value
        normYPanAmount = framingTransposer.m_YDamping;

    }

    public void LerpingYDamping(bool isPlayerFalling)
    {
        lerpYPanCoroutine = StartCoroutine(LerpYAciton(isPlayerFalling));
    }

    private IEnumerator LerpYAciton(bool isPlayerFalling)
    {
        IsLerpingYDamping = true;

        float startDampAmount = framingTransposer.m_YDamping;
        float endDampAmount = 0f;

        if(isPlayerFalling)
        {
            endDampAmount = fallPanAmount;
            LerpedFromPlayerFalling = true;
        }

        else
        {
            endDampAmount = normYPanAmount;
        }

        float eLapsedTime = 0f;
        while(eLapsedTime < fallPanAmount)
        {
            eLapsedTime += Time.deltaTime;

            float lerpedPanAmount = Mathf.Lerp(startDampAmount, endDampAmount, (eLapsedTime / fallPanAmount));
            framingTransposer.m_YDamping = lerpedPanAmount;

            yield return null;
        }

        IsLerpingYDamping = false;
    }
}


