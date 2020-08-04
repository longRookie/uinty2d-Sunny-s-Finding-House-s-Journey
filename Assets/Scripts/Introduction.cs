using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Introduction");
    }
}
