using UnityEngine;
using System.Collections;

public class scoreBoard : MonoBehaviour {
    private int totalScore = 0;
    private playerScript player;
    private TextMesh textScore;
    private Camera cam;

    void Awake() {
        cam = Camera.main;
        textScore = GetComponentInChildren<TextMesh>();
        player = GetComponent<playerScript>();

}
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public void setScoreBoard(int currentScore) {
        print("currScore: " + player.getCurrScore());
        totalScore = totalScore + currentScore;
        textScore.text = totalScore.ToString();
        /* The reason for doing it like this is when you want to change a color,
         * you first make a copy of the colors properties so after you've changed the
         * copy you need to set the new color to the copy's color. You can't change
         the color directly 

        Renderer myRenderer = GetComponent<Renderer>();
        Color col = myRenderer.material.color;
        col.a = 0.25f;
        myRenderer.material.color = col;*/
    }
}
