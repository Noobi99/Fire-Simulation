using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
 
namespace Tests
{
    public class PersonHighlighterTests
    {
        [UnityTest]
        public IEnumerator _Instantiates_GameObject_From_Prefab()
        {
            yield return null;
        }


        [TearDown]
        public void AfterTest()
        {
            foreach (var gameObject in GameObject.FindGameObjectsWithTag("Person"))
            {
                Object.Destroy(gameObject);
            }
        }
    }
}
