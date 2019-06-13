using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour {

	public GameObject panel;

	public void openPanel(){
		Animator animator = panel.GetComponent<Animator>();
		if (animator != null) {
			bool isOpen = animator.GetBool ("open");
			animator.SetBool("open",!isOpen);
		}	
	}
}