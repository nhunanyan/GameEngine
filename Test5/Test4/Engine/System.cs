using Test4.Game;

namespace Test4.Engine;

using Test4.Engine.Components;
using Test4.Game.Components;
public class System
{
    public List<GameObject> GameObjects = new List<GameObject>();
    public System()
    {
        GameObject canvasGameObject = new GameObject();
        Canvas canvas = canvasGameObject.AddComponent<Canvas>();
        GameObjects.Add(canvasGameObject);

        GameObject pointGameObject = new GameObject("PGO1");
        Point point = pointGameObject.AddComponent<Point>();
        pointGameObject.AddComponent<CircleCollider>();
        pointGameObject.AddComponent<Move>();
        point.Transform.Position = new Vector3(1, 1);
        point.Transform.Scale = new Vector3(1, 1);
        GameObjects.Add(pointGameObject);

        GameObject groundGameObject = new GameObject("Ground");
        Square ground = groundGameObject.AddComponent<Square>();
        ground.Transform.Position = new Vector3(0, 22);
        ground.Transform.Scale = new Vector3(25, 2);
        groundGameObject.AddComponent<BoxCollider>();
        GameObjects.Add(groundGameObject);
        
        canvas.Append(point);
        canvas.Append(ground);
    }

    private void CollisionDetection()
    {
        for (int i = 0; i < GameObjects.Count; i++)
        {
            ICollider current = GameObjects[i].GetComponent<ICollider>();
            if (current == null)
            {
                continue;
            }

            for (int j = i + 1; j < GameObjects.Count; j++)
            {
                ICollider next = GameObjects[j].GetComponent<ICollider>();
                if (next == null)
                {
                    continue;
                }

                if (current.Intersect(next))
                {
                    GameObjects[i].OnCollisionDetect(next);
                }
            }
        }
    }

    public void Run()
    {
        while (true)
        {
            CollisionDetection();
            for (int j = 0; j < GameObjects.Count; j++)
            {
                GameObjects[j].Update();
            }
            Thread.Sleep(100);
        }
    }
}