using UnityEngine;
using UnityEngine.SceneManagement;

public class Again : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Menu");
    }
}