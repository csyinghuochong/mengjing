using UnityEngine;
// Animation clips toggle the original body renderers during the death transition.
// Keep added armor in the same visibility state without changing those clips.
public sealed class FrostTrollEquipmentVisibility : MonoBehaviour {
 public SkinnedMeshRenderer source;
 public Renderer[] armor;
 void LateUpdate(){if(!source)return;foreach(var r in armor)if(r)r.enabled=source.enabled;}
}
