using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Functions
    {
        public static float CalculateAngleByDirection(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

            angle = NormalizeAngle(angle);

            return angle;
        }

        public static int Random(int min, int max)
        {
            var r = UnityEngine.Random.Range(min, max+1);
            return r;
        }

        public static float RandomFloat(int min, int max)
        {
            var r = UnityEngine.Random.Range(min * 10000, max * 10000);
            return r / 10000f;
        }
        
        public static float RandomFloat(float min, float max)
        {
            var r = UnityEngine.Random.Range(min * 10000, max * 10000);
            return r / 10000f;
        }
        
        public static bool RandomChance(float percentage)
        {
            var r = Random(0, 100);
            return r < percentage;
        }

        private static float NormalizeAngle(float angle)
        {
            if (angle < 0)
            {
                angle += 360;
            }
            else if (angle >= 360)
            {
                angle -= 360;
            }

            return angle;
        }

        public static Vector3 GetDirectionBetweenPoints(Vector3 from, Vector3 to)
        {
            var direction = (to - from).normalized;

            direction.y = 1;

            return direction;
        }

        public static float GetDistanceBetweenPoints(Vector3 startPosition, Vector3 endPosition)
        {
            return Vector3.Distance(startPosition, endPosition);
        }

        public static float GetProjectileTime(float distance, float force)
        {
            return distance / force;
        }

        public static Vector3 AddAngleToDirection(Vector3 direction, float angle)
        {
            var sin = Mathf.Sin(angle * Mathf.Deg2Rad);
            var cos = Mathf.Cos(angle * Mathf.Deg2Rad);

            direction.x = (cos * direction.x) - (sin * direction.z);
            direction.z = (sin * direction.x) + (cos * direction.z);

            return direction;
        }

        public static IEnumerable<int> Range(int min, int max, int slope = 1)
        {
            var list = new List<int>();
            for (var i = min; i <= max; i = i + slope)
            {
                list.Add(i);
            }

            return list;
        }
    }
}