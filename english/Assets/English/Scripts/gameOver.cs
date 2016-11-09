using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {
    //public Material homeMadeSkyBox; 
    private CanvasGroup canv;
    int fade = 0;
    int clicked = 0;
    private Collider hit;

    void Awake() {
        gameObject.SetActive(false);
        canv = GetComponent<CanvasGroup>();
    }

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (fade == 1)
        {   
            if (canv.alpha < 1) { 
            canv.alpha += (Time.deltaTime / 1);
            }
            else if (clicked == 1) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void playScene() {
        gameObject.SetActive(true);
        fade = 1;
    }

    public void click() {
        clicked = 1;
    }
}
