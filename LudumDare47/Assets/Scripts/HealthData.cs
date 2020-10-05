using UnityEngine;
using System.Collections;

public class HealthData {

	public bool isDead;
	public string cause;
	public string age;

	public HealthData(bool isDead, string cause, string age) {
		this.isDead = isDead;
		this.cause = cause;
		this.age = age;
	}
}
