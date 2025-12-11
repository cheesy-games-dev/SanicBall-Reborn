using System;
using System.Collections;
using System.Collections.Generic;
using Sanicball.Logic;
using Sanicball.Gameplay;
using UnityEngine;

public class OneMinuteHelp : MonoBehaviour {
	private RaceManager manager;
	
	void Start() {
		manager = RaceManager.Instance;
	}
	
	void Update() {
		if(manager != null) {
			if(manager.RaceTime.TotalSeconds >= 5) {
                GameObject gameobject = GameObject.Find("1min Help");
                gameobject?.SetActive(true);
            }
		}else {
			manager = RaceManager.Instance;
		}
	}
}
