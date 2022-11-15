using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float m_Speed = 5f;
    [SerializeField] LayerMask m_AimLauerMask;

    Animator m_Animator;
    Camera m_Camera;

    void Awake() 
    {
        m_Animator = GetComponent<Animator>();
        m_Camera = Camera.main; 
    }

    void Update()
    {
        AimTowardMouse();
        Vector3 _movment = MoveInput();
        Moving(_movment);
        Animating(_movment);
    }

    private Vector3 MoveInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        return new Vector3(horizontal, 0f, vertical);
    }

    private void Moving(Vector3 movement)
    {
        if (movement.magnitude <= 0)
            return;

        movement.Normalize();
        movement *= m_Speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private void Animating(Vector3 movement)
    {
        float VelocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float VelocityX = Vector3.Dot(movement.normalized, transform.right);

        m_Animator.SetFloat("VelocityZ", VelocityZ, 0.1f, Time.deltaTime);
        m_Animator.SetFloat("VelocityX", VelocityX, 0.1f, Time.deltaTime);
    }

    private void AimTowardMouse()
    {
        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, m_AimLauerMask))
            return;
        Vector3 _direction = hit.point - transform.position;
        _direction.y = 0f;
        _direction.Normalize();
        transform.forward = _direction;
    }
}
