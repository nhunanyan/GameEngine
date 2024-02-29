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
        
        
        GameObject squareGameObject1 = new GameObject("GO1");
        Square square1=squareGameObject1.AddComponent<Square>();
        squareGameObject1.AddComponent<BoxCollider>();
        var squareMove1=squareGameObject1.AddComponent<Move2>();
        squareMove1.SetBounds(new Bounds(new Vector3(canvas.Size * 0.5f, canvas.Size * 0.5f, 0),
            new Vector3(canvas.Size, canvas.Size)));
        square1.Transform.Position = new Vector3(1, 1);
        square1.Transform.Scale = new Vector3(5, 5);
        GameObjects.Add(squareGameObject1);
        
        GameObject squareGameObject2 = new GameObject("GO2");
        Square square2=squareGameObject2.AddComponent<Square>();
        squareGameObject2.AddComponent<BoxCollider>();
        var squareMove2=squareGameObject2.AddComponent<Move>();
        squareMove2.SetBounds(new Bounds(new Vector3(canvas.Size * 0.5f, canvas.Size * 0.5f, 0),
            new Vector3(canvas.Size, canvas.Size)));
        square2.Transform.Position = new Vector3(14, 4);
        square2.Transform.Scale = new Vector3(5, 5);
        GameObjects.Add(squareGameObject2);
        
        canvas.Append(square1);
        canvas.Append(square2);
        
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
            Thread.Sleep(1000);
        }
    }
}