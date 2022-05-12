using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Nature
{
    public class QuadGenerator : MonoBehaviour
    {
        [SerializeField] GameObject m_prefQuad;

        [SerializeField] bool m_IsBackOne;

        List<GameObject> m_lstQuads = new List<GameObject>();

        public IReadOnlyList<GameObject> QuadsList => m_lstQuads.AsReadOnly();


        void Start()
        {
            GenerateQuads();
        }
        void GenerateQuads()
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    var go = Instantiate(m_prefQuad);
                    go.transform.position = new Vector3(x - (0.5f *x) - 5, y - (0.5f * y) - 5, 0);
                    go.GetComponent<MeshFilter>().mesh.uv = GetUVValues(x, y, 20, 20);
                    var a = GetUVValues(x, y, 10, 10);

                  //   Debug.Log($"{a[0]} ,{ a[1]},{ a[2]}, {a[3]}");

                    m_lstQuads.Add(go);
                }
            }

            if (m_IsBackOne)
            {
				foreach(var v in m_lstQuads)
				{
                    v.transform.eulerAngles = new Vector3(0f,180f,0f);
				}
            }




        }
        Vector2[] GetUVValues(float x, float y, float numX, float numY)
        {
            Vector2[] vertices = new Vector2[4]
     {
    new Vector3(x/numX, y/numY),
    new Vector3((x+1)/numX, y/numY),
    new Vector3(x/numX, (y+1)/numY),
    new Vector3((x+1)/numX, (y+1)/numY)
     };

            return vertices;
        }
     
    }
}