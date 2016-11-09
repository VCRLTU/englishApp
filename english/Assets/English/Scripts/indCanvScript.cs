using UnityEngine;
using System.Collections;

public class indCanvScript : MonoBehaviour {
    private CanvasGroup canv;
    private Collider physBod;
    private genWord wordScript;
    int faded = 0;

    void Awake() {
        canv = GetComponent<CanvasGroup>();
        physBod = GetComponent<Collider>();
        canv.alpha = 1;
    }
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    /* Time.deltaTime changes the fadeOut in seconds and not in pixels updated. 
     * deltaTime/2 gives us 0.5sec fade out and deltaTime/1 is one. */
	void Update () {
        //text fades out.
        if ((faded == 1) && (canv.alpha > 0.26f))
        {
            canv.alpha -= (Time.deltaTime / 1);
        }
    }
    private IEnumerator sleep() {
        yield return new WaitForSecondsRealtime(1);
        faded = 1;
    }
   
    /* They way "StartCoRoutine works is that it starts the sleep function but also finishes
     * the current ongoing function, then it waits the remainder of the "sleep" time
     * and then continues going with the program. This is what I think anyway.
     * If I put the faded = 1 in fade(), which I can't since it's a void, 
     * the fadeout would begin immediately instead of waiting 1 second. */
    public void fade() {
        StartCoroutine("sleep");
        //.enabled = false fixes the problem of losing a heart on a choice that's already clicked.
        physBod.enabled = false;
    }
}
