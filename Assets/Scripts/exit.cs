using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void ToLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }
}