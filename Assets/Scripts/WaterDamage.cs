using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterDamage : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //检测碰到的Collider是否挂了PlayerController 脚本
        PlayerController pc = collision.GetComponent<PlayerController>();

        if (pc != null)
        {
            
            pc.exitGame();
        }
    }
}