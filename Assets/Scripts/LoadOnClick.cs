using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    public void LoadLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
    }
}
