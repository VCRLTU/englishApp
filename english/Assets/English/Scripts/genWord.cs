using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class genWord : MonoBehaviour {

    // Use this for initialization    
    //public List<string> currlevel;
    public List<string> pickedWords = new List<string>();
    List<int> randomizedIndex;
    void Awake() {
        pickedWords = getLevel1();

    }

	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
    }

    public void setWords() {
        pickedWords.Add(gameObject.transform.root.name);
        List<int> tempLst = new List<int> { 3,0,1,2 };
        randomizedIndex = new List<int>();

        var temp = gameObject.transform.root.name;
        var label1 = gameObject.transform.GetChild(0).GetComponentInChildren<Text>();
        var label2 = gameObject.transform.GetChild(1).GetComponentInChildren<Text>();
        var label3 = gameObject.transform.GetChild(2).GetComponentInChildren<Text>();
        var label4 = gameObject.transform.GetChild(3).GetComponentInChildren<Text>();
        //label1.GetComponentInChildren<Text>().rectTransform.localPosition.Set(0, 0, 0);
        //the check for right answer is not done here.
        
        for (int i = 0; i < 4; i++)
        {
            int indexInList = Random.Range(0, (tempLst.Count - 1));
            //print("indexInList: " + indexInList);
            //print("tempLst: " + tempLst[indexInList]);
            randomizedIndex.Add(tempLst[indexInList]);
            tempLst.RemoveAt(indexInList);
        }

        label1.text = pickedWords[randomizedIndex[0]];
        label2.text = pickedWords[randomizedIndex[1]];
        label3.text = pickedWords[randomizedIndex[2]];
        label4.text = pickedWords[randomizedIndex[3]];


        //label1.GetComponentInChildren<Text>()




        //child.gameObject.GetComponentInChildren<>();
    }

    List<string> getLevel1() {
        List<string> level = new List<string>();
        level.Add("monkey");
        level.Add("dog");
        level.Add("guitar");
        level.Add("hair");
        level.Add("hippo");
        level.Add("volcano");
        level.Add("hallway");
        level.Add("pillow");
        level.Add("book");
        level.Add("pen");
        level.Add("cellphone");
        level.Add("random");
        for (int i = 0; i < 3; i++) {
            int indexInList = Random.Range(0, (level.Count - 1));
            pickedWords.Add(level[indexInList]);
            level.RemoveAt(indexInList);
            
        }
        return pickedWords;
    }
    List<string> getLevel2() {
        List<string> level = new List<string>();
        level.Add("hippo");
        level.Add("volcano");
        level.Add("hallway");
        level.Add("pillow");
        return level;
    }
}
