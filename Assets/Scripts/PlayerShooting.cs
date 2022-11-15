using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Rigidbody m_Arrow;
    [SerializeField] GameObject m_ArrowShootSpot;


    [SerializeField] float m_ShootStrength = 100f;
    Animator m_Animator;

    private void Awake() => m_Animator = transform.GetComponent<Animator>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            m_Animator.SetTrigger("DrawArrow");
        if (Input.GetMouseButtonUp(0))
            m_Animator.SetTrigger("Shoot");
    }

    private void Shoot()
    {
        Rigidbody arrow = Instantiate(m_Arrow, m_ArrowShootSpot.transform.position, m_ArrowShootSpot.transform.rotation);
        arrow.AddForce(transform.forward * m_ShootStrength, ForceMode.Impulse);
        Destroy(arrow.gameObject, 5);
    }
}
