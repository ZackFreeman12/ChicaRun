
using System.Collections.Generic;
using UnityEngine;

namespace ChicaRun
{
    public class TileSpawner : MonoBehaviour
    {
        [SerializeField]
        private int tileStartCount = 5;
        [SerializeField]
        private GameObject startingTile;
        [SerializeField]
        private List<GameObject> tilesList;
        [SerializeField]
        private int maximumClearTiles = 10;
        [SerializeField]
        private bool testingMode = false;
        [SerializeField]
        private GameObject testTile;

        private Vector3 currentTileLocation;
        private GameObject prevTile;
        private List<GameObject> currentTiles;
        private Tile tileToBeSpawned;


        private void Start()
        {
            currentTiles = new List<GameObject>();
            Random.InitState(System.DateTime.Now.Millisecond);

            for (int i = 0; i < tileStartCount; ++i)
            {
                SpawnTile(startingTile.GetComponent<Tile>());
            }

        }


        private void SpawnTile(Tile tile)
        {
            if (tile.type == 0)
            {
                prevTile = GameObject.Instantiate(tile.gameObject, currentTileLocation, Quaternion.identity);
                currentTiles.Add(prevTile);
                currentTileLocation += Vector3.Scale(prevTile.GetComponent<Renderer>().bounds.size, Vector3.forward);
            }
            else
            {

                prevTile = GameObject.Instantiate(tile.gameObject, currentTileLocation, Quaternion.identity);
                SetCoins(Random.Range(0, 3), prevTile.GetComponent<Tile>());
                currentTiles.Add(prevTile);
                currentTileLocation += Vector3.Scale(prevTile.GetComponent<Renderer>().bounds.size, Vector3.forward);
            }


        }

        private GameObject SelectRandomTile(List<GameObject> list)
        {
            if (list.Count == 0) return null;

            return list[Random.Range(0, list.Count)];
        }

        public void AddTile()
        {
            if (testingMode)
            {
                SpawnTile(testTile.GetComponent<Tile>());
            }
            else
            {
                SpawnTile(SelectRandomTile(tilesList).GetComponent<Tile>());
            }


        }
        public void SetCoins(int lane, Tile tile)
        {
            for (int i = 0; i < tile.coinTrails.Count; i++)
            {
                tile.coinTrails[i].SetActive(false);
            }
            tile.coinTrails[lane].SetActive(true);
            Debug.Log(lane);
        }
        public void DeleteTile()
        {
            GameObject tile = currentTiles[0];
            currentTiles.RemoveAt(0);
            Destroy(tile);
        }
    }

}

