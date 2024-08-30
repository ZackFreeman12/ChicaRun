using System.Collections.Generic;
using UnityEngine;

namespace ChicaRun
{
    public enum TileType
    {
        CLEAR,
        TALLLEFT,
        TALLRIGHT,
        TALLMID,
        TALLLEFTRIGHT,
        SHORTLEFT,
        SHORTMID,
        SHORTRIGHT,
        SHORTLEFTRIGHT,
        SHORTAll,
        SLIDELEFT,
        SLIDERIGHT,
        SLIDEMID,
        SLIDELEFTRIGHT,
        SLIDEALL,

    }

    public class Tile : MonoBehaviour
    {
        public TileType type;
        public Transform pivot;
        public List<GameObject> coinTrails;


    }
}
