using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamakiCamera : MonoBehaviour
{
    internal static object main;
    [SerializeField]
	private Material camera;

	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest, camera);
	}
}
