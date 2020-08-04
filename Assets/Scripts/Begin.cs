using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Game1");
    }
}