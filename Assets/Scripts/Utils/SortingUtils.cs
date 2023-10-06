using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Utils {
    public static class SortingUtils {
        public static GameObject GetClosestTarget(Vector3 sourcePosition, GameObject[] targets) {
            Array.Sort(targets, (a, b) => {
                return Vector3.Distance(a.transform.position, sourcePosition).CompareTo(Vector3.Distance(b.transform.position, sourcePosition));
            });
             return targets[0];
        }
    }
}
