using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTestScript : NetworkBehaviour
{
    public GameObject cube;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("spawn");
            CmdSpawnCube();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject go = GameObject.Find("CubeTest(Clone)");
            Debug.Log("supprime");
            Destroy(go);
        }
    }

    void CmdSpawnCube()
    {
        GameObject instantiCube = (GameObject)Instantiate(cube, cube.transform.position, Quaternion.identity);
        GameObject owner = this.gameObject;
        NetworkServer.Spawn(instantiCube, owner);
    }
}
