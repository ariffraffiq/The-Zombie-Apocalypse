using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public Animator anim;
     public int speed = 5;
     Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,12);
        anim.Play("m_run");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
