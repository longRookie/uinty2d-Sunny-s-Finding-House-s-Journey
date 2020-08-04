using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}