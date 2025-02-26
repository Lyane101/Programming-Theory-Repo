using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taipan : Animal
{
	// 1. constructor
	public Taipan()
	{
		AnimalName = "Taipan";
		Debug.Log("1. Taipan Constructor called.");
	}
	
	public override void Jump(Animator animator)
	{
		Debug.Log(AnimalName + " is jumping...");
		animator.Play("Eyes_Happy");
		animator.SetBool("IsSpinning", false);
		animator.SetBool("IsSitting", false);
		animator.SetBool("IsJumping", true);
	}
	
	public override void Trick(Animator animator)
	{
		Debug.Log(AnimalName + " is spinning...");
		animator.Play("Eyes_Squint");
		animator.SetBool("IsSitting", false);
		animator.SetBool("IsJumping", false);
		animator.SetBool("IsSpinning", true);
	}
	
	public override void Sit(Animator animator)
	{
		Debug.Log(AnimalName + " is sitting...");
		animator.Play("Eyes_Sleep");
		animator.SetBool("IsJumping", false);
		animator.SetBool("IsSpinning", false);
		animator.SetBool("IsSitting", true);
	}
}
