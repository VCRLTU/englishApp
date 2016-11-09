using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class canvasScript : MonoBehaviour
{
    private int visible;
    private CanvasGroup canvGroup;
    private int fadeOut;
    private Collider picked = null;
    private objectScript obj;
    private int corrAnswer = 0;
    private int fade = 1;
    private genWord wordScript;
    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
        canvGroup = GetComponent<CanvasGroup>();
        gameObject.SetActive(false);
        obj = GetComponentInParent<objectScript>();
        wordScript = GetComponentInChildren<genWord>();
    }

    // Use this for initialization
    void Start()
    {

    }
     
    // Update is called once per frame
    void Update()
    {        
        //text fades in after you click on Object.
        if (fadeOut == 0)
        {
            canvGroup.alpha += (Time.deltaTime / 1);
            var targetRotation = Quaternion.LookRotation(transform.position - cam.transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 1);
        }
        else if (fadeOut == 1)
        { // Everything fades out.
            canvGroup.alpha -= (Time.deltaTime / 1);
            if ((canvGroup.alpha == 0) && (corrAnswer == 1))
            {
                /* Destroy object here to get rid of it.
                * Using SetActive as a temporary fix since program breaks with Destroy.*/
                //Destroy(transform.root.gameObject);
                transform.root.gameObject.SetActive(false);

            }
        }
    }
    public void activate()
    {
        gameObject.SetActive(true);
        canvGroup.alpha = 0;
        fadeOut = 0;
        wordScript.setWords();
    }

    private IEnumerator sleep() {
            yield return new WaitForSecondsRealtime(2);
            fadeOut = 1;
        }

    // This function takes whatever the choice we picked and colors and fades it.
    public void pickChoice(Collider tempHolder)
    {
        //print("tempHolder name: " + tempHolder.name);
        /*The .getAnswer() function returns the same value as transform.root
         * (which, coincidentally, is the top name in the hierachy right now anyway.*/
        if (tempHolder.GetComponentInChildren<Text>().text == tempHolder.gameObject.GetComponentInParent<objectScript>().getAnswer())
        {
            //Right answer: Colors the choice green.
            ColorBlock col = tempHolder.gameObject.GetComponent<Toggle>().colors;
            col.pressedColor = new Color(0, 220, 0);
            col.normalColor = new Color(0, 220, 0);
            col.highlightedColor = new Color(0, 220, 0);
            tempHolder.gameObject.GetComponent<Toggle>().colors = col;
            corrAnswer = 1;
            StartCoroutine("sleep");
        }
        else {
            //Wrong answer: Colors the choice red and calls a function which fades the choice after 1 second.
            ColorBlock colStart = tempHolder.gameObject.GetComponent<Toggle>().colors;
            colStart.pressedColor = new Color(220, 0, 0);
            colStart.normalColor = new Color(220, 0, 0);
            colStart.highlightedColor = new Color(220, 0, 0);
            tempHolder.gameObject.GetComponent<Toggle>().colors = colStart;
            tempHolder.gameObject.GetComponentInParent<CanvasGroup>().GetComponent<indCanvScript>().fade();
            
        }   
    }
}
