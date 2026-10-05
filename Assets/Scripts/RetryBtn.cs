using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryBtn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Retry);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Retry()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
