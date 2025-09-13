using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [Header("移动参数")]
    [SerializeField] float moveSpeed = 8f;    // 移动速度
    [SerializeField] float jumpForce = 12f;  // 跳跃力度

    [Header("地面检测")]
    [SerializeField] Transform groundCheck;  // 地面检测点
    [SerializeField] LayerMask groundLayer;  // 地面图层
    [SerializeField] float checkRadius = 0.2f; // 检测半径

    Rigidbody2D rb;
    float horizontalInput;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // 锁定旋转
    }

    void Update()
    {
        // 获取水平输入（A/D或左右箭头）
        horizontalInput = Input.GetAxis("Horizontal");

        // 跳跃输入检测（空格键/W/上箭头）
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // 水平移动
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // 地面检测（圆形范围检测）
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    // 可视化检测范围（仅在编辑器中显示）
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
