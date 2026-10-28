using NUnit.Framework;
using UnityEngine;
using RangeAttribute = UnityEngine.RangeAttribute;

public class Parallax : MonoBehaviour
{
	/*GameObject[] backgrounds;
    Material[] mat;
    Transform mainCamera;
    Vector3 camStartPosition;
    float distance;
    float farthestBack;
	float[] backSpeed;
    [Range(0.01f, 1f)]
    public float parallaxSpeed;
    */


	[SerializeField] private float parallaxMultiplier = 0.1f;
    [SerializeField] protected Transform player;
    private Material parallaxMaterial;
    private float Playerx;


    /*void Start()
    {
        mainCamera = Camera.main.transform;
        camStartPosition = mainCamera.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
		}

        BackSpeedCalculate(backCount);

	}

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++)
        {
            if ((backgrounds[i].transform.position.z - mainCamera.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - mainCamera.position.z;

			}
		}

        for (int i = 0; i < backCount; i++)
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - mainCamera.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
        distance = mainCamera.position.x - camStartPosition.x;
        transform.position = new Vector3(mainCamera.position.x - 1, transform.position.y, -5);

        for (int i = 0; i < backSpeed.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }*/


    private void Start()
    {
        parallaxMaterial = GetComponent<Renderer>().material;
        Playerx = player.position.x;
    }
    void Update()
	{
        float delatx = player.position.x - Playerx;
        parallaxMaterial.mainTextureOffset += new Vector2(delatx * parallaxMultiplier, 0);
        Playerx = player.position.x;
	}
}