using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    [SerializeField] GameObject ScoreText;
    [SerializeField] GameObject LeftArrow;
    [SerializeField] GameObject RightArrow;
    Animator leftArrowAnimator;
    Animator rightArrowAnimator;

	// Use this for initialization
	void Start () {
        leftArrowAnimator = LeftArrow.GetComponent<Animator>();
        rightArrowAnimator = RightArrow.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RightArrowDown()
    {
        rightArrowAnimator.SetBool("Pressed", true);
    }

    public void RightArrowUp()
    {
        rightArrowAnimator.SetBool("Pressed", false);
    }

    public void LeftArrowDown()
    {
        leftArrowAnimator.SetBool("Pressed", true);
    }

    public void LeftArrowUp()
    {
        leftArrowAnimator.SetBool("Pressed", false);
    }

    public void updateScore(int score)
    {
        ScoreText.GetComponent<Text>().text = "" + score;
    }
}
