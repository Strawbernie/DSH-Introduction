using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
        public GameObject player;
        void Awake()
        {
            if (!StatsManager.started)
            {
                StatsManager.started = true;
                StatsManager.spawnLocation = new Vector3(-27, 0.2f, 4.64f);
                player.transform.position = new Vector3(StatsManager.spawnLocation.x, StatsManager.spawnLocation.y, StatsManager.spawnLocation.z);
            }
            player.transform.position = new Vector3(StatsManager.spawnLocation.x, StatsManager.spawnLocation.y, StatsManager.spawnLocation.z);
        player.transform.rotation = StatsManager.Rotation;
    }
    }

