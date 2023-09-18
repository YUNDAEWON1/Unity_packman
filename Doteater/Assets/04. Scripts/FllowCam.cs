using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowCam : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 Transform을 할당합니다.
    public Vector3 offset; // 플레이어와 카메라 사이의 거리입니다.

    void Update()
    {
        // 플레이어의 월드 좌표에 offset을 더해 카메라 위치를 결정합니다.
        transform.position = playerTransform.position + offset;
    }
}
