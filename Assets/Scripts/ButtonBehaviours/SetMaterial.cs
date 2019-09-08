using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterial : MonoBehaviour
{
    public MeshRenderer renderer;
    public int meshMaterialIndex = 0;

    public Material[] materials;
    public int materialIndex;

    private void Start() {
        onChangeMaterial();
    }

    public void nextMaterial() {
        materialIndex++;
        onChangeMaterial();
    }

    public void prevMaterial() {
        materialIndex--;
        onChangeMaterial();
    }

    public void setMaterialIndex(int index) {
        materialIndex = index;
        onChangeMaterial();
    }

    private void onChangeMaterial() {
        if (materialIndex >= materials.Length) materialIndex = 0;
        else if (materialIndex < 0) materialIndex = materials.Length;
        Material[] meshMaterials = renderer.materials;
        meshMaterials[meshMaterialIndex] = materials[materialIndex];
        renderer.materials = meshMaterials;
    }


}
