using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
	public TextMeshPro sparrowText;
	public TextMeshPro taipanText;
	public TextMeshPro muskratText;
	private GameObject sparrowObj;
	private GameObject taipanObj;
	private GameObject muskratObj;
	private Sparrow sparrow;
	private Taipan taipan;
	private Muskrat muskrat;
	private Animator sparrowAnimator;
	private Animator taipanAnimator;
	private Animator muskratAnimator;
	private TextSizer sparrowTextSizer;
	private TextSizer taipanTextSizer;
	private TextSizer muskratTextSizer;
	private bool isSelected;
	
    void Start()
    {
        Debug.Log("Creating the Sparrow");
		sparrow = new Sparrow();
		Debug.Log("Creating the Taipan");
		taipan = new Taipan();
		Debug.Log("Creating the Muskrat");
		muskrat = new Muskrat();
		
		sparrowObj = GameObject.Find("Sparrow");
		if (sparrowObj != null)
        {
			sparrowAnimator = sparrowObj.GetComponent<Animator>();
		}
		taipanObj = GameObject.Find("Taipan");
		if (taipanObj != null)
        {
			taipanAnimator = taipanObj.GetComponent<Animator>();
		}
		muskratObj = GameObject.Find("Muskrat");
		if (muskratObj != null)
        {
			muskratAnimator = muskratObj.GetComponent<Animator>();
		}
		
		sparrowTextSizer = sparrowText.GetComponent<TextSizer>();
		taipanTextSizer = taipanText.GetComponent<TextSizer>();
		muskratTextSizer = muskratText.GetComponent<TextSizer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Create a ray from camera to click position
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Check if the ray hits any collider
            {
				isSelected = false;
				
                if (hit.collider.CompareTag("Sparrow")) // Check if the hit object is this object
                {
					isSelected = true;
					
				    sparrow.Clicked(sparrowAnimator, isSelected);
					sparrow.TellName(sparrowText, isSelected);
					sparrowTextSizer.StartTextSizerCoroutine();
					
					taipan.StopSomething();
					muskrat.StopSomething();
					sparrow.DoSomething(sparrowAnimator);
					
					isSelected = false;
                }
				else
				{
					sparrow.Clicked(sparrowAnimator, isSelected);
					sparrow.TellName(sparrowText, isSelected);
				}
				
				if (hit.collider.CompareTag("Taipan"))
				{
					isSelected = true;
					
					taipan.Clicked(taipanAnimator, isSelected);
					taipan.TellName(taipanText, isSelected);
					taipanTextSizer.StartTextSizerCoroutine();
					
					sparrow.StopSomething();
					muskrat.StopSomething();
					taipan.DoSomething(taipanAnimator);
					
					isSelected = false;
				}
				else
				{
					taipan.Clicked(taipanAnimator, isSelected);
					taipan.TellName(taipanText, isSelected);
				}
				
				if (hit.collider.CompareTag("Muskrat"))
				{
					isSelected = true;
					
					muskrat.Clicked(muskratAnimator, isSelected);
					muskrat.TellName(muskratText, isSelected);
					muskratTextSizer.StartTextSizerCoroutine();
					
					sparrow.StopSomething();
					taipan.StopSomething();
					muskrat.DoSomething(muskratAnimator);
					
					isSelected = false;
				}
				else
				{
					muskrat.Clicked(muskratAnimator, isSelected);
					muskrat.TellName(muskratText, isSelected);
				}
            }
        }
    }
}
