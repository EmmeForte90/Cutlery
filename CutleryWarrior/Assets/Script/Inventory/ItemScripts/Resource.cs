using UnityEngine;
[CreateAssetMenu(fileName = "Resource", menuName = "Item/Resource")]
public class Resource : Item
{
    public resourceType type;
    public enum resourceType { Key, Collectible, Material, Quest}
}