using UnityEngine;

public class WallCollider : MonoBehaviour
{
    private PlayerControls m_player;

    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindWithTag("Player").GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        
    }
}
