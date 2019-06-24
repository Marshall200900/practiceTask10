using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10
{
    class Node
    {
        public int Level;
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int value)
        {
            Value = value;
        }
    }
    class Tree
    {
        public Node Root;
        public Tree(int[] array)
        {

            if (array.Length == 0) return;
            Root = new Node(array[0]);
            Node pointer = Root;
            for (int i = 1; i < array.Length; i++)
            {
                while (pointer != null)
                {
                    if (array[i] < pointer.Value)
                    {
                        if (pointer.Left != null)
                            pointer = pointer.Left;
                        else
                        {
                            pointer.Left = new Node(array[i]);
                            pointer = Root;
                            break;
                        }
                    }
                    else if (array[i] >= pointer.Value)
                    {
                        if (pointer.Right != null)
                            pointer = pointer.Right;
                        else
                        {
                            pointer.Right = new Node(array[i]);
                            pointer = Root;
                            break;
                        }
                    }

                }

            }
        }
        public void Run()
        {
            int level = 1;
            Queue<Node> q = new Queue<Node>();
            List<Node> list = new List<Node>();
            Root.Level = level;
            q.Enqueue(Root);
            while (q.Count != 0)
            {
                Node x = q.Dequeue();
                list.Add(x);
                if (x.Left != null)
                {
                    x.Left.Level = x.Level + 1;
                    level = x.Left.Level > level ? x.Left.Level : level;
                    q.Enqueue(x.Left);
                }
                if (x.Right != null)
                {
                    x.Right.Level = x.Level + 1;
                    level = x.Right.Level > level ? x.Right.Level : level;
                    q.Enqueue(x.Right);
                }
            }
            Console.WriteLine("Количество уровней: "+level);
            for(int i = 1; i <= level; i++)
            {
                int num = (from c in list select c).Where(c => c.Level == i).Count();
                Console.WriteLine($"Количество элементов на {i}-м ярусе: " + num);
            }
        }


    }
}
