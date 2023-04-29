using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    float full = 5.0f;
    float energy = 0.0f;
    bool isFull = false;
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30f;
        transform.position = new Vector3(x, y, 0);
        if(type == 1)
        {
            full = 10.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (energy < full)
        {
            if(type == 0)
            {
                transform.position += new Vector3(0, -0.05f, 0);
            }else if (type == 1)
            {
                transform.position += new Vector3(0, -0.03f, 0);
            }else if(type == 2)
            {
                transform.position += new Vector3(0, -0.1f, 0);
            }

            if (transform.position.y < -16f)
            {
                GameManager.I.gameOver();
            }
        }
        else
        {
            if(transform.position.x > 0)
            {
                transform.position += new Vector3(0.05f, 0, 0);
            }
            else
            {
                transform.position += new Vector3(-0.05f, 0, 0);
            }
            Destroy(gameObject, 3.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "food")
        {
            if( energy < full)
            {
                energy += 1.0f;
                Destroy(collision.gameObject);
                gameObject.transform.Find("hungry/Canvas/front").transform.localScale = new Vector3(energy / full, 1.0f, 1.0f);
            }
            else
            {
                if( isFull == false) // 이프문이 없다면 배불러진 상태에서 먹이와 충돌해도 점수가 상승함
                {
                    GameManager.I.addCat();
                    gameObject.transform.Find("hungry").gameObject.SetActive(false);
                    gameObject.transform.Find("full").gameObject.SetActive(true);
                    isFull = true;
                }
                
            }
            
        }
    }
}
