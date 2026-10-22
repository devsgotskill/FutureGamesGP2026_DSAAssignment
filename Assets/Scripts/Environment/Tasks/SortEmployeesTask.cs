using UnityEngine;
using System;
namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "SortEmployeesTask", menuName = "Tasks/Sort Employees")]
    public class SortEmployeesTask : Task
    {
        [SerializeField]
        private InsertEmployeesTask insertTask;
        public override void Execute()
        {
            if(insertTask == null || insertTask.employees == null)
            {
                Debug.LogError("No Insert Employees Task assigned or employees list is empty!");
                return;
            }
            Employee[] empArray = insertTask.employees;
            int n = empArray.Length;
            for(int i = 0; i < n - 1; i++)
            {
                for(int j = 0; j < n - i - 1; j++)
                {
                    DateTime timeA = DateTime.Parse(empArray[j].lastEntranceInEngineRoom);
                    DateTime timeB = DateTime.Parse(empArray[j + 1].lastEntranceInEngineRoom);
                    if(timeA.CompareTo(timeB) > 0)
                    {
                        Employee temp = empArray[j];
                        empArray[j] = empArray[j + 1];
                        empArray[j + 1] = temp;
                    }
                }
            }
            Debug.Log("Employees successfully sorted :D");
        }
    }
}
