using UnityEngine;
using System.Collections;
using DG.Tweening;
using Bolt;


[CreateAssetMenu(menuName = "AI Skills/Rain Of Fire", order = 5)]
public class RainOfFire : AbilityPrototype
{
    public void SpawnMeteor(GameObject caster)
    {
        var impactPosition = caster.GetComponent<UnitStatss>().unitTarget;
        Vector3[] positions = new Vector3[2];
        for(int i = 0; i < positions.Length; i++)
        {
            positions[i] = CalculateMeteorArea(impactPosition.transform.position, 3.0f);
            Vector3 skyPosition = new Vector3(positions[i].x, positions[i].y + 4.0f, positions[i].z);
            var meteor = FindObjectOfType<PoolModule>().pooler.SpawnFromPool("MeteorPool", skyPosition);
            meteor.transform.DOMove(positions[i], 1.0f);
        }
    }

    public Vector3 CalculateMeteorArea(Vector3 center, float radius)
    {
        float randomPoint = Random.Range(0, radius);
        float angle = Mathf.PI * 2 * randomPoint;

        float r = radius * Mathf.Sqrt(randomPoint);

        float xPoint = r * Mathf.Cos(angle);
        float yPoint = r * Mathf.Sin(angle);

        float xCenterPoint = xPoint + center.x;
        float yCenterPoint = yPoint + center.z;

        Vector3 newVector = new Vector3(xCenterPoint, 1.0f, yCenterPoint);
        return newVector;
    }
    
    public override void CastAbility(GameObject caster, int behaviour)
    {
        switch(behaviour)
        {
            case 0:
                SpawnMeteor(caster);
                break;
        }
    }

    public override void SetIndicatorController(GameObject caster)
    {
        throw new System.NotImplementedException();
    }


}
