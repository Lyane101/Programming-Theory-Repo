using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparrow : Animal
{	
	// 1. constructor
	public Sparrow()
	{
		AnimalName = "Sparrow";
		Debug.Log("1. Sparrow Constructor called.");
	}
	
	public override void Jump(Animator animator)
	{
		Debug.Log(AnimalName + " is jumping...");
		animator.Play("Eyes_Happy");
		animator.SetBool("IsRolling", false);
		animator.SetBool("IsSitting", false);
		animator.SetBool("IsJumping", true);
	}
	
	public override void Trick(Animator animator)
	{
		Debug.Log(AnimalName + " is rolling...");
		animator.Play("Eyes_Squint");
		animator.SetBool("IsSitting", false);
		animator.SetBool("IsJumping", false);
		animator.SetBool("IsRolling", true);
	}
	
	public override void Sit(Animator animator)
	{
		Debug.Log(AnimalName + " is sitting...");
		animator.Play("Eyes_Sleep");
		animator.SetBool("IsJumping", false);
		animator.SetBool("IsRolling", false);
		animator.SetBool("IsSitting", true);
	}
}
