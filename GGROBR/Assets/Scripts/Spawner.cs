using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SpawnPoint; //SpawnPoint, to get Position to Spawn New Tile of Obstacles
    public float PlayerDistance; //Distance Player Has Travelled
    public int DistancePerTile; //Distance Traveled Necessary to Instantiate new Tile
    public List<GameObject> TilesOfObstacles; //List of Obstacle Tiles
    private int PreviousModResult = -1; //Used to Check if New Tile Is Needed
    private List<int> ListOfChoices = new List<int> { 0, 1, 2, 3, 4, 5, 6 }; //List of Valid Choices, number of tiles, TBD 
    private List<int> ListOnCD = new List<int> { }; //List of Tiles on Cooldown
    private int ThresholdCounter = 0;
    private int Threshold1 = 10000;
    private int Threshold2 = 10000;
    private int Threshold3 = 10000;
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        int remove;
        while (i < 4)
        {
            remove = Random.Range(0, ListOfChoices.Count);
            ListOnCD.Add(remove);
            ListOfChoices.Remove(remove);
            i++;
        }
        //Sets 4 Tiles on Cooldown at the Start
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDistance = GameObject.FindWithTag("grandma").GetComponent<grandma>().DistanceTravelled;

        if (PlayerDistance > Threshold1 && ThresholdCounter < 1) 
        {
            ListOfChoices.Add(1);
            ListOfChoices.Add(2);
            ListOfChoices.Add(3); //Placeholders
            ListOfChoices.Remove(1);
            ListOfChoices.Remove(2);
            ListOfChoices.Remove(3);
            ListOnCD.Add(1);
            ListOnCD.Add(2);
            ListOnCD.Add(3); //Placeholders
            ListOnCD.Remove(1);
            ListOnCD.Remove(2);
            ListOnCD.Remove(3);
            ThresholdCounter++;
        }
        if (PlayerDistance > Threshold2 && ThresholdCounter < 2)
        {
            ListOfChoices.Add(1);
            ListOfChoices.Add(2);
            ListOfChoices.Add(3); //Placeholders
            ListOfChoices.Remove(1);
            ListOfChoices.Remove(2);
            ListOfChoices.Remove(3);
            ListOnCD.Add(1);
            ListOnCD.Add(2);
            ListOnCD.Add(3); //Placeholders
            ListOnCD.Remove(1);
            ListOnCD.Remove(2);
            ListOnCD.Remove(3);
            ThresholdCounter++;
        }
        if (PlayerDistance > Threshold3 && ThresholdCounter < 3)
        {
            ListOfChoices.Add(1);
            ListOfChoices.Add(2);
            ListOfChoices.Add(3); //Placeholders
            ListOfChoices.Remove(1);
            ListOfChoices.Remove(2);
            ListOfChoices.Remove(3);
            ListOnCD.Add(1);
            ListOnCD.Add(2);
            ListOnCD.Add(3); //Placeholders
            ListOnCD.Remove(1);
            ListOnCD.Remove(2);
            ListOnCD.Remove(3);
            ThresholdCounter++;
        }

        int ChoiceOfSpawn = Random.Range(0, ListOfChoices.Count); //Chooses a Random Tile to Spawn

        if (PlayerDistance % DistancePerTile < PreviousModResult) //Checks if Player Has Passed Threshold to Spawn New Tile by Checking if Player Has JUST Passed Threshold
        {
            ListOnCD.Add(ChoiceOfSpawn); //Adds ChoiceOfSpawn to Cooldown
            ListOfChoices.Remove(ChoiceOfSpawn); //Removes ChoiceOfSpawn from ListOfChoices
            ListOfChoices.Add(ListOnCD[0]); //Adds First Value of ListOnCD to ListOfChoices
            ListOnCD.Remove(ListOnCD[0]); //Removes First Value of ListOnCD
            Instantiate(TilesOfObstacles[ListOfChoices[ChoiceOfSpawn]], SpawnPoint.transform.position, Quaternion.identity); //Instantiate, Creates, Spawns the Tile Chosen
        }
        PreviousModResult = (int)PlayerDistance % DistancePerTile; //Used to Determine if Player has Passed Threshold
    }
}
