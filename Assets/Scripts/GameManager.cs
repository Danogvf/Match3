using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int escCount = 1;
    public TMP_Text pointstext;
    public int points;
    public Fruit[] fruits;
    public GameObject[] spawnPoints;
    public HashSet<Fruit> grapes;
    public HashSet<Fruit> bananas;
    public HashSet<Fruit> apples;
    public HashSet<Fruit> blueBerrys;
    public HashSet<Fruit> pears;
    public HashSet<Fruit> strawBerrys;
    public HashSet<Fruit> oranges;
    public GameObject menu;
    public HashSet<Fruit>[] allFruits;
    public Transform rayCaster;

    public Vector2 fruitColliderSize = new Vector2(1.73913f, 1.73913f);

    public event Action deleteNeighboursInEachFruit;
    void Start()
    {
        SpawnFruits();
        oranges = new HashSet<Fruit>();
        strawBerrys = new HashSet<Fruit>();
        pears = new HashSet<Fruit>();
        blueBerrys = new HashSet<Fruit>();
        apples = new HashSet<Fruit>();
        bananas = new HashSet<Fruit>();
        grapes = new HashSet<Fruit>();
        pointstext.text = points.ToString();
      
        allFruits =new[] { oranges, strawBerrys,pears, blueBerrys,apples, bananas, grapes };
    }
    public void SpawnFruits()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject randomFruit = Instantiate(fruits[UnityEngine.Random.Range(0, fruits.Length)].gameObject);
            randomFruit.transform.position = spawnPoints[i].transform.position;
            randomFruit.GetComponent<Fruit>().gm = this;
            randomFruit.GetComponent<BoxCollider2D>().size = fruitColliderSize;

        }

        RaycastHit2D[] hits = Physics2D.RaycastAll(rayCaster.position, Vector2.down * 15);

        if (hits.Length != 0)
        {
            foreach (var hit in hits)
            {
                print(hit.collider.name);
            }
        }
    }
   public void CollectAllFruits()
    {
        //print(allFruits.Length);
        for (int i = 0; i < allFruits.Length; i++)
        {
            //print(allFruits[i].Count);
            foreach (var fruit in allFruits[i])
            {
                points += 1;
                Destroy(fruit.gameObject);

            }
            pointstext.text = points.ToString();
            allFruits[i].Clear();
           // print(allFruits[i].Count);
        }
        deleteNeighboursInEachFruit?.Invoke();

        


    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && escCount == 1)
        {
            escCount++;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            menu.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.Escape) && escCount == 2)
        {
            escCount--;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1;
            menu.SetActive(false);
        }
    }
}
