using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_PowerUP : MonoBehaviour
{
    public GameObject powerUP;
    int maxPower = 1;

    List<GameObject> powerUPList = new List<GameObject>();

    private void Start()
    {
        starPowerUPList();
        StartCoroutine(spawnPowerUP());
    }

    void starPowerUPList()
    {
        for (int i = 0; i < maxPower; i++)
        {
            GameObject powerUPInList = Instantiate(powerUP, transform);
            powerUPInList.SetActive(false); // desactivar el instanciado, no el prefab
            powerUPList.Add(powerUPInList);
        }

    }

    GameObject GetPowerUP()
    {
        foreach (GameObject NewpowerUP in powerUPList)
        {
            if (!NewpowerUP.activeInHierarchy)
            {
                return NewpowerUP;
            }
        }
        return null;
    }

    IEnumerator spawnPowerUP()
    {
        while (true) // bucle infinito para spawnear cada cierto tiempo
        {
            GameObject activPowerUP = GetPowerUP();
            if (activPowerUP != null)
            {
                activPowerUP.transform.position = new Vector3(
                    Random.Range(-9.5f, 9.5f),
                    transform.position.y,
                    Random.Range(-9.5f, 9.5f)
                );
                activPowerUP.SetActive(true);
            }
            yield return new WaitForSeconds(Random.Range(3f, 6f)); // tiempo aleatorio
        }

    }
}
