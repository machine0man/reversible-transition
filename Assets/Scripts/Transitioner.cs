using UnityEngine;

namespace Nature
{
    public class Transitioner : MonoBehaviour
    {

        [SerializeField] ImageMaker m_imgMaker;
        [SerializeField] [Range(0f, 1f)] float m_T;

        int m_QuadsCountAlongWidth => m_imgMaker.QuadsCountAlongWidth;


        private void Update()
        {
            DoTransition();
        }

        void DoTransition()
        {
            var l_QuadsList1 = m_imgMaker.QuadList1;
            var l_QuadsList2 = m_imgMaker.QuadList2;

            float limit = Mathf.Lerp(0,m_QuadsCountAlongWidth,m_T);
            int flooredLimit = Mathf.FloorToInt(limit);

            for (int i = 0; i < m_QuadsCountAlongWidth; i++)
            {
                for (int j = i; j < l_QuadsList1.Count; j += m_QuadsCountAlongWidth)
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
