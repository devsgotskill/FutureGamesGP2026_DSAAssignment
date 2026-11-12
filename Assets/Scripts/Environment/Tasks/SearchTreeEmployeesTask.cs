using System;
using UnityEngine;

namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "SearchTreeEmployeesTask", menuName = "Tasks/Search Employee (Tree)")]
    public class SearchTreeEmployeesTask : Task
    {
        [SerializeField]
        public TreeEmployeesTask treeTask;
        public string targetEntranceTime = "";

        public override void Execute()
        {
            if(treeTask == null || treeTask.tree == null)
            {
                Debug.LogError("Tree is missing, run the Tree task first!");
                return;
            }

            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Employee last = treeTask.tree.FindLast();
            watch.Stop();

            if(last == null)
            {
                Debug.LogWarning("The tree is empty >:(");
                return;
            }
            Debug.Log("Last Employee Found (Tree)! Name: " + last.name + " | ID: " + last.employeeId + " | Time: " + last.lastEntranceInEngineRoom + " | Took: " + watch.Elapsed.TotalMilliseconds + " ms");

            if(targetEntranceTime == "")
            {
                return;
            }

            DateTime target = DateTime.Parse(targetEntranceTime);
            watch.Reset();
            watch.Start();
            Employee found = treeTask.tree.FindByTime(target);
            watch.Stop();

            if(found == null)
            {
                Debug.LogWarning("Nobody entered at " + targetEntranceTime);
                return;
            }
            Debug.Log("Employee at " + targetEntranceTime + ": " + found.name + " | ID: " + found.employeeId + " | Took: " + watch.Elapsed.TotalMilliseconds + " ms");
        }
    }
}
