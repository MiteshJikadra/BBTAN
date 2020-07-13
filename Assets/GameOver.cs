using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameoverCanvas;
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
        if (collision.gameObject.tag == "Square Brick" || collision.gameObject.tag == "Triangle Brick01" || collision.gameObject.tag == "Triangle Brick02" || collision.gameObject.tag == "Triangle Brick03" || collision.gameObject.tag == "Triangle Brick04")
        {
            gameobjectactivdiactive.GAD.dactive();
            SoundManager.Sm.gameOverSound();
            GameoverCanvas.SetActive(true);
            

        }
        else if (collision.gameObject.tag == "Extra Ball PowerUp")
        {
            Destroy(collision.gameObject);
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuiteGame()
    {
        Application.Quit();
    }
}
