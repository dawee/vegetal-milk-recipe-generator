using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Recipe {
	public double almondsDose;
	public double cashewsDose;
	public double coconutDose;
	public double oatDose;
	public double peanutsDose;
	public double riceDose;
	public double soyDose;
	public double yellowPeasDose;
}

public class SimilarityComputer : MonoBehaviour {
	public Composition cowMilk;
	public Composition almondsComposition;
	public Composition cashewsComposition;
	public Composition coconutComposition;
	public Composition oatComposition;
	public Composition peanutsComposition;
	public Composition riceComposition;
	public Composition soyComposition;
	public Composition yellowPeasComposition;
	public Recipe recipe;

	double Compute(Recipe recipe) {
		var composition = Composition.Blend(new List<Composition>() {
			almondsComposition.Dose(recipe.almondsDose),
			cashewsComposition.Dose(recipe.cashewsDose),
			coconutComposition.Dose(recipe.coconutDose),
			oatComposition.Dose(recipe.oatDose),
			peanutsComposition.Dose(recipe.peanutsDose),
			riceComposition.Dose(recipe.riceDose),
			soyComposition.Dose(recipe.soyDose),
			yellowPeasComposition.Dose(recipe.yellowPeasDose),
		});

		return cowMilk.SimilarityScoreWith(composition);
	}

	void Start () {
		var result = Compute(new Recipe {
			yellowPeasDose = 0.1,
			riceDose = 0.1,
			peanutsDose = 0.1
		});

		Debug.Log(result);
	}
	void Update () {
		
	}
}
