using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public GameObject panel1, buttonResume, buttonReStart1, buttonExit1, textPause;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BatDau()
    {
        SceneManager.LoadScene("Scence_1");
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ReSumeGame()
    {
        Time.timeScale = 1;
        panel1.SetActive(false);
        buttonResume.SetActive(false);
        buttonReStart1.SetActive(false);
        buttonExit1.SetActive(false);
        textPause.SetActive(false);
    }
}
