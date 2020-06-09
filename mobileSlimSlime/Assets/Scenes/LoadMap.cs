using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
    public GameObject[] dontDestroyOnLoadObjects;
    private List<int> map;
    private List<string> doorLocations;
    public GameObject[] blocks;
    /*map legend:
     * 0    =   entrance   (this is put at -1*x automatically)
     * 1    =   farm
     * 2    =   forest
     * 3    =   mine
     * 4    =   river
     * 5    =   chest
     * 6    =   monster
     * 7    =   boss
     * 8    =   door   (add locations through doorlocations list for each door)
     * 9    =   wall   (these are put at the beginning and end of a stage automatically)
     * 10   =   SkillUpgradeStation
     * 11   =   AlchemyStation
     * */

    // Start is called before the first frame update
    void Start()
    {
        map = new List<int>();
        doorLocations = new List<string>();

        switch (SceneManager.GetActiveScene().name)
        {
            //set map creation here
            //if there are doors, set door locations
            case "Home":
                {
                    //sets hub list of blocks
                    map = new List<int>() { 8, 10, 11 };
                    doorLocations.Clear();
                    doorLocations.Add("World");
                    break;
                }
            case "World":
                {
                    map = CreateWorld(StoryProgressionManager.GetMapSize(), StoryProgressionManager.GetDifficulty());
                    break;
                }
        }

        //door counter (used to go through door scene locations)
        int door = 0;
        // Instantiate Walls on the edges of the map
        Instantiate(blocks[9], new Vector3(-2 * 1.5f, 0, 0), blocks[9].transform.rotation);
        Instantiate(blocks[9], new Vector3(map.Count * 1.5f, 0, 0), blocks[9].transform.rotation);
        // Instantiate Entrance
        Instantiate(blocks[0], new Vector3(-1 * 1.5f, 0, 0), blocks[0].transform.rotation);
        //instantiate map
        for (int i = 0; i < map.Count; i++)
        {
            //instantiates objects in blocks list
            var tempObj = Instantiate(blocks[map[i]], new Vector3(i * 1.5f, 0, 0), blocks[map[i]].transform.rotation);

            //if its a door
            if (tempObj.tag == "Door")
            {
                //adds the scene name to the changeScene script
                tempObj.GetComponent<ChangeScene>().sceneName = doorLocations[door];
                door++;
            }
            //if its an enemy
            else if ((tempObj.tag == "Boss") || (tempObj.tag == "Monster"))
           {
                //handles monster spawns
               EnemySpawn(tempObj,StoryProgressionManager.GetDifficulty());
            }
        }

        //if it doesnt find player
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            //instantiate all objects that should be on every scene
            for (int i = 0; i < dontDestroyOnLoadObjects.Length; i++)
            {
                Instantiate(dontDestroyOnLoadObjects[i]);
            }
        }

        //set player to entrance
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(
            GameObject.FindGameObjectWithTag("Entrance").transform.position.x,
            GameObject.FindGameObjectWithTag("Player").transform.position.y,
            GameObject.FindGameObjectWithTag("Player").transform.position.z);
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIControls>().MoveToEntrance();

    }

    // Update is called once per frame
    void Update()
    {
        //load back into home
        if ((GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().actionPointsCurent <= 0) && (SceneManager.GetActiveScene().name != "Home"))
        {
            SceneManager.LoadScene("Home");

            //fade
            GameObject.FindGameObjectWithTag("FadePanel").GetComponent<FadePanel>().Fade(1f);
        }
        else if (SceneManager.GetActiveScene().name == "Home")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().RefillActionPoints();
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().RefillHealthToMax();
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().RefillSPToMax();
        }
    }

    private List<int> CreateWorld(int size,int difficulty)
    {
        //starts world block list
        //each int = a block
        //read start of script for legend
        List<int> world = new List<int>();

        //fix difficulty
        difficulty = Mathf.Clamp(difficulty, 0, 10);

        //go through the size of the map (entrance and walls not included)
        for (int i = 0; i < size; i++)
        {
            world.Add(GetMapInt(difficulty));
        }

        //sets higher diffulty blocks at the end
        world.Reverse();

        //implement doors here
        //add door:
        //world.Add(8);
        //clear:
        //doorLocations.Clear();
        //add locations:
        //doorLocations.Add("World");

        return world;
    }
    private int GetMapInt(int difficulty)
    {
        int randomBlock = 0;
        int difficultyRange = Mathf.Clamp(Random.Range(0,difficulty+1),0,10);
        //depending on the difficulty it'll get different ranges
        //the difficulty will start at the current difficulty level and decrease by one
        //each time grabbing a block within the difficulty ranges
        switch (difficultyRange)
        {
            case 0:
                {
                    randomBlock = Random.Range(1, 5);
                    break;
                }
            case 1:
                {
                    randomBlock = Random.Range(1, 5);
                    break;
                }
            case 2:
                {
                    randomBlock = Random.Range(1, 7);
                    break;
                }
            case 3:
                {
                    randomBlock = Random.Range(1, 7);
                    break;
                }
            case 4:
                {
                    randomBlock = Random.Range(5, 7);
                    break;
                }
            case 5:
                {
                    randomBlock = Random.Range(5, 7);
                    break;
                }
            case 6:
                {
                    randomBlock = Random.Range(5, 7);
                    break;
                }
            case 7:
                {
                    randomBlock = Random.Range(5, 8);
                    break;
                }
            case 8:
                {
                    randomBlock = Random.Range(6, 8);
                    break;
                }
            case 9:
                {
                    randomBlock = Random.Range(6, 8);
                    break;
                }
            case 10:
                {
                    randomBlock = 7;
                    break;
                }
        }
        return randomBlock;
    }
    private void EnemySpawn(GameObject enemyBlock,int mapDifficulty)
    {
        //if there is an enemy script attached
        if (enemyBlock.TryGetComponent<Enemy>(out Enemy en))
        {
            //replace this with monster spawning function
            int random = Random.Range(0, StoryProgressionManager.GetMaxEnemyUnlocked());
            switch (random)
            {
                case 0:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Fish);
                        break;
                    }
                case 1:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Lizzard);
                        break;
                    }
                case 2:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Cat);
                        break;
                    }
                case 3:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Scorpion);
                        break;
                    }
                case 4:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Slime);
                        break;
                    }
                case 5:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Fox);
                        break;
                    }
                case 6:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Boar);
                        break;
                    }
                case 7:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Wolf);
                        break;
                    }
                case 8:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Bear);
                        break;
                    }
                case 9:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Goblin);
                        break;
                    }
                case 10:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.LandFish);
                        break;
                    }
                case 11:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.LizardMan);
                        break;
                    }
                case 12:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Eagle);
                        break;
                    }
                case 13:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Kappa);
                        break;
                    }
                case 14:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.ArmoredBoar);
                        break;
                    }
                case 15:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Pixie);
                        break;
                    }
                case 16:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.FireFox);
                        break;
                    }
                case 17:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Frog);
                        break;
                    }
                case 18:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Panda);
                        break;
                    }
                case 19:
                    {
                        enemyBlock.GetComponent<Enemy>().SetEnemy(EnemiesDatabase.enemy.Golem);
                        break;
                    }
            }
            enemyBlock.name = enemyBlock.GetComponent<Enemy>().GetEnemyType().ToString();
        }
    }
}
