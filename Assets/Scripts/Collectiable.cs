using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectiable : MonoBehaviour
{

    public AudioClip collectClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //检测碰到的Collider是否挂了PlayerController 脚本
        PlayerController pc = collision.GetComponent<PlayerController>();

        if (pc != null)
        {
            if (pc.MyCurrentHealth < pc.MyMaxHealth)
            {
                pc.ChangeHealth(1);
                AudioManager.instance.AudioPlay(collectClip);

                Destroy(this.gameObject);
            }
        }
    }
}
