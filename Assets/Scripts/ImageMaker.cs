using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nature
{
    public class ImageMaker : MonoBehaviour
    {
        [SerializeField] GameObject m_prefQuad1;
        [SerializeField] GameObject m_prefQuad2;
        [SerializeField] int m_quadsCountAlongWidth = 20;
        [SerializeField] float m_imgWidth = 10f;

        List<GameObject> m_lstQuads1 = new List<GameObject>();
        List<GameObject> m_lstQuads2 = new List<GameObject>();

        public int QuadsCountAlongWidth => m_quadsCountAlongWidth;

        public IReadOnlyList<GameObject> QuadList1 => m_lstQuads1.AsReadOnly();
        public IReadOnlyList<GameObject> QuadList2 => m_lstQuads2.AsReadOnly();


        void Start()
        {
            GenerateQuads();
        }

		void GenerateQuads()
		{
            QuadGenerator l_quadGenerator = new QuadGenerator();
            m_lstQuads1 = l_quadGenerator.GenerateQuads(m_quadsCountAlongWidth, m_imgWidth,false, m_prefQuad1);
            m_lstQuads2 = l_quadGenerator.GenerateQuads(m_quadsCountAlongWidth, m_imgWidth,true, m_prefQuad2);
        }
	}
}   
