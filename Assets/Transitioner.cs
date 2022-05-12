using UnityEngine;

namespace Nature
{
    public class Transitioner : MonoBehaviour
    {

        [SerializeField] QuadGenerator m_quadGen1;
        [SerializeField] QuadGenerator m_quadGen2;

        [SerializeField] int n;

        [SerializeField] [Range(0f, 1f)] float m_T;


        private void Update()
        {
            DoTransition();
        }

        void DoTransition()
        {
            var l_QuadsList1 = m_quadGen1.QuadsList;
            var l_QuadsList2 = m_quadGen2.QuadsList;


            float limit = Mathf.Lerp(0,n,m_T);
            int flooredLimit = Mathf.FloorToInt(limit);

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < l_QuadsList1.Count; j += n)
                {
                    var go1 = l_QuadsList1[j];
                    var go2 = l_QuadsList2[j];

                    if (i < limit)
                    {
                            go1.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                            go2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    }
                    else
                    {
                        go1.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        go2.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    }

                    if (i == flooredLimit)
                    {
                        float sT = limit - flooredLimit;
                        float angle = Mathf.Lerp(0f, 180f, sT);

                        go1.transform.rotation = Quaternion.Euler(0f, angle, 0f);
                        go2.transform.rotation = Quaternion.Euler(0f, 180 - angle, 0f);
                    }

                }
            }
        }
    }
}   
