using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "TreeEmployeesTask", menuName = "Tasks/Build Employee Tree")]
    public class TreeEmployeesTask : Task
    {
        [SerializeField]
        public InsertEmployeesTask insertTask;
        public EmployeeTree tree;
        public override void Execute()
        {
            if(insertTask == null || insertTask.employees == null)
            {
                Debug.LogError("No employees loaded yet, run the Read task first!");
                return;
            }
            tree = BuildTree(insertTask.employees);
            Debug.Log("Tree built with " + tree.count + " employees, height " + tree.GetTreeHeight());
        }
        public static EmployeeTree BuildTree(Employee[] employees)
        {
            EmployeeTree newTree = new EmployeeTree();
            foreach(Employee employee in employees)
            {
                newTree.Insert(employee);
            }
            return newTree;
        }
    }
}
