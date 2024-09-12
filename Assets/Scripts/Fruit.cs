using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Fruit : MonoBehaviour
{
    [SerializeField] Line HLine, VLine;
    
    public HashSet<Fruit> myHashSet;
   HashSet<Fruit> hNeighbours;
   HashSet<Fruit> vNeighbours;

    public GameManager gm;

    private void Awake()
    {
        
    }

    void DeleteNeighbours()
    {
        hNeighbours.Clear();
        vNeighbours.Clear();
        print(hNeighbours.Count);
        print(vNeighbours.Count);
    }

    private void OnDestroy()
    {
        gm.deleteNeighboursInEachFruit -= DeleteNeighbours;
    }
    void Start()
    {

        gm.deleteNeighboursInEachFruit += DeleteNeighbours;

        HLine.gm = gm;
        VLine.gm = gm;

        hNeighbours = new HashSet<Fruit>();
        vNeighbours = new HashSet<Fruit>();

        HLine.neighbours = hNeighbours;
        VLine.neighbours = vNeighbours;


        /*HLine = transform.Find("HLine").gameObject;
        VLine = transform.Find("VLine").gameObject;*/

        if (gameObject.tag == "Grape")
        {
            myHashSet = gm.grapes;
        }
        else if (gameObject.tag == "Apple")
        {
            myHashSet = gm.apples;
        }
        else if (gameObject.tag == "Banana")
        {
            myHashSet = gm.bananas;
        }
        else if (gameObject.tag == "Pear")
        {
            myHashSet = gm.pears;
        }
        else if (gameObject.tag == "Orange")
        {
            myHashSet = gm.oranges;
        }
        else if (gameObject.tag == "StrawBerry")
        {
            myHashSet = gm.strawBerrys;
        }
        else if (gameObject.tag == "BlueBerry")
        {
            myHashSet = gm.blueBerrys;
        }
    }

}
