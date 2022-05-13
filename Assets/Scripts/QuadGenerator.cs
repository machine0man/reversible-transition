using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Nature
{
    public class QuadGenerator
    {
        List<GameObject> m_lstQuads;

        public List<GameObject> GenerateQuads(int a_quadsCountAlongWidth, float a_imgWidth, bool a_IsBackOne, GameObject a_prefQuad)
        {
            m_lstQuads = new List<GameObject>();
            float l_quadSize = a_imgWidth / a_quadsCountAlongWidth;
            Vector3 l_quadScale = new Vector3(l_quadSize, l_quadSize, l_quadSize);

            Transform l_holder = new GameObject().transform;

            for (int l_quadIndexY = 0; l_quadIndexY < a_quadsCountAlongWidth; l_quadIndexY++)
            {
                for (int l_quadIndexX = 0; l_quadIndexX < a_quadsCountAlongWidth; l_quadIndexX++)
                {
                    GameObject l_go = Object.Instantiate(a_prefQuad, l_holder.transform);
                    l_go.transform.position = new Vector3
                        (
                        (l_quadSize * l_quadIndexX) - a_imgWidth / 2f,
                        (l_quadSize * l_quadIndexY) - a_imgWidth / 2f,
                        0f
                        );

                    l_go.GetComponent<MeshFilter>().mesh.uv = GetUVValues(l_quadIndexX, l_quadIndexY, a_quadsCountAlongWidth, a_quadsCountAlongWidth);
                    l_go.transform.localScale = l_quadScale;

                    //   var a = GetUVValues(x, y, N, N);
                    //   Debug.Log($"{a[0]} ,{ a[1]},{ a[2]}, {a[3]}");

                    m_lstQuads.Add(l_go);
                }
            }

            if (a_IsBackOne)
            {
                foreach (GameObject l_quad in m_lstQuads)
                {
                    l_quad.transform.eulerAngles = new Vector3(0f, 180f, 0f);
                }

                l_holder.gameObject.name = "backQuadsHolder";
            }
            else
            {
                l_holder.gameObject.name = "frontQuadsHolder";
            }

            return m_lstQuads;
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