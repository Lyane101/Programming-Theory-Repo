using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Animal
{
	protected Action<KeyCode> jumpEventHandler;
	protected Action<KeyCode> trickEventHandler;
	protected Action<KeyCode> sitEventHandler;
	
	[SerializeField]
	private string m_AnimalName;
    public string AnimalName
	{
		get { return m_AnimalName; }
		set
		{ 
		    if (value.Length > 10)
			{
				Debug.LogError("Name cannot be longer than 10 characters.");
			}
			else
			{
		        m_AnimalName = value; 
		    }
		}
	}
	
	// 1. constructor
	public Animal()
	{
		m_AnimalName = "Animal";
		Debug.Log("1. Animal Constructor called.");
	}
	
	// 2. constructor
	public Animal(string name)
	{
		m_AnimalName = name;
		Debug.Log("2. Animal Constructor called.");
	}
	
	public void Clicked(Animator animator, bool isSelected)
	{
		if (isSelected)
		{
		    Debug.Log(m_AnimalName + " clicked...");
			animator.Play("Eyes_Happy");
		}
		else
		{
			animator.Play("Eyes_Blink");
		}
		animator.SetBool("IsClicked", isSelected);
	}
	
	public void TellName(TextMeshPro textMeshObj, bool isSelected)
	{
		if (isSelected)
		{
			Debug.Log(AnimalName + " is telling it's name...");
		}
		textMeshObj.gameObject.SetActive(isSelected);
	}
	
	public virtual void Jump(Animator animator)
	{
		Debug.Log("Jumping...");
	}
	
	public virtual void Trick(Animator animator)
	{
		Debug.Log("Doing a trick...");
	}
	
	public virtual void Sit(Animator animator)
	{
		Debug.Log("Sitting...");
	}
	
	public void DoSomething(Animator animator)
	{
		jumpEventHandler = (key) =>
        {
            if (key == KeyCode.Z)
            {
                Jump(animator);
            }
        };
		
		trickEventHandler = (key) =>
        {
            if (key == KeyCode.X)
            {
                Trick(animator);
            }
        };
		
		sitEventHandler = (key) =>
        {
            if (key == KeyCode.C)
            {
                Sit(animator);
            }
        };
		
		InputManager.KeyDownEvent += jumpEventHandler;
		InputManager.KeyDownEvent += trickEventHandler;
		InputManager.KeyDownEvent += sitEventHandler;
	}
	
	public void StopSomething()
	{
		InputManager.KeyDownEvent -= jumpEventHandler;
		InputManager.KeyDownEvent -= trickEventHandler;
		InputManager.KeyDownEvent -= sitEventHandler;
	}
}
