using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform m_ObjectToFollow;
    [SerializeField] Vector3 m_Offset;
    [SerializeField] float m_SmoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPosition = m_ObjectToFollow.position + m_Offset;
        Vector3 SmoothPosition = Vector3.Lerp(transform.position, desiredPosition, m_SmoothSpeed);
        transform.position = SmoothPosition;
    }
}
