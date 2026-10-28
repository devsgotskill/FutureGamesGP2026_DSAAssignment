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
            if(empArray.Length <= 1)
            {
                Debug.Log("Employees array is too short to sort.");
                return;
            }
            QuickSort(empArray, 0, empArray.Length - 1);
            insertTask.employees = empArray;
            Debug.Log("Employees successfully sorted using QuickSort!");
        }
        private void QuickSort(Employee[] array, int left, int right)
        {
            if(left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }
        private int Partition(Employee[] array, int left, int right)
        {
            int middle = left + (right - left) / 2;
            Swap(array, middle, right);
            Employee pivot = array[right];
            int i = (left - 1);
            for(int j = left; j < right; j++)
            {
                if(CompareEmployees(array[j], pivot) <= 0)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }
        private void Swap(Employee[] array, int indexA, int indexB)
        {
            Employee temp = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = temp;
        }
        private int CompareEmployees(Employee a, Employee b)
        {
            DateTime timeA = DateTime.Parse(a.lastEntranceInEngineRoom);
            DateTime timeB = DateTime.Parse(b.lastEntranceInEngineRoom);
            int timeComparison = timeA.CompareTo(timeB);
            if(timeComparison != 0)
            {
                return timeComparison;
            }
            return a.employeeId.CompareTo(b.employeeId);
        }
    }
}
