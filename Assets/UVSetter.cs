using UnityEngine;

namespace Nature
{
    public class UVSetter : MonoBehaviour
    {

		[SerializeField] MeshFilter m_meshFilter;

		private void Start()
		{
			Mesh l_mesh = m_meshFilter.mesh;
			l_mesh.uv = new Vector2[4]
	 {
			new Vector2(0, 0),
			new Vector2(0.5f, 0),
			new Vector2(0, 0.5f),
			new Vector2(0.5f, 0.5f)
	 };




		}



	}
}   
