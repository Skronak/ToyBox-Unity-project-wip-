using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour {

	public GameObject panelLeft;

    public GameObject panelTop;

    public void openPanel() {
		Animator animator = panelLeft.GetComponent<Animator>();

        if (animator != null ) {
			bool isOpen = animator.GetBool ("open");
			animator.SetBool("open",!isOpen);
		}

        Animator animatorTop = panelTop.GetComponent<Animator>();
        if (animatorTop != null)
        {
            bool isOpen = animatorTop.GetBool("open");
            animatorTop.SetBool("open", !isOpen);
        }
    }
}