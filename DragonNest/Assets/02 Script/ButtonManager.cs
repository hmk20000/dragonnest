using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ButtonManager : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}


    public void MagicSkillTree()
    {

    }


    public void YardScene()
    {
        SceneManager.LoadScene("Yard");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("Main");
    }
}


