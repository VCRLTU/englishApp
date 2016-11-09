using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class playerScript : MonoBehaviour {
    //public Material skyBox;
    //public Material startSkyBox;
    //public gameOver gOver;
    private int counter;
    private canvasScript canv;
    private int currentScore;
    private scoreBoard board;
    private int destroyedObj = 0;
    private int level = 1;
    List<GameObject> objInLevel;
    private int listLength = 5;


    void Awake() {
        objInLevel = new List<GameObject>();
        DontDestroyOnLoad(transform.gameObject);
        loadLevelFunc();
        board = GetComponent<scoreBoard>();
        /*RenderSettings.skybox = startSkyBox; */
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }

    public int getCurrScore() {
        return currentScore;
    }
    public void wrongAnswer(objectScript choice) {
        counter = choice.getCounter();
        //print("choice: " + choice);
        //print("obj counter: " + choice.getCounter());
        if (counter > 0) {
            currentScore = choice.decScore();
            counter = choice.decCounter();
            print("currentScore: " + currentScore);
            print("counter: " + choice.getCounter());
        }
    }
    public void rightAnswer(objectScript choice) {
        currentScore = choice.getScore();
        board.setScoreBoard(currentScore);
        destroyedObj = destroyedObj + 1;
        level = level + 1;
        loadNewLevel();

    }

    public List<GameObject> loadLevel() {
        //Creating list to hold 5 elements.
        List<GameObject> worldObjects = new List<GameObject>(5);
        //Loading all prefabs in list.
        List<GameObject> loadedObjectsInList = new List<GameObject>();
        var prefabs = Resources.LoadAll("level"+level +"/", typeof(GameObject));
        foreach (GameObject obj in prefabs) {
            loadedObjectsInList.Add(obj);
            }
        prefabs = null;

        //Randomize 5 different objects
        for (int i = 0; i < listLength; i++)
        {
            int indexInList = Random.Range(0, (loadedObjectsInList.Count - 1));
            worldObjects.Add(loadedObjectsInList[indexInList]);
            loadedObjectsInList.RemoveAt(indexInList);

        }
        return worldObjects;
    }

    public void loadLevelFunc()
    {
        print("---------- Loading level: " + level + "--------------");
            objInLevel = loadLevel();
            for (int i = 0; i < objInLevel.Count; i++) {
                var s = Instantiate(objInLevel[i]) as GameObject;
                print("Initiated: " + s);
            s = null;
        }
       }

    /* Fix this function to load levels properly */
    public void loadNewLevel() {
        if ((destroyedObj == 1) || (destroyedObj >= 2))
        {
            objInLevel.Clear();
            SceneManager.LoadScene("English/level" + level);
            StartCoroutine("sleep");



        }
    }

    private IEnumerator sleep() {
         yield return new WaitForSecondsRealtime(1);
        loadLevelFunc();
        }
}



    //This function deletes one heart at a time until you die.
    /*type casting the items in the list since arrayList is non-specific.
    ((GameObject)hearts[counter-1]).GetComponent<heartScript>().delHeart();
    counter--;
}
if (counter == 0) {
    gOver.playScene();
    RenderSettings.skybox = skyBox;
    */
