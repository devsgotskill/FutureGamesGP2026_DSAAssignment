using UnityEngine;
using Environment.Tasks;
[CreateAssetMenu(fileName = "InsertEmployeesTask", menuName = "Tasks/Insert Employees")]
public class InsertEmployeesTask : Task
{
    public Employee[] employees;
    public override void Execute()
    {
        if(employees == null)
        {
            Debug.LogWarning("No employees yet!");
            return;
        }

        foreach(Employee employee in employees)
        {
            Debug.Log("Employee: " + employee.name);
        }
    }
}
