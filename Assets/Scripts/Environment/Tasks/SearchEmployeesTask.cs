using UnityEngine;
using System;
namespace Environment.Tasks
{
    [CreateAssetMenu(fileName = "SearchEmployeesTask", menuName = "Tasks/Search Last Employee")]
    public class SearchEmployeesTask : Task
    {
        [SerializeField]
        private SortEmployeesTask sortTask;
        public override void Execute()
        {
            if(sortTask == null || sortTask.insertTask == null || sortTask.insertTask.employees == null)
            {
                Debug.LogError("SortTask, employee list is missing!");
                return;
            }
            Employee[] empArray = sortTask.insertTask.employees;
            if(empArray.Length == 0)
            {
                Debug.LogWarning("The employee array is empty >:(");
                return;
            }
            int lastIndex = empArray.Length - 1;
            Employee lastEmployee = empArray[lastIndex];
            Debug.Log("Last Employee Found! Name: " + lastEmployee.name + " | ID: " + lastEmployee.employeeId + " | Time: " + lastEmployee.lastEntranceInEngineRoom);
        }
        private int BinarySearchByTime(Employee[] array, DateTime targetTime)
        {
            int left = 0;
            int right = array.Length - 1;
            int bestIndex = -1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if(mid == array.Length - 1 || DateTime.Parse(array[mid].lastEntranceInEngineRoom) <= DateTime.Parse(array[array.Length - 1].lastEntranceInEngineRoom))
                {
                    bestIndex = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}
