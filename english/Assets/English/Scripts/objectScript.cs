using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*x-axis: -7 -> 7
  y-axis: -7 -> 7
  z-axis: -7 -> 7   */


public class objectScript : MonoBehaviour {
    private int clicked;
    public canvasScript canvScript;
    private GameObject canv;
    private string answer;
    private int instantiated;
    private int fade = 0;
    private Camera cam;
    private int score = 6000;
    private int counter = 3;
    private float pos;
    private int destroyed = 1;

    void Awake() {
        cam = Camera.main;
        instantiated = 0;
        clicked = 0;
        transform.position = new Vector3(Random.Range(10, -10), Random.Range(10, -10), Random.Range(10, -10));
    
    }

	// Use this for initialization
	void Start () {
        fixName();
        gameObject.name = answer;

    }

    // Update is called once per frame
    void Update()
    {
        if (instantiated == 0)
        {
            //rotateAt();
        }
        spin();
    }

    public void fixName() {
        string temp = gameObject.name;
        string[] var = temp.Split('(');
        answer = var[0];
    }

    /* Makes object spin */ 
    public void spin() {
        transform.Rotate(Vector3.back * 60 * Time.deltaTime);
        transform.Rotate(Vector3.up * 40 * Time.deltaTime);
    }

    /* Rotating around camera object */
    public void rotateAt() {
        var q = transform.rotation;
        var s = transform.rotation;
        var k = transform.rotation;

        transform.RotateAround(cam.transform.position, Vector3.right, 20 * Time.deltaTime);
        transform.rotation = q;
        transform.RotateAround(cam.transform.position, Vector3.forward, 10 * Time.deltaTime);
        transform.rotation = s;
        transform.RotateAround(cam.transform.position, Vector3.back, 15 * Time.deltaTime);
        transform.rotation = k;
    }

    public void destroyObject() {
        Destroy(gameObject);
    }
    public void click() {
        clicked = 1;
        canvScript.GetComponent<canvasScript>().activate();
        
        }

    public int getClick() {
        return clicked;
    }
    public string getAnswer() {
        return answer;
    }

    public void setInstantiate() {
        instantiated = 1;
    }
    public int getInstantiate() {
        return instantiated;
    }
    public void setFade() {
        fade = 1;
    }
    public int getFade() {
        return fade;
    }
    public int getScore() {
        return score;
    }
    public int decScore() {
        score = score - 2000;
        return score;
    }
    public int decCounter() {
        counter = counter-1;
        return counter;
    }
    public int getCounter() {
        return counter;
    }
    public int objDestroyed() {
        return 1;
    }
}
