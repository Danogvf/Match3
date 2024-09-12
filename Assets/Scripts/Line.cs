using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]  string myTag;

    [SerializeField] List<GameObject> testList;

    public GameManager gm;
    public Fruit parentFruit;
    public HashSet<Fruit> neighbours;
    public HashSet<Fruit> myHashSet;
    Collider2D collider;
    private void Awake()
    {
        collider = GetComponent<Collider2D>();



    }
    void Start()
    {
        myTag = parentFruit.gameObject.tag;

        myHashSet = parentFruit.myHashSet;


        Invoke("ActivateCollider", 1);

    }

    void ActivateCollider()
    {
        collider.enabled = true;
        //collider.transform.position = collider.transform.position;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.isTrigger == false)
        {
            var possibleNeighbourFruit = collision.gameObject.GetComponent<Fruit>();

            if (collision.gameObject.tag == myTag && possibleNeighbourFruit != parentFruit)
            {
            
                neighbours.Add(possibleNeighbourFruit);
                testList.Add(possibleNeighbourFruit.gameObject);


                if (neighbours.Count == 2)
                {
                    myHashSet.Add(parentFruit);
                    foreach (var fruit in neighbours)
                    {
                        myHashSet.Add(fruit);
                    }
                }
            }
        }
            
    }

    public void Check()
    {
 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
