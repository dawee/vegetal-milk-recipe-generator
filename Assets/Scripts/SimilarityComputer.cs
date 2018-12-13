using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Recipe {
	public double cashewsDose;
	public double yellowPeasDose;
}

public class SimilarityComputer : MonoBehaviour {
	public Composition cowMilk;
	public Composition cashews;
	public Composition yellowPeas;
	public Recipe recipe;

	double Compute(Recipe recipe) {
		var composition = Composition.Blend(new List<Composition>() {
			cashews.Dose(recipe.cashewsDose),
			yellowPeas.Dose(recipe.yellowPeasDose),
		});

		return cowMilk.SimilarityScoreWith(composition);
	}

	void Start () {
		var result = Compute(new Recipe {
			yellowPeasDose = 0.9,
			cashewsDose = 0.1
		});

		Debug.Log(result);
	}
	void Update () {
		
	}
}
