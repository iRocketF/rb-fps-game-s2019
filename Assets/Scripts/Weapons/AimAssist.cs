using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssist : MonoBehaviour
{

    public GameObject m_goCamera = null;
    public GameObject m_goBody = null;
    public float m_fTargetingMinAngle = 8;
    public float m_fAimAssistSpeed = 7;
    public float dis;

    private Transform m_tTarget = null;
    [SerializeField]
    private Player m_eThisPlayer;
    private GameObject hitObject;
    private bool visible;

    public enum Player
    {
        Player1,
        Player2
    }

    void Start()
    {
        switch (m_eThisPlayer)
        {
            case Player.Player1:
                m_tTarget = GameManager.instance.p2;
                break;
            case Player.Player2:
                m_tTarget = GameManager.instance.p1;
                break;
            default:
                break;
        }
        visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraDirection = m_goCamera.transform.forward.normalized;
        IsSeen();

        dis = Vector3.Distance(GameManager.instance.p1.position, GameManager.instance.p2.position) / 8;


        Vector3 directionToTarget = (m_tTarget.position - m_goCamera.transform.position).normalized;

        if (visible)
        {
            if (Vector3.Angle(directionToTarget, cameraDirection) <= m_fTargetingMinAngle - dis)
            {
                // Calculate final rotation towards the target
                Quaternion newRot = Quaternion.Lerp(m_goCamera.transform.rotation, Quaternion.LookRotation(directionToTarget, Vector3.up), m_fAimAssistSpeed * Time.deltaTime);

                // Rotate camera only on X axis
                m_goCamera.transform.rotation = newRot;

                Vector3 cameraEuler = m_goCamera.transform.localEulerAngles;
                cameraEuler.y = 0f;
                cameraEuler.z = 0f;
                m_goCamera.transform.localEulerAngles = cameraEuler;

                // Rotate body only on Y axis
                m_goBody.transform.rotation = newRot;

                Vector3 bodyEuler = m_goBody.transform.localEulerAngles;
                bodyEuler.x = 0f;
                bodyEuler.z = 0f;
                m_goBody.transform.localEulerAngles = bodyEuler;

            }
        }
       
    }

    public void IsSeen()
    {
        RaycastHit hit;
        if (Physics.Raycast(GameManager.instance.p1.position, GameManager.instance.p2.position - GameManager.instance.p1.position, out hit))
        {
            hitObject = hit.transform.gameObject;
            Health target = hitObject.GetComponent<Health>();

            if (target != null)
            {
                print("visible: " + visible);
                visible = true;

            } else
            {
                print("visible: " + visible);
                visible = false;
            }
            
        }
        Debug.DrawRay(GameManager.instance.p1.position, GameManager.instance.p2.position - GameManager.instance.p1.position);
        
    }

}
