using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsFramework : MonoBehaviour
{
    public GameObject explosionSphere;
    public GameObject bullet;
    IEnumerator VisualizeBullet(Vector3 s,Vector3 e,float step)
    {
        GameObject obj = Instantiate(bullet);
        var beam = obj.GetComponent<LineRenderer>();
        float dist = (s - e).magnitude;
        Vector3 lastPos = s;
        for (float t = Mathf.Min(step,dist); t <= dist; t += step)
        {
            Vector3 ne = s + (e - s) * (t/dist);
            beam.SetPosition(0, lastPos);
            beam.SetPosition(1, ne);
            lastPos = ne;
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(obj);
    }
    IEnumerator VisualizeExplosion(Vector3 pos)
    {
        GameObject ex = Instantiate(explosionSphere);
        ex.transform.position = pos;
        Material mat = ex.GetComponent<Renderer>().material;
        for (float s = 0; s <= 10; s += 1)
        {
            ex.transform.localScale = new Vector3(s, s, s);
            ex.GetComponent<Renderer>().material.color = new Color(mat.color.r, mat.color.g, mat.color.b, 1-s/10f);
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(ex);
    }
    public void Fire(Vector3 startPos,Vector3 vector, float length,float damage,float bulletType,float maxExplodeDist)
    {
        RaycastHit hit;
        if(Physics.Raycast(startPos, vector * length, out hit))
        {
            if (bulletType == 1f)
            {
                GameObject ho = hit.collider.gameObject;
                if (ho.GetComponent<HealthSystem>())
                {
                    ho.GetComponent<HealthSystem>().GiveDamage(damage);
                }
                StartCoroutine(VisualizeBullet(startPos, hit.point,1f));
            }
            else if (bulletType == 2f)
            {
                StartCoroutine(VisualizeExplosion(hit.point));
                ZombieController[] zombies = FindObjectsOfType<ZombieController>();
                for (int i = 0; i <= zombies.Length - 1; i += 1)
                {
                    if ((zombies[i].transform.position - hit.point).magnitude <= maxExplodeDist)
                    {
                        zombies[i].GetComponent<HealthSystem>().GiveDamage(damage * (1 - (zombies[i].transform.position - hit.point).magnitude / maxExplodeDist));
                    }
                }
            }
        }
        else if (bulletType == 1f)
        {
            StartCoroutine(VisualizeBullet(startPos, startPos+vector*length, 1f));
        }

    }
}
