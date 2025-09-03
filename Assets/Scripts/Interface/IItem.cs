using UnityEngine;
public enum TypeIItem
{
    Weapon,
    Potion,
}
public interface IItem
{
    string Name { get; }
    Sprite Icon { get; }
    TypeIItem TypeItem { get; }
}