using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private MovingCube cubePrefab;
    [SerializeField] private MoveDirection moveDirection;
    public void SpawnCube()
    {
        var cube = Instantiate(cubePrefab);

        // Check if there is a previous cube and it is not the "Start" cube
        if (MovingCube.LastCube != null && MovingCube.LastCube.gameObject != GameObject.Find("Start"))
        {
            float x  = moveDirection == MoveDirection.X ? transform.position.x : MovingCube.LastCube.transform.position.x;
            float z = moveDirection == MoveDirection.Z ? transform.position.z : MovingCube.LastCube.transform.position.z;

            // Adjust the y-position based on the last cube's position and height
            cube.transform.position = new Vector3(x,
                MovingCube.LastCube.transform.position.y + cubePrefab.transform.localScale.y,
                z);
        }
        else
        {
            cube.transform.position = transform.position;
        }

        cube.MoveDirection = moveDirection;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, cubePrefab.transform.localScale);
    }
}
