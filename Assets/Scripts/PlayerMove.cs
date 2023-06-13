using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour  //class�� ��ũ��Ʈ �̸��̴� ��
{
    public float maxSpeed;//�ۺ��� �ۿ����� ���̰�����
    Rigidbody2D rigid; //��������
    SpriteRenderer spriteRenderer;

        void Awake()
        {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        }





        private void Update()//�ܹ����� Ű�Է�
    {
        if (Input.GetButtonUp("Horizontal"))  //���ߴ� �ӵ�
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);                //�ٹ�ư���� ��ư�� ������. �����座�ν�Ƽ�� ������ �������ִ��� ũ�⵵ �����ֱ⶧����
                                                                                                             //������ ����������� ��ֶ������� ����ũ�⸦ 1�θ������
        }
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

    }
       
        
        void FixedUpdate()//Ű�� �������� 1�ʿ� 50��(��������Ű�Է�)
        {
        float h = Input.GetAxisRaw("Horizontal");// �¿��̵�

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)    //velocity��rigidbody�� ����ӵ�,������ Max Speed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed*(-1))    //���� Max Speed
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
        }
}
