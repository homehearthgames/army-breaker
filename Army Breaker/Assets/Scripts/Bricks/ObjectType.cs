using System.Collections.Generic;
using UnityEngine;

public class ObjectType : MonoBehaviour
{
    public enum ObjectTypes { CastleWall, House, Farm, Villager, CastleTower, Bandit, BanditCamp, King };
    public ObjectTypes objectType;
}
