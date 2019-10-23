using UnityEngine;

namespace DefaultNamespace
{
    public static class ExtensionMethods
    {
        private static float _yCoord;
        
        public static Vector3 RandomPositionInCollider(Collider collider)
        {
            // 1.738f for exit reference. This value can be changed with the method ChangeYCoord.
            var bounds = collider.bounds;
            return new Vector3(Random.Range(bounds.max.x, bounds.max.x - 2), 1.738f, Random.Range(bounds.min.z, bounds.max.z));
        }

        // Changes the y coordinate of the 
        public static void ChangeYCoord(float value)
        {
            _yCoord = value;
        }
        
        // Denne metode kan kaldes:             transform.ResetTransformation();, wow det er smart
        public static void ResetTransformation(this Transform trans)
        {
            trans.position = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = new Vector3(1, 1, 1);
            
        }
        
    }
}