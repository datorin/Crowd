using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Persistence
{
    public static class Extensions
    {
        public static Vector3 Times(this Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        public static T Random<T>(this IEnumerable<T> list)
        {
            try
            {
                return list.ToList()[Functions.Random(0, list.Count())];
            }
            catch (Exception e)
            {
                return list.First();
            }
            
        }
        
        public static IEnumerable<T> Clone<T>(this IEnumerable<T> list)
        {
            return list.ToList();
        }

        public static IEnumerable<GameObject> GetAllChildren(this Transform transform)
        {
            var list = new List<GameObject>();
            try
            {
                for (var i = 0; true; i++)
                {
                    list.Add(transform.GetChild(i).gameObject);
                }
            }
            catch (Exception e)
            {
                return list;
            }
        }
    }
}