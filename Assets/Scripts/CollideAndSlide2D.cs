using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideAndSlide2D : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 moveVec;
    [SerializeField] private float xDir;
    [SerializeField] private float yDir;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Bounds bounds;

    private float skinWidth = 0.015f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bounds = col.bounds;
        bounds.Expand(-20 * skinWidth);
        
        xDir = Input.GetAxisRaw("Horizontal");
        yDir = Input.GetAxisRaw("Jump");

        moveVec = new Vector2(xDir, yDir).normalized * (moveSpeed * Time.deltaTime);

        if (Physics2D.BoxCast(bounds.center, bounds.size - new Vector3(.01f, .01f, 0f), 0f, moveVec, moveVec.magnitude + skinWidth, 3))
        {
            moveVec.x = .1f;
        }

        transform.Translate(moveVec);

    }
}
