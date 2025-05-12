using System;
using System.Collections.Generic;  // Bu kütüphane koleksiyonları (List, Dictionary) sağlar
using Newtonsoft.Json;  // JSON işlemleri için gerekli
using System.Linq;


namespace AnketApp.Utils
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();

        public TreeNode(T value)
        {
            Value = value;
        }
    }

    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }

        public Tree(T rootValue)
        {
            Root = new TreeNode<T>(rootValue);
        }

        public void AddChild(TreeNode<T> parent, TreeNode<T> child)
        {
            parent.Children.Add(child);
        }
    }
}
