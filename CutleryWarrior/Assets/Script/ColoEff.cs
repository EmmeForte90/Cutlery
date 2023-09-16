using UnityEngine;
public class ColoEff : MonoBehaviour
{
    public Color m_changeColor;    
    public GameObject m_obj;
    Renderer[] m_rnds;
    void Update()
    {
        m_rnds = m_obj.GetComponentsInChildren<Renderer>(true);
            foreach(Renderer rend in m_rnds)
            {
                for (int i = 0; i < rend.materials.Length; i++)
                {
                    rend.materials[i].SetColor("_TintColor", m_changeColor);
                    rend.materials[i].SetColor("_Color", m_changeColor);
                    rend.materials[i].SetColor("_RimColor", m_changeColor);
                }
            }
    }
}