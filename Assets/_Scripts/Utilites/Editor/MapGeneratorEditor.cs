using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using World2D.Generator.Noise;

namespace World2D.Utilites
{
    [CustomEditor(typeof(GeneratorManager))]
    public class MapGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        { 
            GeneratorManager mapGen = (GeneratorManager)base.target;

            if(DrawDefaultInspector())
            {
                if(mapGen.AutoUpdate)
                {
                    mapGen.GenerateMap();
                }
            }

            if(GUILayout.Button("Generate"))
            {
                mapGen.GenerateMap();
            }
        }
    }
}
