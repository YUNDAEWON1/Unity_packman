using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowCam : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� Transform�� �Ҵ��մϴ�.
    public Vector3 offset; // �÷��̾�� ī�޶� ������ �Ÿ��Դϴ�.

    void Update()
    {
        // �÷��̾��� ���� ��ǥ�� offset�� ���� ī�޶� ��ġ�� �����մϴ�.
        transform.position = playerTransform.position + offset;
    }
}
