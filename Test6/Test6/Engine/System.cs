using Test6.Engine.Components;
using Test6.Game.Components;

namespace Test6.Engine;
public class System
{
    public List<GameObject> GameObjects = new List<GameObject>();
    public System()
    {
        GameObject canvasGameObject = new GameObject();
        Canvas canvas = canvasGameObject.AddComponent<Canvas>();
        GameObjects.Add(canvasGameObject);

        GameObject ballGameObject = new GameObject("PGO1");
        Ball point = ballGameObject.AddComponent<Ball>();
        ballGameObject.AddComponent<CircleCollider>();
        ballGameObject.AddComponent<Move>();
        point.Transform.Position = new Vector3(0, 24);
        point.Transform.Scale = new Vector3(1, 1);
        GameObjects.Add(ballGameObject);
        /*
        GameObject groundGameObject = new GameObject("Ground");
        Square ground = groundGameObject.AddComponent<Square>();
        ground.Transform.Position = new Vector3(0, 22);
        ground.Transform.Scale = new Vector3(25, 2);
        groundGameObject.AddComponent<BoxCollider>();
        GameObjects.Add(groundGameObject);
        */
        canvas.Append(point);
        //canvas.Append(ground);
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