using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

	public Wealth PWealth {
		get; set;
	}
	public Childhood PChildhood {
		get; set;
	}
	public TeenagePersonality PTeenagePersonality {
		get; set;
	}

	private void Start() {
		ResetLife();
	}

    private void ResetLife() {
		PWealth = Wealth.None;
		PChildhood = Childhood.None;
		PTeenagePersonality = TeenagePersonality.None;
	}

    private bool DetermineWealthOnBirth() {
		return Random.Range(0, 11) >= 9;
	}

	private void ChangeToDay() {
	
	}

    private void ChangeToNight() {
      
    }
}
