using System.Collections.Generic;
using UnityEngine;

namespace World2D.Generator
{
    public class VisualDisplay : MonoBehaviour
    {
        private Transform objectParent;

        public void Render(Transform parentTransform, Queue<VisualToRender> awaitingObjects)
        {
            objectParent = CreateTransform("Object Parent", parentTransform);

            DrawObjects(awaitingObjects);
        }

        private Transform CreateTransform(string name, Transform parent)
        {
            GameObject gameObject = new GameObject(name);
            gameObject.transform.parent = parent;

            return gameObject.transform;
        }

        private void DrawObjects(Queue<VisualToRender> awaitingObjects)
        {
            while (awaitingObjects.Count > 0)
            {
                VisualToRender val = awaitingObjects.Dequeue();
                CreateObject(val.Prefab as GameObject, val.Position, val.Scale);
            }
        }

        private GameObject CreateObject(GameObject prefab, Vector3 position, float scale)
        {
            GameObject gameObject = GameObject.Instantiate(prefab, position, Quaternion.identity, objectParent);
            gameObject.transform.localScale = new Vector3(scale, scale, scale);

            return gameObject;
        }
    }
}