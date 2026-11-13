using System;
using UnityEngine;

namespace Environment.Tasks
{
    public class TreeNode
    {
        public Employee employee;
        public DateTime time;
        public TreeNode left;
        public TreeNode right;
        public int height = 1;
        public TreeNode(Employee employee, DateTime time)
        {
            this.employee = employee;
            this.time = time;
        }
    }
    public class EmployeeTree
    {
        public TreeNode root;
        public int count = 0;
        public void Insert(Employee employee)
        {
            DateTime time = DateTime.Parse(employee.lastEntranceInEngineRoom);
            root = InsertNode(root, employee, time);
        }
        private TreeNode InsertNode(TreeNode node, Employee employee, DateTime time)
        {
            if(node == null)
            {
                count++;
                return new TreeNode(employee, time);
            }
            int comparison = time.CompareTo(node.time);
            if(comparison == 0)
            {
                comparison = employee.employeeId.CompareTo(node.employee.employeeId);
            }
            if(comparison < 0)
            {
                node.left = InsertNode(node.left, employee, time);
            }
            else if(comparison > 0)
            {
                node.right = InsertNode(node.right, employee, time);
            }
            else
            {
                return node;
            }
            return Balance(node);
        }
        public Employee FindLast()
        {
            if(root == null)
            {
                return null;
            }
            TreeNode node = root;
            while(node.right != null)
            {
                node = node.right;
            }
            return node.employee;
        }
        public Employee FindFirst()
        {
            if(root == null)
            {
                return null;
            }
            TreeNode node = root;
            while(node.left != null)
            {
                node = node.left;
            }
            return node.employee;
        }
        public Employee FindByTime(DateTime time)
        {
            TreeNode node = root;
            while(node != null)
            {
                int comparison = time.CompareTo(node.time);
                if(comparison == 0)
                {
                    return node.employee;
                }
                if(comparison < 0)
                {
                    node = node.left;
                }
                else
                {
                    node = node.right;
                }
            }
            return null;
        }
        public int GetTreeHeight()
        {
            return GetHeight(root);
        }
        private int GetHeight(TreeNode node)
        {
            if(node == null)
            {
                return 0;
            }
            return node.height;
        }
        private void UpdateHeight(TreeNode node)
        {
            node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
        }
        private TreeNode Balance(TreeNode node)
        {
            UpdateHeight(node);
            int balance = GetHeight(node.left) - GetHeight(node.right);

            if(balance > 1)
            {
                if(GetHeight(node.left.left) < GetHeight(node.left.right))
                {
                    node.left = RotateLeft(node.left);
                }
                return RotateRight(node);
            }
            if(balance < -1)
            {
                if(GetHeight(node.right.right) < GetHeight(node.right.left))
                {
                    node.right = RotateRight(node.right);
                }
                return RotateLeft(node);
            }
            return node;
        }
        private TreeNode RotateRight(TreeNode y)
        {
            TreeNode x = y.left;
            y.left = x.right;
            x.right = y;
            UpdateHeight(y);
            UpdateHeight(x);
            return x;
        }
        private TreeNode RotateLeft(TreeNode x)
        {
            TreeNode y = x.right;
            x.right = y.left;
            y.left = x;
            UpdateHeight(x);
            UpdateHeight(y);
            return y;
        }
    }
}
