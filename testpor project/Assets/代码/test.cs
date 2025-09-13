using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [Header("�ƶ�����")]
    [SerializeField] float moveSpeed = 8f;    // �ƶ��ٶ�
    [SerializeField] float jumpForce = 12f;  // ��Ծ����

    [Header("������")]
    [SerializeField] Transform groundCheck;  // �������
    [SerializeField] LayerMask groundLayer;  // ����ͼ��
    [SerializeField] float checkRadius = 0.2f; // ���뾶

    Rigidbody2D rb;
    float horizontalInput;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // ������ת
    }

    void Update()
    {
        // ��ȡˮƽ���루A/D�����Ҽ�ͷ��
        horizontalInput = Input.GetAxis("Horizontal");

        // ��Ծ�����⣨�ո��/W/�ϼ�ͷ��
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // ˮƽ�ƶ�
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // �����⣨Բ�η�Χ��⣩
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    // ���ӻ���ⷶΧ�����ڱ༭������ʾ��
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
