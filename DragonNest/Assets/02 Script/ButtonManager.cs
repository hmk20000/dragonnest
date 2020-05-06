using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ButtonManager : MonoBehaviour {

    [SerializeField]
    GameObject MSwindow;

    [SerializeField]
    GameObject BSwindow;



	void Start () {
		
        

	}
	
	void Update () {
		
	}


    public void MagicSkillTreeOn()
    {
        MSwindow.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void MagicSkillTreeOff()
    {
        MSwindow.transform.localPosition = new Vector3(2000, 0, 0);

    }


    public void BodySkillTreeOn()
    {
        BSwindow.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void BodySkillTreeOff()
    {
        BSwindow.transform.localPosition = new Vector3(2000, 0, 0);

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


