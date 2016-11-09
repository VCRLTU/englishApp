using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clickHandler : MonoBehaviour
{
    //public Material homeMadeSkyBox;
    public GameObject UI;
    private GameObject specificToggle;
    private GameObject toggle;
    private objectScript model;
    private canvasScript canvScript;
    private int instantiated = 0;
    //private int clickedFade = 0;
    private playerScript playScript;
    private int submit = 0;
    private string answer;

    void Awake() {
        //Don't want to use "FIND" thing but doesn't seem to keep variable otherwise when loading scene.
        UI = GameObject.Find("playerUI");
        playScript = UI.GetComponent<playerScript>();
        //canvasSc = canvas.GetComponentInChildren<Canvasscript>();
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (GvrViewer.Instance.Triggered)// || Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            bool u = Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity);//, 1 << 8);
            Collider tempHolder = hit.collider;

            if (u)
            {
                //print("Raycast hit: " + tempHolder);

                /*TempHolder here gets the Objects collider, therefor searching for a component in Parent works.
                 * Searching for a Child component will therefor not work since the objects collider doesn't have components
                 * underneath itself, it's the object itself that holds the collider that has the children components.
                 * We also check if our tempHolder has a parent since as of this moment, the object is root in the hierachy.
                 * This might change when we add more objects. */

                objectScript rayCast = tempHolder.GetComponentInParent<objectScript>();

                //This functions checks if the object is initiated and then does something with the choice you picked.
                if ((rayCast.getFade() == 0) && (rayCast.getClick() == 1) && (tempHolder.transform.parent != null)) {
                    canvasScript canvScript = tempHolder.gameObject.GetComponentInParent<canvasScript>();
                    answer = tempHolder.GetComponentInChildren<Text>().text.ToString();
                    //print("tempHolder: " + answer.ToString());
                    //print("racCast " + rayCast.getAnswer().ToString());
                    if (answer == rayCast.getAnswer())
                    {
                        canvScript.pickChoice(tempHolder);
                        playScript.rightAnswer(rayCast);
                        //fades everything.
                        rayCast.setFade();
                    }
                    else {
                        canvScript.pickChoice(tempHolder);
                        playScript.wrongAnswer(rayCast);
                    }
                }
                
                //This function initiates the model choices and sets them to initiated so you can't initiate them again.  
                else if (rayCast.getInstantiate() == 0) 
                    {
                    model = tempHolder.GetComponent<objectScript>();
                    model.click();
                    model.setInstantiate();
                    }
            }
        }
    }
}