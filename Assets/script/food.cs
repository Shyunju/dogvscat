using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    public float dtryheigt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0.5f, 0);

        if (transform.position.y > dtryheigt)
        {
            Destroy(gameObject);
        }
    }
}
