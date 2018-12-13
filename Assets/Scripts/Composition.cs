using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Protein {
  public double tryptophan;
  public double threonin;
  public double isoleucin;
  public double leucin;
  public double lysin;
  public double methionin;
  public double cystin;
  public double phenylalanin;
  public double tyrosin;
  public double valin;
  public double arginin;
  public double histidin;
  public double alanin;
  public double asparticAcid;
  public double glutamicAcid;
  public double glycin;
  public double proline;
  public double serine;
}

[System.Serializable]
public struct Lipid {
  public double saturatedFat;
  public double monoInsaturatedAcid;
  public double polyInsaturatedAcid;
}

[System.Serializable]
public struct Glucid {
  public double sugar;
}

[System.Serializable]
public class Composition : MonoBehaviour {
  public Protein protein;
  public Lipid lipid;
  public Glucid glucid;

  private static double MAX_DISTANCE = 35.46;

  public static Composition Null = new Composition {
    protein = new Protein {
      tryptophan = 0,
      threonin = 0,
      isoleucin = 0,
      leucin = 0,
      lysin = 0,
      methionin = 0,
      cystin = 0,
      phenylalanin = 0,
      tyrosin = 0,
      valin = 0,
      arginin = 0,
      histidin = 0,
      alanin = 0,
      asparticAcid = 0,
      glutamicAcid = 0,
      glycin = 0,
      proline = 0,
      serine = 0,
    },
    lipid = new Lipid {
      saturatedFat = 0,
      monoInsaturatedAcid = 0,
      polyInsaturatedAcid = 0,
    },
    glucid = new Glucid {
      sugar = 0,
    }
  };

  public static Composition Blend(List<Composition> compositions) {
    var result = Null;

    foreach (Composition composition in compositions) {
      result = Add(result, composition);
    }

    return result;
  }

  public static Composition Add(Composition compositionA, Composition compositionB) {
    return new Composition {
      protein = new Protein {
        tryptophan = compositionA.protein.tryptophan + compositionB.protein.tryptophan,
        threonin = compositionA.protein.threonin + compositionB.protein.threonin,
        isoleucin = compositionA.protein.isoleucin + compositionB.protein.isoleucin,
        leucin = compositionA.protein.leucin + compositionB.protein.leucin,
        lysin = compositionA.protein.lysin + compositionB.protein.lysin,
        methionin = compositionA.protein.methionin + compositionB.protein.methionin,
        cystin = compositionA.protein.cystin + compositionB.protein.cystin,
        phenylalanin = compositionA.protein.phenylalanin + compositionB.protein.phenylalanin,
        tyrosin = compositionA.protein.tyrosin + compositionB.protein.tyrosin,
        valin = compositionA.protein.valin + compositionB.protein.valin,
        arginin = compositionA.protein.arginin + compositionB.protein.arginin,
        histidin = compositionA.protein.histidin + compositionB.protein.histidin,
        alanin = compositionA.protein.alanin + compositionB.protein.alanin,
        asparticAcid = compositionA.protein.asparticAcid + compositionB.protein.asparticAcid,
        glutamicAcid = compositionA.protein.glutamicAcid + compositionB.protein.glutamicAcid,
        glycin = compositionA.protein.glycin + compositionB.protein.glycin,
        proline = compositionA.protein.proline + compositionB.protein.proline,
        serine = compositionA.protein.serine + compositionB.protein.serine,
      },
      lipid = new Lipid {
        saturatedFat = compositionA.lipid.saturatedFat + compositionB.lipid.saturatedFat,
        monoInsaturatedAcid = compositionA.lipid.monoInsaturatedAcid + compositionB.lipid.monoInsaturatedAcid,
        polyInsaturatedAcid = compositionA.lipid.polyInsaturatedAcid + compositionB.lipid.polyInsaturatedAcid,
      },
      glucid = new Glucid {
        sugar = compositionA.glucid.sugar + compositionB.glucid.sugar
      }
    };
  }

  public double SimilarityScoreWith(Composition candidate) {
    var distance =
        Math.Pow(candidate.protein.tryptophan - this.protein.tryptophan, 2)
        + Math.Pow(candidate.protein.threonin - this.protein.threonin, 2)
        + Math.Pow(candidate.protein.isoleucin - this.protein.isoleucin, 2)
        + Math.Pow(candidate.protein.leucin - this.protein.leucin, 2)
        + Math.Pow(candidate.protein.lysin - this.protein.lysin, 2)
        + Math.Pow(candidate.protein.methionin - this.protein.methionin, 2)
        + Math.Pow(candidate.protein.cystin - this.protein.cystin, 2)
        + Math.Pow(candidate.protein.phenylalanin - this.protein.phenylalanin, 2)
        + Math.Pow(candidate.protein.tyrosin - this.protein.tyrosin, 2)
        + Math.Pow(candidate.protein.valin - this.protein.valin, 2)
        + Math.Pow(candidate.protein.arginin - this.protein.arginin, 2)
        + Math.Pow(candidate.protein.histidin - this.protein.histidin, 2)
        + Math.Pow(candidate.protein.alanin - this.protein.alanin, 2)
        + Math.Pow(candidate.protein.asparticAcid - this.protein.asparticAcid, 2)
        + Math.Pow(candidate.protein.glutamicAcid - this.protein.glutamicAcid, 2)
        + Math.Pow(candidate.protein.glycin - this.protein.glycin, 2)
        + Math.Pow(candidate.protein.proline - this.protein.proline, 2)
        + Math.Pow(candidate.protein.serine - this.protein.serine, 2)
        + Math.Pow(candidate.lipid.saturatedFat - this.lipid.saturatedFat, 2)
        + Math.Pow(candidate.lipid.monoInsaturatedAcid - this.lipid.monoInsaturatedAcid, 2)
        + Math.Pow(candidate.lipid.polyInsaturatedAcid - this.lipid.polyInsaturatedAcid, 2)
        + Math.Pow(candidate.glucid.sugar - this.glucid.sugar, 2);

    return distance > MAX_DISTANCE ? 0 : (MAX_DISTANCE - distance) * 100 / MAX_DISTANCE;
  }

  public Composition Dose(double coef) {
    return new Composition {
      protein = new Protein {
        tryptophan = protein.tryptophan * coef,
        threonin = protein.threonin * coef,
        isoleucin = protein.isoleucin * coef,
        leucin = protein.leucin * coef,
        lysin = protein.lysin * coef,
        methionin = protein.methionin * coef,
        cystin = protein.cystin * coef,
        phenylalanin = protein.phenylalanin * coef,
        tyrosin = protein.tyrosin * coef,
        valin = protein.valin * coef,
        arginin = protein.arginin * coef,
        histidin = protein.histidin * coef,
        alanin = protein.alanin * coef,
        asparticAcid = protein.asparticAcid * coef,
        glutamicAcid = protein.glutamicAcid * coef,
        glycin = protein.glycin * coef,
        proline = protein.proline * coef,
        serine = protein.serine * coef,
      },
      lipid = new Lipid {
        saturatedFat = lipid.saturatedFat * coef,
        monoInsaturatedAcid = lipid.monoInsaturatedAcid * coef,
        polyInsaturatedAcid = lipid.polyInsaturatedAcid * coef,
      },
      glucid = new Glucid {
        sugar = glucid.sugar * coef
      }
    };
  }
};