using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour  //class가 스크립트 이름이다 굿
{
    public float maxSpeed;//퍼블릭은 밖에서도 보이게해줌
    Rigidbody2D rigid; //물리엔진
    SpriteRenderer spriteRenderer;

        void Awake()
        {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        }





        private void Update()//단발적인 키입력
    {
        if (Input.GetButtonUp("Horizontal"))  //멈추는 속도
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);                //겟버튼업은 버튼을 땠을때. 리지드벨로시티는 방향을 가지고있느데 크기도 갖고있기때문에
                                                                                                             //단위를 설정해줘야함 노멀라이즈드는 벡터크기를 1로만든상태
        }
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

    }
       
        
        void FixedUpdate()//키를 눌렀을때 1초에 50번(지속적인키입력)
        {
        float h = Input.GetAxisRaw("Horizontal");// 좌우이동

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)    //velocity는rigidbody의 현재속도,오른쪽 Max Speed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed*(-1))    //왼족 Max Speed
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
        }
}
