using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyReward))]
public class ObjectType : MonoBehaviour
{
    public enum ObjectTypes { CastleWall, House, Farm, Villager, CastleTower, Bandit, BanditCamp, King };
    public ObjectTypes objectType;
}
