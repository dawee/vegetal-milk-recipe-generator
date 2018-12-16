using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
  private static double MAX_DISTANCE = 35.46;


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


	public Text almondsField;
	public Text cashewsField;
	public Text coconutField;
	public Text oatField;
	public Text peanutsField;
	public Text riceField;
	public Text soyField;
	public Text yellowPeasField;

	public Text distanceField;
	public Text similarityField;

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


		almondsField.text = string.Format("{0}g", (recipe.almondsDose * 100).ToString());
		cashewsField.text = string.Format("{0}g", (recipe.cashewsDose * 100).ToString());
		coconutField.text = string.Format("{0}g", (recipe.coconutDose * 100).ToString());
		oatField.text = string.Format("{0}g", (recipe.oatDose * 100).ToString());
		peanutsField.text = string.Format("{0}g", (recipe.peanutsDose * 100).ToString());
		riceField.text = string.Format("{0}g", (recipe.riceDose * 100).ToString());
		soyField.text = string.Format("{0}g", (recipe.soyDose * 100).ToString());
		yellowPeasField.text = string.Format("{0}g", (recipe.yellowPeasDose * 100).ToString());

		var distance = cowMilk.SimilarityScoreWith(composition);
		var similarity = (distance > MAX_DISTANCE ? 0 : (MAX_DISTANCE - distance) * 100 / MAX_DISTANCE);

		distanceField.text = distance.ToString();
		similarityField.text = string.Format("{0}%", similarity);

		return distance;
	}

	void Start () {
		Compute(new Recipe {
			almondsDose = 0.02,
			cashewsDose = 0.04,
			coconutDose = 0.06,
			oatDose = 0.08,
			peanutsDose = 0.1,
			riceDose = 0.12,
			soyDose = 0.14,
			yellowPeasDose = 0.16,
		});
	}

	void Update () {
		
	}
}
