using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPVDroneBasicMoveMono : MonoBehaviour
{

    public Transform m_whatToAffect;


    [Header("Percent Input")]
    [Range(-1,1)]
    public float m_rotateLeftRightPercent;

    [Range(-1, 1)]
    public float m_pitchBackForwardPercent;

    [Range(-1, 1)]
    public float m_rollLeftRightPercent;

    [Range(-1, 1)]
    public float m_throttleFrontPercent;


    [Header("Speed and Angle")]
    public float m_rotateLeftRightAngle = 180;
    public float m_pitchBackForwardAngle = 180;
    public float m_rollLeftRightAngle = 180;
    public float m_throttleFrontSpeed = 0.5f;
    public float m_throttleBackSpeed = 0.1f;


    public void SetDoubleJoystick(Vector2 leftJoystick, Vector2 rightJoystick)
    {
        m_throttleFrontPercent = leftJoystick.y;
        m_rotateLeftRightPercent = leftJoystick.x;
        m_pitchBackForwardPercent = rightJoystick.y;
        m_rollLeftRightPercent = rightJoystick.x;
    }
    public void SetRotateLeftRight(float percent)
    {
        m_rotateLeftRightPercent = percent;
    }
    public void SetPitchBackForward(float percent)
    {
        m_pitchBackForwardPercent = percent;
    }
    public void SetRollLeftRight(float percent)
    {
        m_rollLeftRightPercent = percent;
    }
    public void SetThrottleFront(float percent)
    {
        m_throttleFrontPercent = percent;
    }


    private void Reset()
    {
        m_whatToAffect = transform;
    }

    void LateUpdate()
    {
        float throttleSpeed= m_throttleFrontPercent > 0 ? m_throttleFrontSpeed : m_throttleBackSpeed;
        float speed = m_throttleFrontPercent * throttleSpeed;

        m_whatToAffect.Rotate(Vector3.up, -m_rotateLeftRightAngle *m_rotateLeftRightPercent * Time.deltaTime, Space.Self);
        m_whatToAffect.Rotate(Vector3.right, m_pitchBackForwardAngle* m_pitchBackForwardPercent * Time.deltaTime, Space.Self);
        m_whatToAffect.Rotate(Vector3.forward, - m_rollLeftRightAngle* m_rollLeftRightPercent * Time.deltaTime, Space.Self);
        m_whatToAffect.Translate(Vector3.up *speed * Time.deltaTime, Space.Self  );
        
    }
}
